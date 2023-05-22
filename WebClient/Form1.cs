using System.Text.RegularExpressions;

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
                
                string pattern = @"\w+"; //prende solo le parole intere
                testo = Regex.Replace(testo, @"<script[^>]*>[^<]*<\/script>", "", RegexOptions.Singleline); //rimuove gli script javascript che contengono anche altri parametri dopo la prima scritta script
                testo = Regex.Replace(testo, @"<[^>]+>", ""); //rimuove i tag html
                testo = testo.ToLower().Trim();
                //testo = Regex.Replace(testo, @"{[^}]*}", ""); //rimuove tutti gli elementi chiusi tra graffe e le graffe
                //testo = Regex.Replace(testo, @".*}", ""); //rimuove tutte le serie di caratteri che terminano con graffe
                MatchCollection parole = Regex.Matches(testo, pattern);

                Dictionary<string, int> archivio = new();
                foreach (Match parola in parole) //se non ho mai trovato la parola la aggiungo, altrimenti incremento il suo contatore
                {
                    if (archivio.ContainsKey(parola.Value))
                    {
                        archivio[parola.Value]++;
                    }
                    else
                    {
                        archivio.Add(parola.Value, 1);
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