internal class Program
{
    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        //impostiamo la base delle nostra tabellina
        int baseTabellina = 2;
        //decidiamo quante volte eseguire la moltiplicazione
        int volte = 11;
        
        for (int i = 0; i < volte; i++)
        {
            int risultato = i * baseTabellina;
            Console.WriteLine($"{i} * {baseTabellina} = {risultato}");
        }
    }
}