using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassificationPeriodique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Classification Périodique des éléments");

            TableauPeriodique.ChargerFichierTxt();

            //short num1 = 35;
            //char etat = TableauPeriodique.Elements[num1].CodeEtat;

            //ConsoleColor couleur = TableauPeriodique.GetCouleurEtat(etat);
            //Console.ForegroundColor = couleur;
            //Console.WriteLine($"Élément n°{num1} → Couleur d’état : {couleur}");
            //Console.ResetColor();


            //TesterCouleurs();
            Console.WriteLine("🔧 Transformation du fichier HTML en cours...");
            TableauPeriodique.TransformerFichier();
            Console.WriteLine(" Fichier épuré généré : TableauPeriodique_epure.html");



            while (true)
            {
                short num = SaisirNuméro();


                //Console.WriteLine(TableauPeriodique.GetDetailElement(num));


                //TableauPeriodique.AfficherDetailElement(num);
                ConsoleColor couleurOrig = Console.ForegroundColor;

                //appelle de la couleur en mettant recuperant la coulelur dans le dictionnaire
                Console.ForegroundColor = TableauPeriodique.GetCouleurEtat(TableauPeriodique.Elements[num].CodeEtat);
                Console.WriteLine(TableauPeriodique.GetDetailElement(num));
                Console.ForegroundColor = couleurOrig;




                Console.WriteLine("\nAppuyez sur Echap pour quitter ou n'importe quelle autre touche pour continuer.");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    Environment.Exit(0);
                else
                    Console.Clear();

            }
        }

        public static short SaisirNuméro() 
        {
            bool saisieOK = false;

            short num = 1;
       
         

            while (!saisieOK)
            {
                Console.WriteLine("Numéro atomique de l'élément :");
                string? saisie = Console.ReadLine();

                if (short.TryParse(saisie, out num))
                {
                    if (num >= 1 && num <= 118)
                        saisieOK = true;

                    else
                        Console.WriteLine("Veuillez entrer un nombre entre 1 et 118");
                }
                else
                {
                    Console.WriteLine("Format non valide. Veuillez entrer un nombre entier.");
                }
                   
            }
            return num;
        }
        //public static void TesterCouleurs()
        //{
        //    TestEtat(34, 'S');
        //    TestEtat(35, 'L');
        //    TestEtat(36, 'G');
        //    TestEtat(109, '?');
        //    Console.ResetColor();
        //}

        //public static void TestEtat(int numero, char etat)
        //{
        //    ConsoleColor couleur = TableauPeriodique.GetCouleurEtat(etat);
        //    Console.ForegroundColor = couleur;
        //    Console.WriteLine($"Élément n°{numero} - État : {etat} → Couleur : {couleur}");
        //}



    }
}
