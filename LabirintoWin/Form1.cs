namespace LabirintoWin
{
    public partial class Form1 : Form
    {
        private Point precedente = new Point(0, 0);
        Pen tratto = new Pen(Color.Black, 10);
        public Form1()
        {
            InitializeComponent();
            Bitmap nuova = new Bitmap(2000, 2000); //creo l'immagine da mettere dentro la PictureBox
            pctLabirinto.Image = nuova;
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image); //prendo il pennello per disegnare sull'immagine del labirinto
            pennello.Clear(Color.White);
        }

        private void pctLabirinto_MouseMove(object sender, MouseEventArgs e)
        {
            Point attuale = new Point(e.X, e.Y);
            lstSoluzioni.Items.Clear();
            lstSoluzioni.Items.Add($"{e.Location}\t{e.Button}");
            if (e.Button == MouseButtons.Left) //se il tasto sinistro del mouse è premuto
            {
                //Bitmap attuale = (Bitmap)pctLabirinto.Image;
                Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
                pennello.DrawLine(tratto, attuale, precedente);
                //attuale.SetPixel(e.X, e.Y, Color.Black); //coloro alla posizione attuale del mouse
                pctLabirinto.Invalidate(); //forza la PictureBox ad aggiornarsi
            }
            precedente = attuale;
        }

        private void mnuSalva_Click(object sender, EventArgs e)
        {
            DialogResult risultato = dlgSalva.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                pctLabirinto.Image.Save(dlgSalva.FileName);
            }
        }

        private void mnuApri_Click(object sender, EventArgs e)
        {
            DialogResult risultato = dlgApri.ShowDialog();
            if (risultato == DialogResult.OK)
            {
                pctLabirinto.Image = Image.FromFile(dlgApri.FileName);
            }
        }

        private void cancellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            pennello.Clear(Color.White);
            pctLabirinto.Invalidate();
        }

        private void mnuPenna_Click(object sender, EventArgs e)
        {
            tratto.Color = Color.Black;
        }

        private void mnuGomma_Click(object sender, EventArgs e)
        {
            tratto.Color = Color.White;
            tratto.Width = 20;
        }
    }
}