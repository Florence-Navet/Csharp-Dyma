using System.Runtime.CompilerServices;

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
            } else
            {
                Console.WriteLine("Aucune température moyenne valide trouvée.");
            }

            
        }
       


    }
}
