using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerations
{
    public enum TaillesChemises { XS=36, S=37, M=38, L=40, XL=42, XXL=44 }
    internal class DemoEnumsPerso
    {
        public static TaillesChemises ConvertirTaille(int tf)
        {
            TaillesChemises res =TaillesChemises.XS;
            foreach (TaillesChemises taille in Enum.GetValues(typeof(TaillesChemises)))
            {
                if ((int)taille <= tf)
                    res = taille;
                else
                    break;
                
            }
            return res;
        }

        public static void TesterConversion()
        {

            for (int i = 36; i < 45 ; i++)
            {
                TaillesChemises t = ConvertirTaille(i);
                Console.WriteLine($"{i} : {t}");
            }


        }
        public static void TesterInterpretation()
        {
            TaillesChemises taille = TaillesChemises.M;
            bool repOk = false;
            while (!repOk)
            {
                Console.WriteLine("Quelle est votre taille (XS -> XL) ?");
                string? rep = Console.ReadLine();
                repOk = Enum.TryParse(rep, out taille) && Enum.IsDefined(taille);
            }
            Console.WriteLine($"Votre taille est {taille}");
        }
        public static void TesterInterpretationEntier(int n)
        {
            if (Enum.IsDefined(typeof(TaillesChemises), n))
            {
                TaillesChemises t = (TaillesChemises)n;
                Console.WriteLine(t);
            } else
            {
                Console.WriteLine($"{n} ne correspond pas à la valeur ennuméré");
            }
        }
    }
}
