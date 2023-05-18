using System.Diagnostics;
using System.Net;
using System.Text;

namespace WebServer
{
    public partial class Form1 : Form
    {
        HttpListener server;
        //HttpListenerContext richiesta;
        bool isAttivato;
        public Form1()
        {
            InitializeComponent();
            //1) permettere all'utente di selezionare una cartella di root
            //2) attendere una chiamata
            //3) capire quale pagina � richiesta
            //4) se presente spedirla
            //5) rimetteri in attesa della prossima chiamata
            //6) opzionale: permettere l'uso di pagina php
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            isAttivato = true;
            server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:8080/");
            server.Start();

            do
            {
                HttpListenerContext richiesta = server.GetContext(); //aspetto una richiesta
                Stream cornetta = richiesta.Response.OutputStream;
                string fileRichiesto = richiesta.Request.RawUrl.Substring(1); //substring(1) prende la stringa partendo dalla posizione 1 per rimuovere lo / in testa
                fileRichiesto = Path.Combine(txtPath.Text, fileRichiesto);
                lstRichieste.Items.Add(richiesta.Request.UserHostAddress + "\t" + fileRichiesto);
                caricaPagina(fileRichiesto, cornetta);

                richiesta.Response.OutputStream.Close();
            } while (server.IsListening);

            server.Close();
        }

        private void btnCartella_Click(object sender, EventArgs e)
        {
            if (dlgCartella.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlgCartella.SelectedPath;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Close();
        }

        private void caricaPagina(string url, Stream cornetta)
        {
            string nomeFile = url.Replace(txtPath.Text, "");
            if (nomeFile == "")
            {
                List<string> listaFile = Directory.EnumerateFiles(txtPath.Text).ToList();
                string elenco = String.Join("\r\n", listaFile);
                cornetta.Write(Encoding.UTF8.GetBytes(elenco));
                cornetta.Close();
            }
            else if (File.Exists(url))
            {
                if (url.EndsWith(".php"))
                {
                    Process interpretePHP = new Process();
                    interpretePHP.StartInfo.FileName = @"c:\xampp\php\php.exe"; //la @ serve per intepretare correttamente gli slash
                    interpretePHP.StartInfo.Arguments = url;
                    interpretePHP.StartInfo.RedirectStandardOutput = true;
                    interpretePHP.StartInfo.CreateNoWindow = true;
                    interpretePHP.Start();

                    string testoElaborato = interpretePHP.StandardOutput.ReadToEnd();
                    cornetta.Write(Encoding.UTF8.GetBytes(testoElaborato));
                }
                else
                {
                    byte[] contenuto = File.ReadAllBytes(url);
                    cornetta.Write(contenuto);
                }

                cornetta.Close();
            }
            else
            {
                string messaggio = "File non esistente!";
                cornetta.Write(Encoding.UTF8.GetBytes(messaggio));
                cornetta.Close();
            }
        }
    }
}