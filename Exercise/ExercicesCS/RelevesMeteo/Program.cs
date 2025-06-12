using System.Runtime.CompilerServices;

namespace RelevesMeteo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans la meteo !");
            Program p = new Program();

            p.DecoupeChaine();

            p.RemplaceTexte("pluie", "soleil");

        }

        public void AfficherListe()
        {
            string cheminFichier = "MeteoParis.csv";

            if (!File.Exists(cheminFichier))
            {
                Console.WriteLine($"le fichier {cheminFichier} est introuvable.");
            }
            else
            {
                return;
            }

            string[] lignes = File.ReadAllLines(cheminFichier);
            Console.WriteLine(cheminFichier);


        }
        public void DecoupeChaine()
        {
            string cheminFichier = "MeteoParis.csv";

            // Lire toutes les lignes du fichier CSV
            string[] lignes = File.ReadAllLines(cheminFichier);

            foreach (string ligne in lignes)
            {
                // Séparer les colonnes avec le point-virgule
                string[] colonnes = ligne.Split(';');

                Console.WriteLine("Contenu de la ligne :");

                // Afficher chaque colonne avec un espace
                foreach (string col in colonnes)
                {
                    Console.Write(col + " ");
                }

                Console.WriteLine(); // retour à la ligne
                Console.WriteLine("-------------------");
            }

        }

        public void RemplaceTexte(string ancienMot, string NouveauMot)
        {
            string cheminFichier = "MeteoParis.csv";

            if (!File.Exists(cheminFichier))
            {
                Console.WriteLine($"Le fichier {cheminFichier} est introuvable.");
                return;
            }
            string[] lignes = File.ReadAllLines(cheminFichier);

            foreach(string ligne in lignes)
            {
                string[] colonne = ligne.Split(",");

                if (colonne.Length > 0)
                {
                    colonne[0] = colonne[0].Replace(ancienMot, NouveauMot);
                    string nouvelleLigne = string.Join(",", colonne);
                    Console.WriteLine(nouvelleLigne);
                }
            }

        }
    }
}
