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
            btnCartella.Enabled = false;
            numPorta.Enabled = false;
            //costruisco il telefono
            TcpListener telefono = new TcpListener(80); //creo un listener sulla porta 80
            //lo attacco al muro
            telefono.Start(); //avvio il listener 
            //mi metto in ascolto finchè qualcuno non si connette
            TcpClient linea = telefono.AcceptTcpClient(); //accetto una richiesta del client e lo "salvo" in un oggetto TcpClient
            lstRichieste.Items.Add("Richiesta in ingresso!");
            //prendiamo il ricevitore per parlare e ascoltare
            NetworkStream cornetta = linea.GetStream(); //prendo il NetworkStream del TcpClient 

            string comando;
            do
            {
                invia(cornetta, "\n\rTxtServer V1.0.0\n\rBenvenuto!\n\rComando:");

                comando = ascolta(cornetta);
                switch (comando)
                {
                    case "carica":
                        invia(cornetta, "Quale file vuoi caricare?");
                        string file = ascolta(cornetta);
                        caricaFile(cornetta, file);
                        break;

                    case "crea":
                        invia(cornetta, "Inserisci il nome del file da creare:");
                        string daCreare = ascolta(cornetta);
                        invia(cornetta, "Inserisci il testo del file:");
                        string testo = ascolta(cornetta);
                        creaFile(daCreare, testo);
                        invia(cornetta, "File creato!");
                        break;

                    case "elimina":
                        invia(cornetta, "Inserisci il nome del file da eliminare");
                        string daEliminare = ascolta(cornetta);
                        eliminaFile(daEliminare);
                        invia(cornetta, "File eliminato!");
                        break;

                    case "visualizza":
                        invia(cornetta, $"Elenco file in {txtPath.Text}\n\r");
                        foreach (string s in Directory.GetFiles(txtPath.Text))
                        {
                            invia(cornetta, s + "\n\r");
                        }
                        break;




                    default:
                        invia(cornetta, "Comando non riconosciuto!");
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
                if (singolo > -1 && singolo != 13 && singolo != 10)
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
    }
}