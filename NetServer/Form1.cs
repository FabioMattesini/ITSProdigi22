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
            TcpListener telefono = new TcpListener(80);
            //lo attacco al muro
            telefono.Start();
            //mi metto in ascolto finchè qualcuno non si connette
            TcpClient linea = telefono.AcceptTcpClient();
            lstRichieste.Items.Add("Richiesta in ingresso!");
            //prendiamo il ricevitore per parlare e ascoltare
            NetworkStream cornetta = linea.GetStream();
            //mi presento
            byte[] messaggio = Encoding.ASCII.GetBytes("TxtServer V1.0.0\n\rBenvenuto!\n\rComando:");
            cornetta.Write(messaggio);
            //ascolto cosa mi chiede
            List<byte> buffer = new();
            int singolo;
            do
            {
                singolo = cornetta.ReadByte();
                if(singolo > -1 && singolo != 13)
                    buffer.Add((byte)singolo);
            }while(singolo > -1 && singolo != 13);
            //potrebbe essere un file.txt
            string risposta = Encoding.ASCII.GetString(buffer.ToArray());

            string percorso = txtPath.Text;
            string percorsoFile = Path.Combine(percorso, risposta);
            if (File.Exists(percorsoFile))
            {
                byte[] contenuto = File.ReadAllBytes(percorsoFile);
                cornetta.Write(contenuto);
            }

            //riporto a schermo il messaggio del cliente
            lstRichieste.Items.Add(risposta);
            //chiudo la telefonata
            linea.Close();
            //stacco il telefono dal muro
            telefono.Stop();
            lstRichieste.Items.Add("Richiesta terminata!");
        }
    }
}