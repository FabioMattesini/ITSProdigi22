namespace LabirintoWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap tela = new Bitmap(100, 100);
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            pennello.Clear(Color.White);
        }

        private void pctLabirinto_MouseMove(object sender, MouseEventArgs e)
        {
            lstSoluzioni.Items.Clear();
            if(e.Button == MouseButtons.Left )
            {
                Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
                lstSoluzioni.Items.Add($"{e.Location}\t{e.Button}");
            }
            
        }
    }
}