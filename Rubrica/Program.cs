using System.Text.Json;

namespace Rubrica
{
    internal class Program
    {
        static private List<Contatto> contatti;
        static void Main(string[] args)
        {
            contatti = new List<Contatto>();
            string comando;
            do
            {
                comando = chiedi("cosa vuoi fare?");
                switch (comando)
                {
                    case "nuovo": //Create
                        contatti.Add(
                                new(
                                        chiedi("Nome:", false),
                                        chiedi("Cognome:", false),
                                        chiedi("Telefono:", false)
                                    )
                            );
                        Console.WriteLine($"Contatti presenti: {Contatto.quanti}");
                        break;

                    case "vedi": //Read
                        string chi = chiedi("Chi devo cercare?", false);
                        List<Contatto> selezionati = contatti.Where(x => x.nome.Contains(chi)).ToList();
                        foreach (Contatto singolo in selezionati)
                        {
                            Console.WriteLine(singolo);
                        }
                        break;

                        //TODO
                    case "cancella":
                        string daEliminare = chiedi("Scrivi il nome del contatto da eliminare:", false);
                        List<Contatto> lista = contatti.Where(x => x.nome.Contains(daEliminare)).ToList(); //creo una lista dei contatti potenzialmente da eliminare
                        if(lista.Count == 0) 
                        {
                            Console.WriteLine("Il contatto cercato non è presente!");
                        }
                        else
                        {
                            Console.WriteLine("Tra i contatti trovati quali devo eliminare?");
                            int i = 1;
                            foreach (var contatto in lista)
                            {
                                Console.WriteLine($"{i}){contatto}");
                                i++;
                            }
                            int index = Convert.ToInt32(chiedi("Inserisci il numero corrispondente al contatto da eliminare:", false)) - 1;
                            contatti.Remove(lista[index]); //rimuovo dai contatti il contatto specificato dall'utente
                            Contatto.quanti--;
                            Console.WriteLine("Contatto eliminato!");
                        }
                        break;

                    //TODO
                    case "modifica":
                        break;
                     
                    case "salva": //salvo la rubrica serializzandola su un file JSON
                        File.WriteAllText("rubrica.json", JsonSerializer.Serialize(contatti));
                        Console.WriteLine("Rubrica salvata su disco!");
                        break;

                    case "apri": //Deserializzo il file JSON
                        try
                        {
                            string buffer = File.ReadAllText("rubrica.json");
                            contatti = JsonSerializer.Deserialize<List<Contatto>>(buffer);
                            Console.WriteLine($"Caricati {contatti.Count} contatti");
                        }
                        catch
                        {
                            contatti = new();
                            Console.WriteLine("Errore di caricamento del file!");
                        }
                        break;

                    default:
                        Console.WriteLine("non ho capito...");
                        break;
                }

            } while (comando != "exit");
        }

        static private string chiedi(string domanda, bool corretto = true)
        {
            Console.Write($"{domanda}");
            if (corretto)
                return Console.ReadLine().ToLower().Trim();
            else
                return Console.ReadLine();
        }
    }
}