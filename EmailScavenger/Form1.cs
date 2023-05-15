using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace EmailScavenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtIndirizzo.Text = "https://it.wikipedia.org/wiki/Federico_Barbarossa";
        }

        private async void btnAnalizza_Click(object sender, EventArgs e)
        {
            string url = txtIndirizzo.Text;
            HttpClient browser = new HttpClient();
            HttpResponseMessage risposta = await browser.GetAsync(url);
            if (risposta.StatusCode == HttpStatusCode.OK)
            {
                string corpo = await risposta.Content.ReadAsStringAsync();
                string pattern = @"a href=""([^""]+)";
                MatchCollection links = Regex.Matches(corpo, pattern, RegexOptions.Multiline);
                foreach (Match link in links) 
                {
                    string indirizzo = link.Groups[1].Value; //link.Groups[0] contiene "a href" e il contenuto dello stesso, link.Groups[1] contiene solo il contenuto del link
                    if(!indirizzo.StartsWith("http"))
                        indirizzo = url + indirizzo;
                    if(!lstRisultati.Items.Contains(indirizzo))
                        lstRisultati.Items.Add(indirizzo);
                }

                //foreach(var elemento in risposta.Content.Headers) //gli elementi degli Headers sono delle coppie chiave/valore, dove il valore è un Enumerable di string
                //{
                //    string chiave = elemento.Key;
                //    string valore = string.Join(", ", elemento.Value); //unisce tutti i valori relativi alla chiave considerata
                //    lstRisultati.Items.Add($"{chiave}:\t{valore}");
                //}
            }
        }
    }
}