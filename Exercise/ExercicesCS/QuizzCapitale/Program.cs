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


            Console.WriteLine("Souhaites-tu des questions aléatoires (1) ou choisir les numéros toi-même (2) ?");
            string choix = Console.ReadLine().ToUpper();

            (int n1, int n2, int n3) numeros;

            if (choix == "1")
            {
                numeros = Quizz.Saisir3Numeros();
            }
            else
            {
                numeros = Quizz.Generer3Numeros();
            }

            Console.WriteLine($"Numéros sélectionnés : {numeros.n1}, {numeros.n2}, {numeros.n3}");
            Quizz.Jouer(numeros.n1, numeros.n2, numeros.n3);

        }
    }
}
