namespace TerzaApp
{
    internal class Program
    {
        private static List<Casella> Scacchiera;
        private static Casella inizio;
        private static Casella fine;

        static void Main(string[] args)
        {
            Scacchiera = new List<Casella>();
            string buffer = File.ReadAllText("labirinto.txt");
            string[] righe = buffer.Split("\n"); //divido il file per righe

            for (int y=0; y<righe.Length; y++) //leggendo il file costruiamo il labirinto
            {
                string riga = righe[y];
                for (int x=0; x<righe.Length; x++)
                {
                    char cella = riga[x];
                    bool muro = cella == '1'; //se la cella contiene un 1 mettiamo muro a true
                    if (cella == 'S')
                    {
                        inizio = new(x, y, false);
                    }
                    else if (cella == 'F')
                    {
                        fine = new(x, y, false);
                    }
                    Scacchiera.Add(new (x, y, muro)); //da .NET 6.0 si può omettere il nome della classe
                }
            }

            Analizza(Scacchiera, inizio, fine);
        }

        private static void Analizza(List<Casella> scacchiera, Casella attuale, Casella arrivo)
        {
            if (attuale.x == arrivo.x && attuale.y == arrivo.y)
            {
                Console.WriteLine("Fatto!");
            }
            else
            {
                //analizza su
                Casella? su = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y - 1).FirstOrDefault(); //prendo il primo valore in alto
                if(su != null)
                {
                    Analizza(scacchiera, su, arrivo);
                }

                //analizza dx
                Casella? dx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x + 1 && cella.y == attuale.y).FirstOrDefault();
                if(dx != null)
                {
                    Analizza(scacchiera, dx, arrivo);
                }

                //analizza giu
                Casella? giu = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y + 1).FirstOrDefault();
                if (giu != null)
                {
                    Analizza(scacchiera, giu, arrivo);
                }

                //analizza sx
                Casella? sx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x - 1 && cella.y == attuale.y).FirstOrDefault();
                if (sx != null)
                {
                    Analizza(scacchiera, sx, arrivo);
                }
            }
        }
    }
}