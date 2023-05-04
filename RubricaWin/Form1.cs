using System.Text.Json;

namespace RubricaWin
{
    public partial class Rubrica : Form
    {
        List<Contatto> contatti = new List<Contatto>();
        public Rubrica(String filepath) //costruttore della finestra principale
        {
            InitializeComponent();
            this.Text = filepath;
            try
            {
                string buffer = File.ReadAllText(filepath);
                contatti = JsonSerializer.Deserialize<List<Contatto>>(buffer);
                foreach (Contatto c in contatti)
                {
                    lstContatti.Items.Add(c);
                }
            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            int nuovoId;
            try
            {
                nuovoId = contatti.Max(x => x.idContatto) + 1; //prendo l'id più grande presente 
            }
            catch
            {
                nuovoId = 1;
            }

            contatti.Add(new Contatto(nuovoId, txtNome.Text, txtCognome.Text, txtTelefono.Text));
            lstContatti.Items.Add(contatti[contatti.Count - 1]);
            File.WriteAllText("rubricaForm.json", JsonSerializer.Serialize(contatti));
            txtNome.Clear();
            txtCognome.Clear();
            txtTelefono.Clear();
        }

        private void btnApri_Click(object sender, EventArgs e)
        {
            Rubrica nuovaFinestra = new Rubrica("rubricaForm.json");
            //nuovaFinestra.Show();
            nuovaFinestra.FormBorderStyle = FormBorderStyle.None;
            nuovaFinestra.WindowState = FormWindowState.Maximized;
            nuovaFinestra.ShowDialog(); //blocca l'interazione sulla finestra attuale impedendo di passare a quella precedente

        }

        private void Rubrica_FormClosed(object sender, FormClosedEventArgs e)
        {
            string buffer = JsonSerializer.Serialize(lstContatti.Items);
            File.WriteAllText(this.Text, buffer);
        }
    }
}