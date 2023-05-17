using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCartella_Click(object sender, EventArgs e)
        {
            if (dlgCartella.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlgCartella.SelectedPath;
            }
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            string command = $"/C telnet 127.0.0.1 {numPorta.Value}";
            Process.Start("CMD.exe", command);
            btnCartella.Enabled = false;
            numPorta.Enabled = false;
            //costruisco il telefono
            TcpListener telefono = new TcpListener((int)numPorta.Value); //creo un listener sulla porta 80
            //lo attacco al muro
            telefono.Start(); //avvio il listener 
            //mi metto in ascolto finchè qualcuno non si connette
            TcpClient linea = telefono.AcceptTcpClient(); //accetto una richiesta del client e lo "salvo" in un oggetto TcpClient
            lstRichieste.Items.Add("Richiesta in ingresso!");
            //prendiamo il ricevitore per parlare e ascoltare
            NetworkStream cornetta = linea.GetStream(); //prendo il NetworkStream del TcpClient 
            invia(cornetta, "\n\rTxtServer V1.0.0\n\rBenvenuto!\n\r");

            string comando;
            do
            {
                
                invia(cornetta, "\n\rScrivi un comando:(carica, crea, elimina, visualizza, esegui, php, orario)\n\r");

                comando = ascolta(cornetta);
                switch (comando)
                {
                    case "carica":
                        invia(cornetta, "Quale file vuoi caricare?\n\r");
                        string file = ascolta(cornetta);
                        caricaFile(cornetta, file);
                        break;

                    case "crea":
                        invia(cornetta, "Inserisci il nome del file da creare:\n\r");
                        string daCreare = ascolta(cornetta);
                        invia(cornetta, "Inserisci il testo del file:\n\r");
                        string testo = ascolta(cornetta);
                        creaFile(daCreare, testo);
                        invia(cornetta, "File creato!\n\r");
                        break;

                    case "elimina":
                        invia(cornetta, "Inserisci il nome del file da eliminare:\n\r");
                        string daEliminare = ascolta(cornetta);
                        eliminaFile(daEliminare);
                        invia(cornetta, "File eliminato!\n\r");
                        break;

                    case "visualizza":
                        //invia(cornetta, $"{Directory.EnumerateFiles(txtPath.Text).Count()} file presenti\n\r");
                        //foreach (string s in Directory.GetFiles(txtPath.Text))
                        //{
                        //    invia(cornetta, s + "\n\r");
                        //}
                      
                        invia(cornetta, $"{Directory.EnumerateFiles(txtPath.Text).Count()} file presenti\n\r");
                        if (Directory.EnumerateFiles(txtPath.Text).Count() > 0)
                        {
                            string[] files = Directory.EnumerateFiles(txtPath.Text).ToArray();
                            string listaFile = String.Join("\r\n ", files);
                            invia(cornetta, $"{listaFile}\n\r");
                        }
                        else
                        {
                            invia(cornetta, "Nessun file presente!\n\r");
                        }

                        break;

                    case "esegui":
                        esegui(cornetta);
                        break;

                    case "php":
                        eseguiPHP(cornetta);
                        break;

                    case "orario":
                        invia(cornetta, DateTime.Now.ToShortTimeString());
                        break;

                    default:
                        invia(cornetta, "Comando non riconosciuto!\n\r");
                        break;
                }

            } while (comando != "exit");

            //chiudo la telefonata
            linea.Close();
            //stacco il telefono dal muro
            telefono.Stop();
            lstRichieste.Items.Add("Richiesta terminata!");
        }

        private string ascolta(NetworkStream cornetta)
        {
            List<byte> buffer = new();
            int singolo;
            do
            {
                singolo = cornetta.ReadByte();
                if (singolo > -1 && singolo != 13 && singolo != 10 && singolo != 8)
                    if(singolo == 8) //se ho premuto backspace elimino l'ultimo carattere
                        buffer.RemoveAt(buffer.Count - 1);
                    else
                        buffer.Add((byte)singolo);
            } while (singolo > -1 && singolo != 13);
            string risposta = Encoding.ASCII.GetString(buffer.ToArray());
            return risposta;
        }

        private void caricaFile(NetworkStream cornetta, string risposta)
        {
            string percorso = txtPath.Text;
            string percorsoFile = Path.Combine(percorso, risposta);
            if (File.Exists(percorsoFile))
            {
                byte[] contenuto = File.ReadAllBytes(percorsoFile);
                cornetta.Write(contenuto);
                string contenutoFile = Encoding.ASCII.GetString(contenuto.ToArray());
                lstRichieste.Items.Add(contenutoFile);
            }
            else
            {
                invia(cornetta, "Il file non esiste!\n\r");
            }
        }

        private void creaFile(string nomeFile, string testo)
        {
            string percorsoFile = Path.Combine(txtPath.Text, nomeFile);
            File.WriteAllText(percorsoFile, testo);
        }

        private void eliminaFile(string nomeFile)
        {
            string percorsoFile = Path.Combine(txtPath.Text, nomeFile);
            if (File.Exists(percorsoFile))
            {
                File.Delete(percorsoFile);
            }
        }

        private void invia(NetworkStream cornetta, string domanda)
        {
            byte[] messaggio = Encoding.ASCII.GetBytes(domanda);//codifico il messaggio in ASCII
            cornetta.Write(messaggio);//scrivo il messaggio sul NetworKStream
        }

        private string chiedi(NetworkStream cornetta, string domanda)
        {
            invia(cornetta, domanda);
            return ascolta(cornetta);
        }

        private void esegui(NetworkStream cornetta)
        {
            string programma = chiedi(cornetta, "Comando da eseguire:\n\r");
            string parametri = chiedi(cornetta, "Con quali parametri?\n\r");
            Process cmd = new Process();
            cmd.StartInfo.FileName = programma; //specifico il programma da eseguire
            cmd.StartInfo.Arguments = parametri; //specifico i parametri
            cmd.StartInfo.RedirectStandardOutput = true; //ridirezione l'output sullo standard output
            string risultato = "Comando non esistente!";
            try
            {
                cmd.Start();
                risultato = cmd.StandardOutput.ReadToEnd(); //leggo l'output dell'applicazione
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            invia(cornetta, risultato);
        }

        private void eseguiPHP(NetworkStream cornetta) 
        {
            string pagina = chiedi(cornetta, "Quale pagina?");
            string pathPagina = Path.Combine(txtPath.Text, pagina + ".txt"); //possimao selezionare solo file .txt
            Process interprete = new Process();
            interprete.StartInfo.FileName = @"c:\xampp\php\php.exe";
            interprete.StartInfo.Arguments = pathPagina;
            interprete.StartInfo.RedirectStandardOutput = true;
            interprete.Start();
            string paginaDinamica = interprete.StandardOutput.ReadToEnd();
            invia(cornetta, paginaDinamica);
        }
    }
}