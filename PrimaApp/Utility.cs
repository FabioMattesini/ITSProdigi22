using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaApp
{

    internal class Utility
    {
        /// <summary>
        /// funzione per porre una domanda all'utente tramite la console
        /// </summary>
        /// <param name="domanda">La domanda da porre all'utente</param>
        /// <returns>Quello che l'utente ha scritto in console</returns>
        public static string chiedi(string domanda)
        {
            //scrivo la domanda
            Console.Write(domanda + ": ");
            //recupero dal buffer la risposta
            string risposta = Console.ReadLine();
            return risposta;
        }

        /// <summary>
        /// funzione per chiedere un numero all'utente
        /// </summary>
        /// <param name="domanda">La domanda da porre all'utente</param>
        /// <returns>Il numero che l'utente ha scritto in console</returns>
        public static int chiediNumero(string domanda)
        {
            Console.Write(domanda + ": ");
            int risposta = int.Parse(Console.ReadLine());
            return risposta;
        }

        public static void scriviFile(int baseTabellina, int volte)
        {
            string nomeFile = $"tabellina_{baseTabellina}.txt";
            File.WriteAllText(nomeFile, $"TABELLINA DEL {baseTabellina}\n");

            for (int i = 0; i < volte; i++)
            {
                int risultato = i * baseTabellina;
                string testo = $"{i}\t*\t{baseTabellina}\t=\t{risultato}\n";
                File.AppendAllText(nomeFile, testo);
            }
        }
    }
}
