using System.Text.Json;

namespace RubricaWin
{
    public partial class Rubrica : Form
    {
        List<Contatto> contatti = new List<Contatto>();
        public Rubrica(String filepath)
        {
            InitializeComponent();
            this.Text = filepath;
            try
            {
;                string buffer = File.ReadAllText(filepath);
                Contatto[] recuperati = JsonSerializer.Deserialize<Contatto[]>(buffer);
                lstContatti.Items.AddRange(recuperati);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string buffer = File.ReadAllText("rubricaForm.json");
                contatti = JsonSerializer.Deserialize<List<Contatto>>(buffer);
                Console.WriteLine($"Caricati {contatti.Count} contatti");
                foreach (Contatto c in contatti)
                {
                    lstContatti.Items.Add(c.ToString());
                }
            }
            catch (Exception eccezione) //si può omettere l'eccezione
            {
                contatti = new();
                Console.WriteLine("Errore di caricamento del file!");
                Console.WriteLine(eccezione.Message);
            }
        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {
            foreach (Contatto c in contatti)
            {
                lstContatti.Items.Add(c.ToString());
            }
        }
    }
}