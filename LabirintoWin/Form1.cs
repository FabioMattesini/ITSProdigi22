using System;

namespace LabirintoWin
{
    public partial class Form1 : Form
    {
        private Point precedente = new Point(0, 0);
        Pen tratto = new Pen(Color.Black, 20);
        private int numeroCelle = 10;
        private bool[,] scacchiera;
        private bool disegnaMuro = true;
        private bool disegnaInizio = false;

        public Form1()
        {
            InitializeComponent();
            Bitmap nuova = new Bitmap(1000, 1000); //creo l'immagine da mettere dentro la PictureBox
            pctLabirinto.Image = nuova;
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image); //prendo il pennello per disegnare sull'immagine del labirinto
            pennello.Clear(Color.White);
            scacchiera = new bool[numeroCelle, numeroCelle];
        }

        private void pctLabirinto_MouseMove(object sender, MouseEventArgs e)
        {
            Point attuale = new Point(e.X, e.Y);
            lstSoluzioni.Items.Clear();
            lstSoluzioni.Items.Add($"{e.Location}\t{e.Button}");
            int rectangleWidth = pctLabirinto.Width / numeroCelle; //dimensioni del rettangolo
            int rectangleHeight = pctLabirinto.Height / numeroCelle;
            int gridX = attuale.X / rectangleWidth; //divido la posizione attuale per la dimensione del rettangolo e poi rimoltiplico di nuovo per questa per ottenere un quadrato che coincide con la griglia
            int gridY = attuale.Y / rectangleHeight;
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            Rectangle rettangolo = new Rectangle(gridX * rectangleWidth, gridY * rectangleHeight, rectangleWidth, rectangleHeight);
            Brush brush = new SolidBrush(Color.Black);

            if (e.Button == MouseButtons.Left && disegnaMuro) //se il tasto sinistro del mouse è premuto
            {
                scacchiera[gridX, gridY] = true;
                pennello.FillRectangle(brush, rettangolo);
            }
            else if (e.Button == MouseButtons.Right && disegnaMuro)
            {
                brush = new SolidBrush(Color.White);
                scacchiera[gridX, gridY] = false;
                pennello.FillRectangle(brush, rettangolo);
            }

            pctLabirinto.Invalidate(); //forza la PictureBox ad aggiornarsi
            precedente = attuale;
        }

        private void pctLabirinto_MouseClick(object sender, MouseEventArgs e)
        {
            Point attuale = new Point(e.X, e.Y);
            int rectangleWidth = pctLabirinto.Width / numeroCelle; //dimensioni del rettangolo
            int rectangleHeight = pctLabirinto.Height / numeroCelle;
            if (e.Button == MouseButtons.Left && !disegnaMuro) //inserisco l'inizio del percorso
            {
                Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
                int gridX = attuale.X / rectangleWidth;
                int gridY = attuale.Y / rectangleHeight;
                Rectangle rettangolo = new Rectangle(gridX * rectangleWidth, gridY * rectangleHeight, rectangleWidth, rectangleHeight);
                Brush b = new SolidBrush(Color.Green);
                pennello.FillRectangle(b, rettangolo);
                pctLabirinto.Invalidate();
            }
            else if (e.Button == MouseButtons.Right && !disegnaMuro)
            {
                Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
                int gridX = attuale.X / rectangleWidth;
                int gridY = attuale.Y / rectangleHeight;
                Rectangle rettangolo = new Rectangle(gridX * rectangleWidth, gridY * rectangleHeight, rectangleWidth, rectangleHeight);
                Brush b = new SolidBrush(Color.Red);
                pennello.FillRectangle(b, rettangolo);
                pctLabirinto.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

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

        private void muroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disegnaMuro = true;
        }

        private void inizioFineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disegnaMuro = false;
        }
    }
}