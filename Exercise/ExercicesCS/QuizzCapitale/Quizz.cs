using System;

namespace QuizzCapitale
{
    internal class Quizz
    {
        static string?[] pays = {
            "Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Biélorussie",
            "Bosnie-Herzgovine", "Bulgarie", "Chypre", "Croatie"
        };

        static string?[] capitale = {
            "Tirana", "Berlin", "Andorre-La-Vieille", "Vienne", "Bruxelles", "Minsk",
            "Sarajevo", "Sofia", "Nicosie", "Zagreb"
        };

        public static void Jouer()
        {
            bool continuer = true;

            while (continuer)
            {
                int bonnesRep = 0;

                for (int i = 0; i < pays.Length; i++)
                {
                    if (PoserQuestion(i))
                    {
                        bonnesRep++;
                    }
                }

                Console.WriteLine($"\nTu as donné {bonnesRep} bonnes réponses.");

                continuer = DemanderSiRejouer();
            }
        }
        public static void Jouer(params int[] numQuestions)
        {
            bool continuer = true;
            while (continuer)
            {
                int bonnesRep = 0;
                foreach (int num in numQuestions)
                {
                    if (num > 0 && num <= pays.Length && PoserQuestion(num-1)) bonnesRep++;
                }
                Console.WriteLine($"\n{bonnesRep} : bonnes réponses.");

                continuer= DemanderSiRejouer();
            }

            
             
  

        }

        static bool DemanderSiRejouer()
        {
            Console.WriteLine("\nVeux-tu rejouer ? (o/O pour oui, autre touche pour non)");
            string? reponse = Console.ReadLine();

            if (reponse?.ToLower() == "o")
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Merci d'avoir joué ! À bientôt.");
                return false;
            }
        }

        static bool PoserQuestion(int numQuestion)
        {
            Console.WriteLine($"\nQuelle est la capitale de {pays[numQuestion]} ?");
            string? repPays = Console.ReadLine();

            if (repPays?.Equals(capitale[numQuestion], StringComparison.OrdinalIgnoreCase) == true)
            {
                Console.WriteLine($"Bravo ! {repPays} est bien la capitale de {pays[numQuestion]}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Mauvaise réponse ! La bonne réponse était : {capitale[numQuestion]}.");
                return false;
            }
        }
    }
}
