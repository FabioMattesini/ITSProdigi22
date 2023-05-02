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
                comando = chiedi("cosa vuoi fare?\n-nuovo\n-vedi\n-cancella\n-modifica\n-salva\n-apri\n");
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
                            foreach (Contatto contatto in lista)
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

                    case "modifica":
                        string daModificare = chiedi("Scrivi il nome del contatto da modificare:");
                        List<Contatto> listModify = contatti.Where(x => x.nome.Contains(daModificare)).ToList();
                        if(listModify.Count == 0)
                        {
                            Console.WriteLine("Il contatto cercato non è presente!");
                        }
                        else
                        {
                            Console.WriteLine("Tra i contatti trovati quali devo modificare?");
                            int i = 1;
                            foreach(Contatto contatto in listModify) 
                            {
                                Console.WriteLine($"{i}){contatto}");
                                i++;
                            }
                            int index = Convert.ToInt32(chiedi("Inserisci il numero corrispondente al contatto da modificare:", false)) - 1;
                            string nome = chiedi("Inserisci il nuovo nome (lasciare vuoto se non si intende modificare):");
                            string cognome = chiedi("Inserisci il nuovo cognome (lasciare vuoto se non si intende modificare):");
                            string telefono = chiedi("Inserisci il nuovo nuemro di telefono (lasciare vuoto se non si intende modificare)");
                            if(!nome.Trim().Equals(""))
                                listModify[index].nome = nome;
                            if (!cognome.Trim().Equals(""))
                                listModify[index].cognome = cognome;
                            if (!telefono.Trim().Equals(""))
                                listModify[index].telefono = telefono;

                            Console.WriteLine("Contatto modificato!");
                        }
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