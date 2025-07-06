using Services;

namespace Servi_ces.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IPage accueil = new PageAccueil
            {
                Titre = "Accueil",
                Parente = null
            };

            bool continuer = true;
            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("========= ACCUEIL =========");
                Console.WriteLine("0. Quitter l'application");
                Console.WriteLine("1. Factures simples");
                Console.WriteLine("2. Factures de situation");
                Console.Write("Votre choix ? ");
                string choix = Console.ReadLine();
                Console.Clear();

                IPage pageActive = null;

                switch (choix)
                {
                    case "0":
                        continuer = false;
                        break;
                    case "1":
                        pageActive = new PageFacture
                        {
                            Titre = "Facture simple",
                            Parente = accueil
                        };
                        break;
                    case "2":
                        pageActive = new PageFactureSituation
                        {
                            Titre = "Factures de situation",
                            Parente = accueil
                        };
                        break;
                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }

                if (pageActive != null)
                {
                    pageActive.Afficher();
                    Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
