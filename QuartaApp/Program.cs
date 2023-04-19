using System.Reflection;

namespace QuartaApp
{
    internal class Program
    {
        static private List<Persona> persone = new List<Persona>();

        static void Main(string[] args)
        {
            //esempio di riferimento
            int prima = 1;
            int seconda = 2;
            somma(ref prima, seconda);
            Console.WriteLine(prima);
            //esempio di somma delle età
            persone.Add(new Persona("John", "Doe", 18));
            persone.Add(new Persona("Federico", "Rossi", 20));

            Persona nuova = new Persona(persone[0].nome, persone[0].cognome, persone[0].eta);
            nuova.eta = 65;

            Clona(nuova);

            int totale = sommaEta(persone[0], persone[1]);
            Console.WriteLine($"Totale delle età: {totale}");
            Console.WriteLine($"Perchè John ha {persone[0].eta}, mentre Federico ha {persone[1].eta}");
        }

        static int sommaEta(Persona prima, Persona seconda)
        {
            prima.eta += seconda.eta;
            return prima.eta;
        }

        static void somma(ref int a, int b)
        {
            a = a + b;
            Console.WriteLine($"Sto stampando a: {a}");
        }

        
        static void Clona(object oggetto)
        {
            Type tipo = oggetto.GetType();
            PropertyInfo[] props = tipo.GetProperties(); //ottengo le proprietà del tipo
            foreach (PropertyInfo pi in props)
            {
                Console.WriteLine($"Dimmi {pi.Name}");
                var appoggio = Console.ReadLine();
            }
        }
    }
}