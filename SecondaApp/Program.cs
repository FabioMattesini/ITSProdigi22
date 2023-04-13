using System.IO;

namespace SecondaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TrovaFile(".sql");
            int tabellina = int.Parse(args[0]);
            int ripetizioni = int.Parse(args[1]);


            Moltiplica(tabellina, ripetizioni, 0);

        }

        static void Moltiplica(int tabellina, int ripetizioni, int n) //moltiplicazione tramite ricorsione
        {
            string risultato = $"{tabellina} X {n} = {tabellina * n}\n";
            File.AppendAllText($"tabellina_{tabellina}.txt", risultato);
            if(n < ripetizioni)
                Moltiplica(tabellina, ripetizioni, n + 1);
        }

        /// <summary>
        /// Metodo che cerca file con una determinata estensione in un certo path
        /// </summary>
        /// <param name="estensione">Estensione dei file da cercare</param>
        /// <param name="path">Percorso nel quale cercare i file</param>
        public static void TrovaFile(String estensione, string path = "C:\\") //metodo che cerca un file con una certa estensione
        {
            IEnumerable<string> files;
            IEnumerable<string> sottodirectory;
            try //uso un try catch perchè potrei accedere a un file senza avere il permesso
            {
                files = Directory.EnumerateFiles(path);
            }
            catch(Exception errore) 
            {
                files = new List<string>();
                Console.WriteLine($"{path}: Accesso negato!");
                Console.WriteLine( errore.Message );
            }

            try
            {
                sottodirectory = Directory.EnumerateDirectories(path);
            }
            catch (Exception errore)
            {
                sottodirectory = new List<string>();
                Console.WriteLine($"{path}: Accesso negato!");
                Console.WriteLine(errore.Message);
            }

            foreach (string singolo in files)
            {
                if (singolo.EndsWith(estensione))
                {
                    Console.WriteLine(singolo);
                }
            }

            foreach(string sottocartella in sottodirectory) //richiamo ricorsivamente il metodo sulle sottocartelle
            {
                TrovaFile(estensione, sottocartella);
            }
        }

    }
}