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
            string soleil = valeurs[5].Replace(" ", "");
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

            double SommeTemp = 0;
            int NbValeurs = 0;

            for (int i = 1; i < lignes.Length; i++)
            {
                string[] valeurs = lignes[i].Split(';');
                if (double.TryParse(valeurs[2], out double tMin) && double.TryParse(valeurs[3], out double tMax))
                {
                    SommeTemp += tMin + tMax;
                    NbValeurs += 2;
                }
                string resultat = AfficheData(valeurs);

                Console.WriteLine(resultat);
            }
            if (NbValeurs > 0)
            {
                double moyenne = SommeTemp / NbValeurs;
                Console.WriteLine($"Température moyenne égale : {moyenne}");

            } else
            {
                Console.WriteLine("Aucune température valide trouvée.");
            }
        }
       


    }
}
