namespace WebClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnVai_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            lstParole.Items.Clear();
            HttpClient browser = new HttpClient();
            HttpResponseMessage risposta = await browser.GetAsync(url); //await aspetta il risultato di GetAsync
            if(risposta.IsSuccessStatusCode)
            {
                string testo = await risposta.Content.ReadAsStringAsync();
                //REGEX ???
                string[] parole = testo.Split(" "); //???
                /*
                 * ["casa","gatto","cane","boh","nonso","cellulare"]
                 * ["immobile","felix felix","lupus","incertezza","grave incertezza","apparecchio radio"]
                */
                Dictionary<string, int> archivio = new();
                foreach (string parola in parole) //se non ho mai trovato la parola la aggiungo, altrimenti incremento il suo contatore
                {
                    if (archivio.ContainsKey(parola))
                    {
                        archivio[parola]++;
                    }
                    else
                    {
                        archivio.Add(parola, 1);
                    }
                }

                foreach(KeyValuePair<string,int> coppia in archivio.OrderByDescending(x => x.Value)) //ordino l'archivio in base alle parole che appaiono più volte
                {
                    lstParole.Items.Add($"{coppia.Key}\t{coppia.Value}");
                }
            }
            
        }
    }
}