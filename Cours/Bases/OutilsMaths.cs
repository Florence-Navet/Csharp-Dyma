using System;

#pragma warning disable IDE0130 // Le namespace ne correspond pas à la structure de dossiers
namespace Fonctions
{
    internal class OutilMaths
    {
        // Méthode pour récupérer uniquement la valeur maximale
        public static double GetValeurMaxi(params double[] nombres)
        {
            double max = double.MinValue;
            foreach (double nombre in nombres)
            {
                if (nombre > max) max = nombre;
            }
            return max;
        }

        // Méthode renommée pour obtenir à la fois min et max
        public static (double, double) GetValeursMinMax(params double[] nombres)
        {
            double min = double.MaxValue;
            double max = double.MinValue;

            foreach (double nombre in nombres)
            {
                if (nombre > max) max = nombre;
                if (nombre < min) min = nombre;
            }

            return (min, max);
        }

        //new function pour test
        public static void GetValeursMinMax(out double min, out double max, params double[] nombres)
        {
            min = double.MaxValue;
            max = double.MinValue;

            foreach (double nombre in nombres)
            {
                if (nombre > max) max = nombre;
                if (nombre < min) min = nombre;
            }



   
        }


    }
}
