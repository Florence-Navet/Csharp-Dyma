using System;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;
using System.Xml.Serialization;
using System.Threading.Channels;
using static System.Math;


namespace POO2
{
    internal class Class1
    {
        public static void TesterNS()
        {
            Console.WriteLine();

            StringBuilder sb;

            XmlSerializer xs;
        }
     
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Sqrt(Pow(y2 - y1, 2) + Pow(x1 - x2, 2));
        }
    }
}
    
   