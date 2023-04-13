using System.IO;

namespace TrovaFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                string estensione = args[0];
                string path = args[1];
                TrovaFile(estensione, path);  
            }
            else if (args.Length == 1)
            {
                string estensione = args[0];
                TrovaFile(estensione);
            }
            else
            {
                Console.WriteLine("Inserire l'estensione e il percorso!");
            }
        }

        public static void TrovaFile(String estensione, string path = "C:\\") //metodo che cerca un file con una certa estensione
        {
            IEnumerable<string> files;
            IEnumerable<string> sottodirectory;
            try //uso un try catch perchè potrei accedere a un file senza avere il permesso
            {
                files = Directory.EnumerateFiles(path);
            }
            catch (Exception errore)
            {
                files = new List<string>();
                Console.WriteLine($"{path}: Accesso negato!");
                Console.WriteLine(errore.Message);
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

            foreach (string sottocartella in sottodirectory) //richiamo ricorsivamente il metodo sulle sottocartelle
            {
                TrovaFile(estensione, sottocartella);
            }
        }
    }
}