using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases
{
    internal class DemoEnums
    {
        public static void TesterJour() {}
        /// <summary>
        /// Montre comment utiliser une énumération définies par .Net
        /// </summary>
        public static void TesterEnums()
        {
            string message;

            DateTime dt = DateTime.Now;
            switch (dt.DayOfWeek) {
                case DayOfWeek.Friday:
                    message = "Bientôt en week-end ! ";
                    break;

                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    message = "Profite bien de ton week-end";
                    break;

                default:
                    message = $"{DayOfWeek.Saturday - dt.DayOfWeek} jours avant le week-end...";
                    break;
            }
            Console.WriteLine($"Aujourd'hui c'est le {dt.ToString("dddd")}");
            Console.WriteLine(message);
            Console.WriteLine();
            
        }
        public static void TesterItérationEnum(int i) {
            string[] couleur = new string[0];  // tableau vide


            //Memorisations de la couleurs de police d'origine
            ConsoleColor consoleOrig = Console.ForegroundColor;

            //Parcours des couleurs posssible
            for(ConsoleColor c = ConsoleColor.Black; c <= ConsoleColor.White; c++)
            {
                Console.ForegroundColor = c;
                Console.WriteLine($"  {c:D}  :  {c}");

            }

            string[] couleurs = {
                "Noir", "Bleu foncé", "Vert foncé", "Cyan foncé", "Rouge foncé",
                "Magenta foncé", "Jaune foncé", "Gris clair", "Gris foncé", "Bleu",
                "Vert", "Cyan", "Rouge", "Magenta", "Jaune", "Blanc"
            };

            foreach (ConsoleColor c1 in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.ForegroundColor = c1;
                Console.WriteLine($"  {c1:D}  :  {couleurs[(int)c1]}");
            }

            //restauration de la couleur d'origine
            Console.ForegroundColor= consoleOrig;
        }
        
    }
}
