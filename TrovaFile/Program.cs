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

        /// <summary>
        /// Metodo che cerca tutti i file con una certa estensione nel path specificato ricorsivamente
        /// </summary>
        /// <param name="estensione">Estensione dei file da cercare</param>
        /// <param name="path">Path di partenza della ricerca</param>
        public static void TrovaFile(String estensione, string path = "C:\\") //metodo che cerca un file con una certa estensione
        {
            IEnumerable<string> files;
            IEnumerable<string> sottodirectory;
            try //uso un try catch perchè potrei accedere a un file senza avere il permesso
            {
                files = Directory.EnumerateFiles(path); //EnumerateFiles mi restituisce il nome di tutti i file nel path specificato
            }
            catch (Exception errore)
            {
                files = new List<string>();
                Console.WriteLine($"{path}: Accesso negato!");
                Console.WriteLine(errore.Message);
            }

            try
            {
                sottodirectory = Directory.EnumerateDirectories(path); //EnumerateDirectories restituisce il nome di tutte le cartelle nel path specificato
            }
            catch (Exception errore)
            {
                sottodirectory = new List<string>();
                Console.WriteLine($"{path}: Accesso negato!");
                Console.WriteLine(errore.Message);
            }

            foreach (string singolo in files)
            {
                if (singolo.EndsWith(estensione)) //stampo tutti i file che finiscono con l'estensione specificata
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