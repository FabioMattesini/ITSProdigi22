using PrimaApp;
using System.IO;

internal class Program
{

    private static void Main(string[] args) //primo parametro sarà la base della tabellina, il secondo sarà la quantità di volte
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        bool ripeti = true;
        
        while (ripeti) {
            int baseTabellina;
            int volte;

            if (args.Length == 2)
            {
                baseTabellina = int.Parse(args[0]);
                volte = int.Parse(args[1]) + 1;
            }
            else
            {
                baseTabellina = Utility.chiediNumero("Che tabellina vuoi?");
                volte = Utility.chiediNumero("Quante volte vuoi ripetere la tabellina?") + 1;
            }

            string nomeFile = $"tabellina_{baseTabellina}.txt";
            File.WriteAllText(nomeFile, $"TABELLINA DEL {baseTabellina}\n");

            for (int i = 0; i < volte; i++)
            {
                int risultato = i * baseTabellina;
                string testo = $"{i}\t*\t{baseTabellina}\t=\t{risultato}\n";
                //Console.Write(testo);
                File.AppendAllText(nomeFile, testo);
            }

            if(args.Length == 0)
            {
                string risposta = Utility.chiedi("Vuoi un'altra tabellina? (s/n)");
                ripeti = risposta == "s";
            }
            else
            {
                ripeti = false;
            }
            
            if(args.Length == 0)
            {
                Console.WriteLine("Buona giornata!");
            }

        }
    }
    
}