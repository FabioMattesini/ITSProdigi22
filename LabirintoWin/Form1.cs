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
        private Point inizio;
        private Point fine;

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
            //lstSoluzioni.Items.Clear();
            //lstSoluzioni.Items.Add($"{e.Location}\t{e.Button}");
            int rectangleWidth = pctLabirinto.Width / numeroCelle; //dimensioni del rettangolo
            int rectangleHeight = pctLabirinto.Height / numeroCelle;
            int gridX = attuale.X / rectangleWidth; //divido la posizione attuale per la dimensione del rettangolo e poi rimoltiplico di nuovo per questa per ottenere un quadrato che coincide con la griglia
            int gridY = attuale.Y / rectangleHeight;
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            Rectangle rettangolo = new Rectangle(gridX * rectangleWidth, gridY * rectangleHeight, rectangleWidth, rectangleHeight);
            Brush brush = new SolidBrush(Color.Black);

            if (e.Button == MouseButtons.Left && disegnaMuro) //se il tasto sinistro del mouse è premuto
            {
                try
                {
                    scacchiera[gridX, gridY] = true;
                    pennello.FillRectangle(brush, rettangolo);
                }
                catch { }
            }
            else if (e.Button == MouseButtons.Right && disegnaMuro)
            {
                brush = new SolidBrush(Color.White);
                try
                {
                    scacchiera[gridX, gridY] = false;
                    pennello.FillRectangle(brush, rettangolo);
                }
                catch { }
            }

            pctLabirinto.Invalidate(); //forza la PictureBox ad aggiornarsi
            precedente = attuale;
        }

        private void pctLabirinto_MouseClick(object sender, MouseEventArgs e)
        {
            Point attuale = new Point(e.X, e.Y);
            int rectangleWidth = pctLabirinto.Width / numeroCelle; //dimensioni del rettangolo
            int rectangleHeight = pctLabirinto.Height / numeroCelle;
            Graphics pennello = Graphics.FromImage(pctLabirinto.Image);
            int gridX = attuale.X / rectangleWidth;
            int gridY = attuale.Y / rectangleHeight;
            Rectangle rettangolo = new Rectangle(gridX * rectangleWidth, gridY * rectangleHeight, rectangleWidth, rectangleHeight);
            Brush brush = new SolidBrush(Color.Green);

            if (e.Button == MouseButtons.Left && !disegnaMuro) //inserisco l'inizio del percorso
            {
                pennello.FillRectangle(brush, rettangolo);
                inizio = new Point(gridX, gridY);
            }
            else if (e.Button == MouseButtons.Right && !disegnaMuro)
            {
                brush = new SolidBrush(Color.Red);
                pennello.FillRectangle(brush, rettangolo);
                fine = new Point(gridX, gridY);
            }
            pctLabirinto.Invalidate();
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

        private void btnRisolvi_Click(object sender, EventArgs e)
        {
            scansiona(scacchiera, inizio, fine, new List<Point>());
        }

        private void scansiona(bool[,] labirinto, Point start, Point finish, List<Point> percorso = null) //tengo una lista del percorso
        {
            if (start == finish)
            {
                lstSoluzioni.Items.Add($"Percorso:");
                foreach (Point p in percorso)
                {
                    lstSoluzioni.Items.Add($"X:{p.X} - Y:{p.Y}");
                }
            }
            else
            {
                percorso.Add(start);
                //creo una lista di possibili caselle da esplorare, cioè quelle adiacenti
                List<Point?> possibilita = new List<Point?>() {//con if in linea controllo se sto andando in una cella fuori dal labirinto, nel quale caso metto la cella a null
                    start.Y - 1 >= 0 ? new Point(start.X, start.Y - 1) : null, //top
                    start.X - 1 >= 0 ? new Point(start.X - 1, start.Y) : null, //left
                    start.X + 1 < numeroCelle ? new Point(start.X + 1, start.Y) : null, //right
                    start.Y + 1 < numeroCelle ? new Point(start.X, start.Y + 1) : null //bottom
                };
                
                foreach (Point? p in possibilita)
                {
                    if(p.HasValue && !labirinto[p.Value.X, p.Value.Y] && !percorso.Contains(p.Value))//se la cella considerata non è un muro e non l'ho già esplorata la scansiono
                    {
                        scansiona(labirinto, p.Value, finish, percorso);
                    }
                }
            }
        }
    }
}