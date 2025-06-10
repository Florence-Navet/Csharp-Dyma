using System;

namespace Functions
{
    internal class Quizz
    {
        public static string?[] pays = { "Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Biélorussie",
                                         "Bosnie-Herzégovine", "Bulgarie", "Chypre", "Croatie" };

        public static string?[] capitale = { "Tirana", "Berlin", "Andorre-La-Vieille", "Vienne",
                                              "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb" };

        public static void Jouer()
        {
            //bool rejouer = true;

            //while (rejouer)
            //{
            //    int bonRep = PoserQuestions();
            //    AfficherScore(bonRep);

            //    rejoue
            //    r = DemanderRejouer();
            //}

            Jouer(Enumerable.Range(0, pays.Length).ToArray()); // Appelle la version avec toutes les questions
        }
        public static void Jouer(params int[] numQuestions)
        {
            int bonRep = 0;

            foreach (int index in numQuestions)
            {
                if (index >= 1 && index <= 10) // 🔹 Correction : Vérifier si l'index est bien dans [1, 10]
                {
                    int tableauIndex = index - 1; // 🔹 Ajustement de l’index (1 devient 0, 2 devient 1, etc.)

                    Console.WriteLine($"\nQuelle est la capitale de {pays[tableauIndex]} ?");
                    string repPays = Console.ReadLine();

                    if (repPays.Equals(capitale[tableauIndex], StringComparison.OrdinalIgnoreCase))
                    {
                        bonRep++;
                        Console.WriteLine($"Bravo ! {repPays} est bien la capitale de {pays[tableauIndex]}");
                    }
                    else
                    {
                        Console.WriteLine($"Mauvaise réponse ! La bonne réponse est {capitale[tableauIndex]}");
                    }
                }
                else
                {
                    Console.WriteLine($"⚠️ Numéro de question {index} incorrect. Veuillez choisir entre 1 et 10.");
                }
            }

            AfficherScore(bonRep);
            DemanderRejouer();
        }


        // 🔹 Méthode pour poser les questions du quizz
        private static int PoserQuestions()
        {
            int bonRep = 0;

            for (int p = 0; p < pays.Length; p++)
            {
                Console.WriteLine($"\nQuelle est la capitale de {pays[p]} ?");
                string repPays = Console.ReadLine();

                if (repPays.Equals(capitale[p], StringComparison.OrdinalIgnoreCase))
                {
                    bonRep++;
                    Console.WriteLine($"Bravo ! {repPays} est bien la capitale de {pays[p]} !");
                }
                else
                {
                    Console.WriteLine($"Mauvaise réponse !! La bonne réponse était : {capitale[p]} !");
                }
            }

            return bonRep;
        }

        // 🔹 Méthode pour afficher le score
        private static void AfficherScore(int bonRep)
        {
            Console.WriteLine($"Vous avez {bonRep} bonnes réponses.");
        }

        // 🔹 Méthode pour demander si l'utilisateur veut rejouer
        private static bool DemanderRejouer()
        {
            Console.WriteLine("Veux-tu rejouer ? (o/O pour oui, autre touche pour non)");
            string reponse = Console.ReadLine();

            if (reponse.ToLower() == "o")
            {
                Console.Clear();
                return true;
            }

            Console.WriteLine("Merci d'avoir joué ! À bientôt !");
            return false;
        }

        
    }
}
