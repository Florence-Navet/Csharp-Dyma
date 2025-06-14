using System.Globalization;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RelevesMeteo
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Bienvenue dans la météo !");

            string cheminFichier = "MeteoParis.csv";

            if (File.Exists(cheminFichier))
            {
                AfficherListe(cheminFichier);
                AfficherTableau(cheminFichier);
            }
            else
            {
                Console.WriteLine("Fichier introuvable !");
            }
        }

        public static string AfficheData(string[] valeurs)
        {
            string date = valeurs[0] + "/" + valeurs[1];
            string temperatures = "[" + valeurs[2] + " ; " + valeurs[3] + "]°C";
            string soleil = valeurs[5].Replace("h ", "h");
            string pluie = valeurs[6] + " mm de pluie";

            return $"{date} : {temperatures}        {soleil} de soleil {pluie}";
        }

        public static void AfficherListe(string cheminFichier)
        {
            if (!File.Exists(cheminFichier))
            {
                Console.WriteLine($"Le fichier {cheminFichier} est introuvable.");
                return;
            }

            string[] lignes = File.ReadAllLines(cheminFichier);

            float sommeTemp = 0;
            int nbValeurs = 0;

            for (int i = 0; i < lignes.Length; i++)
            {
                string ligne = lignes[i].Replace("h ", "h").Replace("min", "");
                string[] infos = ligne.Split(";");

                Console.WriteLine($"{infos[0]}/{infos[1]} : [{infos[2]} ; {infos[3]}]°C\t" +
                                  $"{infos[6]} de soleil\t{infos[7]} mm de pluie");

                Console.WriteLine();

                if (float.TryParse(infos[4], out float temp))
                {
                    sommeTemp += temp;
                    nbValeurs++;
                }
            }
            Console.WriteLine();
            if(nbValeurs > 0)
            {
                Console.WriteLine($"T° moyenne globale : {sommeTemp / nbValeurs:F2}");
                Console.WriteLine();
            } else
            {
                Console.WriteLine("Aucune température moyenne valide trouvée.");
            }

            
        }
        public static void AfficherTableau(string cheminFichier)
        {

            if (!File.Exists(cheminFichier))
            {
                Console.WriteLine($"Le fichier {cheminFichier} est introuvable.");
                return;
            }

            string[] lignes = File.ReadAllLines(cheminFichier);


            const string entete = $"""
                Mois    | T° min | T° max | Soleil  | Pluie (mm)
                ----------------------------------------------
                """;
            Console.WriteLine(entete);
            CultureInfo culture = CultureInfo.GetCultureInfo("fr-FR");


            for (int i = 1; i < lignes.Length; i++) {

                string ligne = lignes[i].Replace("h ", "h").Replace("min", "");
                string[] infos2 = ligne.Split(";");
                int mois = int.Parse(infos2[0]);
                int annee = int.Parse(infos2[1]);
                string moisAnnee = $"{mois:00}/{annee}";


                // Parse float pour les températures, soleil, pluie (à adapter selon ton fichier)
                float tMin = float.Parse(infos2[2], culture);
                float tMax = float.Parse(infos2[3], culture);
                string soleil = infos2[6]; // ex : "59h30"
                float pluie = float.Parse(infos2[7], culture);


                //int mois = int.Parse.(infos2[0]) + "/" + int.Parse.(infos2[1]);
                //int tMin = int.Parse(infos2[2]);
                //int tMax = int.Parse(infos2[3]);
                //int soleil = int.Parse(infos2[4]);
                //int pluie = int.Parse(infos2[5]);

                Console.WriteLine($"{moisAnnee,-7} | {tMin,6} | {tMax,6} | {soleil,7} | {pluie,10}");
            }








        }






    }
}
