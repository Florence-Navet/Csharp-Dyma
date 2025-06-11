using System;


namespace Foncions
{
    internal class OutilMaths
    {
        public static double GetValeurMaxi(params double[] nombres)
        {
            double max = double.MinValue;
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] > max) max = nombres[i];
            }
            return max;
        }
        public static (double, double) GetValeurMaxi(params double[] nombres)
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
    }


}
