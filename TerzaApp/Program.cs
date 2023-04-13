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
            string[] righe = buffer.Replace("\r","").Split("\n"); //divido il file per righe

            for (int y=0; y<righe.Length; y++) //leggendo il file costruiamo il labirinto
            {
                string riga = righe[y];
                for (int x=0; x<riga.Length; x++)
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
            List<Casella>? percorso = null;
            Analizza(Scacchiera, inizio, fine, percorso);
        }

        private static void Analizza(List<Casella> scacchiera, Casella attuale, Casella arrivo, List<Casella>? percorso)
        {
            if(percorso == null)
            {
                percorso = new List<Casella>();
                percorso.Add(attuale);
            }

            if (attuale.x == arrivo.x && attuale.y == arrivo.y)
            {
                Console.WriteLine("Fatto!");
                Console.WriteLine("Percorso eseguito:");
                foreach (Casella c in percorso)
                {
                    Console.WriteLine($"X:{c.x} - Y:{c.y}");
                }
            }
            else
            {
                //analizza su
                Casella? su = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y - 1).FirstOrDefault(); //prendo il primo valore in alto
                if(su != null)
                {
                    su.muro = true;
                    percorso.Add(su);
                    Analizza(scacchiera, su, arrivo, percorso);
                }

                //analizza dx
                Casella? dx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x + 1 && cella.y == attuale.y).FirstOrDefault();
                if(dx != null)
                {
                    dx.muro = true;
                    percorso.Add(dx);
                    Analizza(scacchiera, dx, arrivo, percorso);
                }

                //analizza giu
                Casella? giu = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y + 1).FirstOrDefault();
                if (giu != null)
                {
                    giu.muro = true;
                    percorso.Add(giu);
                    Analizza(scacchiera, giu, arrivo, percorso);
                }

                //analizza sx
                Casella? sx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x - 1 && cella.y == attuale.y).FirstOrDefault();
                if (sx != null)
                {
                    sx.muro = true;
                    percorso.Add(sx);
                    Analizza(scacchiera, sx, arrivo, percorso);
                }

                percorso.RemoveAt(percorso.Count-1);
            }
        }
    }
}