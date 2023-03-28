internal class Program
{
    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        //impostiamo la base delle nostra tabellina
        string richiesta = chiedi("Che tabellina vuoi?");
        int baseTabellina = int.Parse(richiesta);
        //decidiamo quante volte eseguire la moltiplicazione
        richiesta = "Quante volte vuoi ripetere la tabellina?";
        int volte = chiediNumero(richiesta);
        
        for (int i = 0; i < volte; i++)
        {
            int risultato = i * baseTabellina;
            Console.WriteLine($"{i}\t*\t{baseTabellina}\t=\t{risultato}");
            //Console.WriteLine(i.ToString() + " * " + baseTabellina.ToString() + " = " + risultato.ToString());
        }
    }

    /// <summary>
    /// funzione per porre una domanda all'utente tramite la console
    /// </summary>
    /// <param name="domanda">La domanda da porre all'utente</param>
    /// <returns>Quello che l'utente ha scritto in console</returns>
    private static string chiedi(string domanda)
    {
        //scrivo la domanda
        Console.Write(domanda + ": ");
        //recupero dal buffer la risposta
        string risposta = Console.ReadLine();
        return risposta;
    }

    private static int chiediNumero(string domanda)
    {
        Console.Write(domanda + ": ");
        int risposta = int.Parse(Console.ReadLine());
        return risposta;
    }
}