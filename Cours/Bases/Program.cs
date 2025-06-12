using System;
using Fonctions;
using Bidule;
using System.Drawing;
using System.ComponentModel;
using Array;
using ChaineInterpolees;
using Echanges;
using Variables;
using TypeVariables;
using Chaines;
using ChainesString;

namespace Fonctions
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("=== DemoString ===");
            DemoString dem = new DemoString(); // créer une instance
            dem.ConstruireChaines();

            Console.WriteLine("=== Test sur chaine de caracteres ===");
            DemoString dem1 = new DemoString(); // créer une instance
            dem1.TesterMethodeStatique();

            Console.WriteLine("=== Test sur chaine de caracteres ===");
            DemoString dem2 = new DemoString(); // créer une instance
            dem2.TesterMethodesInstances();


            Console.WriteLine("=== Test sur chaine de caracteres ===");
            DemoString dem3 = new DemoString(); // créer une instance
            dem3.Couperchaines();


            Console.WriteLine("=== Test sur chaine de caracteres ===");
            ChaineCaracteres chai = new ChaineCaracteres(); // créer une instance
            chai.AfficherChaines();

            Console.WriteLine("=== Test du type de variables ===");
            DifferentesVariables var = new DifferentesVariables(); // créer une instance
            var.Tester();

            Console.WriteLine("=== Test des variables===");
            Affichage ec = new Affichage(); // créer une instance
            ec.EcrireTerminal();

            Console.WriteLine("=== Test des ifelseSwitch===");
            Toto ag = new Toto(); // créer une instance
            ag.DonnerAge();

            Console.WriteLine("=== Test des chaines interpolees===");
            DateAge an = new DateAge(); // créer une instance
            an.AfficherAge();


            Console.WriteLine("=== Test des scores===");
            Scores sc = new Scores(); // créer une instance
            sc.AfficherScores();

            Console.WriteLine("=== Test des fonctions sets de jeu ===");
            WhileFor wf = new WhileFor(); // créer une instance pour iterations
            wf.Run();
            Console.WriteLine("=== Test des fonctions OutilMaths ===");

            double max = OutilMaths.GetValeurMaxi(1.2, 5.4, 3.3);
            Console.WriteLine($"Valeur maximale : {max}");

            (double min, double max2) = OutilMaths.GetValeursMinMax(1.2, 5.4, 3.3);
            Console.WriteLine($"Valeur minimale : {min}, Valeur maximale : {max2}");

            (double x, double y, double z) point = (2.2, 3.3, 4.4);
            Console.WriteLine($"{point.x}, {point.y}, {point.y}");

            //appelle nouvelle double GetValeursMinMax
            OutilMaths.GetValeursMinMax(out double mini, out double maxi, 1.2, 3.7, 5.8, 9.4);
            Console.WriteLine($"valeurs mini et maxi sont {mini} et {maxi}.");


            //Utiliser un paramètre en out + return
            //bool repOk;
            //do
            //{
            //    Console.WriteLine("Saisissez un nombre compris entre 1 et 10 :");
            //    string rep = Console.ReadLine();
            //    repOk = int.TryParse(repOk, out int nombre) && nombre >= 1 && nombre <= 10;

            //}
            //while (!repOk);


        }


    }
}
