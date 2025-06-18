using System;
using System.IO;
using System.Globalization;
using Concours;

namespace Concours
{
    internal class Program
    {
        /// <summary>
        /// mettre nullable pour eviter le soulignement
        /// </summary>
        public static (string nomComplet, double moyenne)[]? Etudiants;

        static void Main()
        {
            Console.WriteLine("Résultat Concours Étudiant !");
            string cheminFichier = "Etudiants.csv";

            if (File.Exists(cheminFichier))
            {
                ChargerDonnees(cheminFichier);
                AfficherEtudiants();
                Console.WriteLine();
                Console.WriteLine("Résultats du concours :\n");
                AfficherResultatsConcours(cheminFichier);
            }
            else
            {
                Console.WriteLine("Fichier introuvable !");
            }

            Console.ReadKey();
        }

        //charge le f iche des étudiants dans de tableau de tuples
        public static void ChargerDonnees(string chemin)
        {
            string[] lignes = File.ReadAllLines(chemin);
            Etudiants = new (string, double)[lignes.Length - 1];

            for (int i = 1; i < lignes.Length; i++) // Commencer à 1 pour sauter l'en-tête
            {
                string[] infos = lignes[i].Split(';');
                string nomComplet = infos[1] + " " + infos[0]; // Prénom Nom et infos et le nom de tableau de renvoi
                double moyenne = double.Parse(infos[4].Replace(',', '.'), CultureInfo.InvariantCulture);

                Etudiants[i - 1] = (nomComplet, moyenne);
            }
        }

        public static void AfficherEtudiants()
        {
            Console.WriteLine("Liste des étudiants :\n");

            foreach (var (nom, moyenne) in Etudiants)
            {
                Console.WriteLine($"{nom} : {moyenne} / 20");
            }
        }

        public static void AfficherResultatsConcours(string cheminFichier)
        {
            if (!File.Exists(cheminFichier))
            {
                Console.WriteLine($"Le fichier {cheminFichier} est introuvable.");
                return;
            }

            string[] lignes = File.ReadAllLines(cheminFichier);
            const int NbAdmis = 50;
            int compteurAdmis = 0;

            if (Etudiants == null) return;
            {

                foreach (var (nom, moyenne) in Etudiants)
                {
                    var mention = Notation.GetMention(moyenne);
                    string res = "";
                    if (moyenne >= 10 && compteurAdmis < NbAdmis)
                    {
                        res = "Admis";
                        compteurAdmis++;
                    }
                    Console.WriteLine($"{nom,-20} : {moyenne,5:N1}  {mention.Item2,-12} {res}");

                    //string res = moyenne >= 10 ? "Admis" : "";
                    //Console.WriteLine($"{nom,-20} : {moyenne,5:N1}  {mention.Item2,-12} {res}");

                }
            }




        }
    }
}







   
