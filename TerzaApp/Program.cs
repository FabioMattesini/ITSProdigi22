namespace TerzaApp
{
    internal class Program
    {
        private static List<Casella> Scacchiera;
        private static Casella inizio;
        private static Casella fine;
        private static List<String> soluzioni = new List<string>();

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

            //List<Casella>? percorso = null;
            //Analizza(Scacchiera, inizio, fine, percorso);

            //soluzione prof
            Analizza2(Scacchiera, inizio, fine);
            string migliore = soluzioni.OrderBy( x => x.Length).FirstOrDefault(); //ordino le soluzioni per lunghezza e estraggo la prima
            if(migliore != null )
            {
                Console.WriteLine($"Vince:{migliore}");
            }
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

        private static void AnalizzaProf(List<Casella> scacchiera, Casella attuale, Casella arrivo, string percorso="")
        {
            

            if (attuale.x == arrivo.x && attuale.y == arrivo.y)
            {
                soluzioni.Add(percorso);
                Console.WriteLine("Fatto:" + percorso);
            }
            else
            {
                //analizza su
                Casella? su = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y - 1).FirstOrDefault(); //prendo il primo valore in alto
                if (su != null && !percorso.Contains($"[{su.x} {su.y}]")) //se la prossima casella non è nulla e percorso non contiene già la casella continuo ad analizzare
                {
                    AnalizzaProf(scacchiera, su, arrivo, percorso + $"[{attuale.x} {attuale.y}]"); //aggiungo al percorso la mia posizione attuale
                }

                //analizza dx
                Casella? dx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x + 1 && cella.y == attuale.y).FirstOrDefault();
                if (dx != null && !percorso.Contains($"[{dx.x} {dx.y}]"))
                {
                    AnalizzaProf(scacchiera, dx, arrivo, percorso + $"[{attuale.x} {attuale.y}]");
                }

                //analizza giu
                Casella? giu = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x && cella.y == attuale.y + 1).FirstOrDefault();
                if (giu != null && !percorso.Contains($"[{giu.x} {giu.y}]"))
                {
                    AnalizzaProf(scacchiera, giu, arrivo, percorso + $"[{attuale.x} {attuale.y}]");
                }

                //analizza sx
                Casella? sx = scacchiera.Where(cella => cella.muro == false && cella.x == attuale.x - 1 && cella.y == attuale.y).FirstOrDefault();
                if (sx != null && !percorso.Contains($"[{sx.x} {sx.y}]"))
                {
                    AnalizzaProf(scacchiera, sx, arrivo, percorso + $"[{attuale.x} {attuale.y}]");
                }

            }
        }

        private static void Analizza2(List<Casella> scacchiera, Casella da, Casella a, String percorso="") //versione ottimizzata di AnalizzaProf
        {
            //somportamento selettivo
            if(da.y == a.y && da.x == a.x)
            {
                soluzioni.Add(percorso);
                Console.WriteLine(percorso);
            }

            //navigazione
            List<Casella> possibili = scacchiera.Where( //ottengo una lista di tutte le casella nelle quali mi posso muovere
                cella => cella.muro == false &&
                    (
                        (cella.x == da.x && cella.y == da.y - 1) ||
                        (cella.x == da.x && cella.y == da.y + 1) ||
                        (cella.x == da.x - 1 && cella.y == da.y) ||
                        (cella.x == da.x + 1 && cella.y == da.y)
                    )
                    ).ToList();

            foreach (Casella singola in possibili) //scorro le celle possibili e le analizzo
            {
                if(!percorso.Contains($"[{singola.x} {singola.y}]"))
                {
                    Analizza2(scacchiera, singola, a, $"{percorso} [{da.x} {da.y}]"); //aggiungo al percorso la casella attuale
                }
            }
        }
    }
}