using PrimaApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        bool ripeti = true;
        
        while (ripeti) {
            //impostiamo la base delle nostra tabellina
            string richiesta = Utility.chiedi("Che tabellina vuoi?");
            int baseTabellina = int.Parse(richiesta);
            //decidiamo quante volte eseguire la moltiplicazione
            richiesta = "Quante volte vuoi ripetere la tabellina?";
            int volte = Utility.chiediNumero(richiesta) + 1;

            for (int i = 0; i < volte; i++)
            {
                int risultato = i * baseTabellina;
                Console.WriteLine($"{i}\t*\t{baseTabellina}\t=\t{risultato}");
                //Console.WriteLine(i.ToString() + " * " + baseTabellina.ToString() + " = " + risultato.ToString());
            }

            string risposta = Utility.chiedi("Vuoi un'altra tabellina? (s/n)");
            ripeti = risposta == "s";
        }

        Console.WriteLine("Buona giornata!");
    }

    
}