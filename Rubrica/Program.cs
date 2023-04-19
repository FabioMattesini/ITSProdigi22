namespace Rubrica
{
    internal class Program
    {
        static private List<Contatto> contatti;
        static void Main(string[] args)
        {
            contatti = new List<Contatto>();
            string comando = "";

        }

        static private string chiedi(string domanda)
        {
            Console.Write($"{domanda} :");
            return Console.ReadLine();
        }
    }
}