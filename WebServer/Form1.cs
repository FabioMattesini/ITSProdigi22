using System.Diagnostics;
using System.Net;
using System.Text;

namespace WebServer
{
    public partial class Form1 : Form
    {
        HttpListener server;
        HttpListenerContext richiesta;
        bool isAttivato;
        public Form1()
        {
            InitializeComponent();
            //1) permettere all'utente di selezionare una cartella di root
            //2) attendere una chiamata
            //3) capire quale pagina è richiesta
            //4) se presente spedirla
            //5) rimetteri in attesa della prossima chiamata
            //6) opzionale: permettre l'uso di pagina php
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            isAttivato = true;
            server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:8080/");
            server.Start();

            do
            {
                richiesta = server.GetContext(); //aspetto una richiesta
                Stream cornetta = richiesta.Response.OutputStream;
                caricaPagina(richiesta.Request.RawUrl, cornetta);

                richiesta.Response.OutputStream.Close();
            } while (isAttivato);
            
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
            string file = url.Replace("/", "");
            string percorsoFile = Path.Combine(txtPath.Text, file);
            if(File.Exists(percorsoFile))
            {
                //byte[] contenuto = File.ReadAllBytes(percorsoFile);
                //cornetta.Write(contenuto);
                Process interpretePHP = new Process();
                interpretePHP.StartInfo.FileName = @"c:\xampp\php\php.exe"; //la @ serve per intepretare correttamente gli slash
                interpretePHP.StartInfo.Arguments = percorsoFile;
                interpretePHP.StartInfo.RedirectStandardOutput = true;
                interpretePHP.StartInfo.CreateNoWindow = true;
                interpretePHP.Start();

                string testoElaborato = interpretePHP.StandardOutput.ReadToEnd();
                cornetta.Write(Encoding.UTF8.GetBytes(testoElaborato));
            }
            else
            {
                string messaggio = "File non esistente!";
                cornetta.Write(Encoding.UTF8.GetBytes(messaggio));
            }
        }
    }
}