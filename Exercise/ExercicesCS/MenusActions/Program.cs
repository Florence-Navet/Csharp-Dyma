using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;

namespace MenusActions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //liste de couples libellé action
            List<(string libellé, Action action)> menu = new List<(string, Action)>
            {
                ("Quitter l'application", () => Environment.Exit(0)),
                ("Action 1", Actions.Action1),
                ("Action 2", Actions.Action2),

            };

            while (true)
            {
                var libellés = menu.Select(m => m.libellé);

                int choix = AfficherMenu(libellés);
                Console.Clear();

                menu[choix].action();

                Console.WriteLine("\nAppuyer sur une touche pour revenir au menu...");
                //Console.ReadKey();
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
                Console.Clear();

            }

        }
        private static int AfficherMenu(IEnumerable<string> libellésMenus)
        {
            int index = 0;
         

            //  Affichage du menu
            Console.WriteLine("\n=================== MENU ========================");

            foreach (var libellé in libellésMenus)
            {
                Console.WriteLine($"{index}. {libellé}");
                index++;

            }
            int choix = -1;
            bool choixOk = false;


            while (!choixOk)
            {
                Console.Write("\nVotre choix : ");
                string? rep = Console.ReadLine();
                choixOk = int.TryParse(rep, out choix) && choix >= 0 && choix <= 2;

                if (!choixOk)
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
            }
            return choix;



        }
    }
}
