using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace ChainesString
{
    internal class DemoString
    {
        public void ConstruireChaines()
        {
            string mot = "abracadabra";
            int cpt = 0;
            for (int c = 0; c < mot.Length; c++)
            {
                if (mot[c] == 'a') cpt++;
            }
            Console.WriteLine($"Il y a {cpt} 'a' dans {mot}"); // Il y a 5 'a' dans abracadabra
        }

        public void TesterMethodeStatique()
        {
            string s1 = "un texte";
            string s2 = "découpé en plusieurs morceaux";
            string s3 = "pour le test du cours";

            //concatenation
            string res1 = string.Concat(s1, " ", s2, "\n", s3, " !");
            Console.WriteLine($"Concat :\n{res1}\n");

            //assemblage en utilisant un séparateur donné
            string res2 = string.Join("\n", s1,s2,s3);
            Console.WriteLine($"Join : \n{res2}\n");

            //assemblage via une chaine de format et des jetons
            string res3 = string.Format("Le {0:dd MMMM} est le {1}ème jourde l'année", DateTime.Today, DateTime.Today.DayOfYear);
            Console.WriteLine($"Format : \n{res3}\n");

            //verifier si une chaine est null, vide ou constitue d'espace blanc
            Console.WriteLine();
            string? rep;
            do
            {
                Console.WriteLine("Saisissez le nom d'un anime : ");
                rep = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(rep));
            Console.WriteLine($"Votre anime est : {rep} !");


        }
        public void TesterMethodesInstances()
        {
            string s = "chaîne de caractères";
            Console.WriteLine(s.Contains("car"));  // True
            Console.WriteLine(s.StartsWith("ch")); // True
            Console.WriteLine(s.EndsWith("es"));   // True
            Console.WriteLine(s.IndexOf('h'));     // 1
            Console.WriteLine(s.LastIndexOf('c')); // 14
            Console.WriteLine(s.Substring(4, 2));  // ne
            Console.WriteLine(s.Replace(' ', '\n'));  // espaces remplacés par des retours à la ligne
            Console.WriteLine(s.ToUpper());  // CHAÎNE DE CARACTÈRES
        }

        public void Couperchaines()
        {
            string s = """
   Au 30 juin 2022, en France, 51 % des abonnements internet à haut et très haut débit
   étaient en fibre optique (+ 11 points en un an).
   """;

            int nbLettres = 0, nbChiffres = 0, nbPonctuations = 0, nbEspaces = 0, nbSymboles = 0;
            int nbMajuscules = 0;
            foreach (char c in s.ToCharArray())
            {
                if (char.IsLetter(c))
                    nbLettres++;
                else if (char.IsDigit(c))
                    nbChiffres++;
                else if (char.IsPunctuation(c))
                    nbPonctuations++;
                else if (char.IsWhiteSpace(c))
                    nbEspaces++;
                else if (char.IsSymbol(c))
                    nbSymboles++;

                if (char.IsUpper(c)) nbMajuscules++;
            }

            string res = $"""
   {s.Length} caractères, dont :
   - {nbLettres} lettres, dont {nbMajuscules} majuscules
   - {nbChiffres} chiffres
   - {nbPonctuations} ponctuations
   - {nbEspaces} espaces
   - {nbSymboles} symboles
   """;

            Console.WriteLine(res);
        }
    }
}


