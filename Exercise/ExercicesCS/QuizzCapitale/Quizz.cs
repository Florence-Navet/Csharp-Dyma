using System;
using System.Net.WebSockets;
using System.Globalization;
using System.Text;

namespace Functions
{
    internal class Quizz
    {
        public static string?[] pays = { "Albanie", "Allemagne", "Corée du Sud", "Autriche", "Belgique", "Espagne",
                                         "Bosnie-Herzégovine", "Bulgarie", "Australie", "Danemark" };

        public static string?[] capitale = { "Tirana", "Berlin", "Séoul", "Vienne",
                                              "Bruxelles", "Madrid", "Sarajevo", "Sofia", "Canberra", "Copenhague" };

        public static void Jouer()
        {
            bool rejouer = true;

            while (rejouer)
            {
                int bonRep = PoserQuestions();
                AfficherScore(bonRep);

              
                rejouer = DemanderRejouer();
                
            }

            //Jouer(Enumerable.Range(0, pays.Length).ToArray()); // Appelle la version avec toutes les questions
        }
        public static void Jouer(params int[] numQuestions)
        {
            int bonRep = 0;

            foreach (int index in numQuestions)
            {
                if (index >= 1 && index <= 10) 
                {
                    int tableauIndex = index - 1; 

                    Console.WriteLine($"\nQuelle est la capitale de {pays[tableauIndex]} ?");
                    string? repPays = Console.ReadLine();

                    if (Normaliser(repPays) == Normaliser(capitale[tableauIndex]))

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
                    Console.WriteLine($"Numéro de question {index} incorrect. Veuillez choisir entre 1 et 10.");
                }
            }

            AfficherScore(bonRep);
            //DemanderRejouer();
        }
        public static (int, int, int) Generer3Numeros()
        {
            (int num1, int num2, int num3) numeros;
            Random rand = new Random();
            numeros.num1 = rand.Next(1, 11);
            numeros.num2 = rand.Next(1, 11);
            numeros.num3 = rand.Next(1, 11);
            return numeros;

  




        }
        public static (int, int, int) Saisir3Numeros()
        {
            (int num1, int num2, int num3) numeros;
            Console.WriteLine("Saisis le premier numéro (entre 1 et 10) :");
            numeros.num1 = SaisirNombre(1, 10);

            Console.WriteLine("Saisis le deuxième numéro (entre 1 et 10) :");
            numeros.num2 = SaisirNombre(1, 10);

            Console.WriteLine("Saisis le troisième numéro (entre 1 et 10) :");
            numeros.num3 = SaisirNombre(1, 10);

            return numeros;

        }


        public static int SaisirNombre(int min, int max)
        {
            Console.WriteLine($"Entre un nombre valide entre {min} et {max}:");
            bool repOk;
            int num;
            do
            {
                string? rep = Console.ReadLine();
                repOk = int.TryParse(rep, out num) && num >= min && num <= max;
            }
            while (!repOk);

            return num;


            /*int nombre = 0;
            bool valide = false;

            do
            {
                Console.WriteLine($"Entre un nombre valide entre {min} et {max}:");
                string? saisie = Console.ReadLine();

                //convertir entier en entier
                if (int.TryParse(saisie, out nombre))
                {
                    if (nombre >=min && nombre <= max)
                    {
                        valide = true;
                    }
                    else
                    {
                        Console.WriteLine($"Erreur : Le nombre doit être entre {min} et {max}.");
                    }
                } else
                {
                    Console.WriteLine("Erreur : Veuillez saisir un nombre valide.");
                }
               

            } while (!valide);
             return nombre;*/
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
        private static string Normaliser(string? texte)
        {
            if (string.IsNullOrEmpty(texte)) return "";

            string normalise = texte.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalise)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().ToLower().Normalize(NormalizationForm.FormC);
        }


        // 🔹 Méthode pour demander si l'utilisateur veut rejouer
        public static bool DemanderRejouer()
        {
            Console.WriteLine("Veux-tu rejouer ? (o/O pour oui, autre touche pour non)");
            string reponse = Console.ReadLine();

            if (reponse.ToLower() == "o")
            {
                Console.Clear();
                return true;
            }

            Console.WriteLine("Merci d'avoir joué ! À bientôt !");
            Environment.Exit(0);
            return false;
            
        }

        // Méthode de normalisation (supprime les accents, met en minuscules)






    }
}
