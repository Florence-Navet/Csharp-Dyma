using System;

namespace Fonctions
{
    internal class OutilsMaths
    {
        public static double GetValeurMaxi(params double[] nombres)
        {
            if (nombres == null || nombres.Length == 0)
                throw new ArgumentException("Le tableau ne doit pas être vide ou null.");

            double max = double.MinValue;
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] > max)
                {
                    max = nombres[i]; // ✅ Correction des accolades
                }
            }

            return max;
        }
    }
}
