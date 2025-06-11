using System;
using Fonctions;
using Bidule;
using System.Drawing;
using System.ComponentModel;

namespace Fonctions
{
    internal class Program
    {
        static void Main(string[] args)

        {
           Console.WriteLine("=== Test des fonctions sets de jeu ===");
            WhileFor wf = new WhileFor(); // créer une instance
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
            bool repOk;
            do
            {
                Console.WriteLine("Saisissez un nombre compris entre 1 et 10 :");
                string.Compare rep = Console.ReadLine();
                repOk = int.TryParse(repOk, out int nombre) && nombre >= 1 && nombre <= 10;

            }
            while (!repOk);


        }


    }
}
