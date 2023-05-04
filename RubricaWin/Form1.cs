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
                //string buffer = File.ReadAllText(filepath);
                contatti = JsonSerializer.Deserialize<List<Contatto>>(File.ReadAllText(filepath));
                foreach (Contatto c in contatti)
                {
                    lstContatti.Items.Add(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            save();
            clearAllTextBox();
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

        private void lstContatti_SelectedIndexChanged(object sender, EventArgs e) //quando si seleziona un contatto riporta i dati sulle textbox
        {
            int index = lstContatti.SelectedIndex;
            try
            {
                txtNome.Text = contatti[index].nome;
                txtCognome.Text = contatti[index].cognome;
                txtTelefono.Text = contatti[index].telefono;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void lstContatti_KeyPress(object sender, KeyPressEventArgs e)
        {
            int index = lstContatti.SelectedIndex;
            if (e.KeyChar == 8) //numero del backspace
            {
                try
                {
                    contatti.RemoveAt(index);
                    lstContatti.Items.RemoveAt(index);
                    save();
                    clearAllTextBox();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void clearAllTextBox()
        {
            txtNome.Clear();
            txtCognome.Clear();
            txtTelefono.Clear();
        }

        private void save()
        {
            File.WriteAllText("rubricaForm.json", JsonSerializer.Serialize(contatti));
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            int index = lstContatti.SelectedIndex;
            try
            {
                Contatto daModificare = contatti[index];
                FormModifica frmModifica = new FormModifica(daModificare, this);
                frmModifica.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            clearAllTextBox();
        }

        private void Rubrica_Activated(object sender, EventArgs e)
        {
            lstContatti.Items.Clear();
            foreach (Contatto c in contatti)
            {
                lstContatti.Items.Add(c);
            }
        }
    }
}