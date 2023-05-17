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
                //string messaggio = $"sito in costruzione: {richiesta.Request.RawUrl}";
                //byte[] pachetto = Encoding.UTF8.GetBytes(messaggio);
                Stream cornetta = richiesta.Response.OutputStream;
                //cornetta.Write(pachetto); //scrivo un messaggio sullo stream di output
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
            richiesta.Response.OutputStream.Close();
            server.Close();
        }

        private void caricaPagina(string url, Stream cornetta)
        {
            string file = url.Replace("/", "");
            string percorsoFile = Path.Combine(txtPath.Text, file);
            if(File.Exists(percorsoFile))
            {
                byte[] contenuto = File.ReadAllBytes(percorsoFile);
                cornetta.Write(contenuto);
            }
            else
            {
                string messaggio = "File non esistente!";
                cornetta.Write(Encoding.UTF8.GetBytes(messaggio));
            }
        }
    }
}