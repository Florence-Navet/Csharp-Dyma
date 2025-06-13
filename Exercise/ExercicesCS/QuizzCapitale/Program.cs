using System;
using Functions;

namespace MonApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu de Quizz !");

            //var numeros = Quizz.Generer3Numeros();
            //Console.WriteLine($"Numéros générés : {numeros.Item1}, {numeros.Item2}, {numeros.Item3}");
            //Quizz.Jouer(numeros.Item1, numeros.Item2, numeros.Item3);


            Console.WriteLine("Souhaites-tu :");
            Console.WriteLine("1 - Saisir 3 numéros de questions");
            Console.WriteLine("2 - Obtenir 3 numéros aléatoires");
            Console.WriteLine("3 - Faire tout le quiz");
            Console.Write("Ton choix : ");
            string choix = Console.ReadLine().ToUpper();

            (int n1, int n2, int n3) numeros;
            bool rejouer = true;

            while (rejouer) {

                if (choix == "1")
                {
                    numeros = Quizz.Saisir3Numeros();
                    Console.WriteLine($"Numéros sélectionnés : {numeros.n1}, {numeros.n2}, {numeros.n3}");
                    Quizz.Jouer(numeros.n1, numeros.n2, numeros.n3);
                    rejouer = Quizz.DemanderRejouer();

                }
                else if (choix == "2")
                {
                    numeros = Quizz.Generer3Numeros();
                    Console.WriteLine($"Numéros générés : {numeros.n1}, {numeros.n2}, {numeros.n3}");
                    Quizz.Jouer(numeros.n1, numeros.n2, numeros.n3);
                    rejouer = Quizz.DemanderRejouer();


                }
                else if (choix == "3")
                {
                    int totalQuestions = 10;
                    for (int i = 0; i < totalQuestions; i++)
                    {
                        Quizz.Jouer(); 
                        rejouer = Quizz.DemanderRejouer();

                    }

                }
                else
                {
                    Console.WriteLine("Choix invalide !! Veuillez saisir 1, 2 ou 3");
                }



            }

          

        }
    }
}
