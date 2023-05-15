using System.Net;
using System.Net.Http.Headers;

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
                foreach(var elemento in risposta.Content.Headers)
                {
                    string chiave = elemento.Key;
                    string valore = string.Join(", ", elemento.Value);
                    lstRisultati.Items.Add($"{chiave}:\t{valore}");
                }
            }
        }
    }
}