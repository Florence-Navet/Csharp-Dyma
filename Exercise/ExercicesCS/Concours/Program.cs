using System;
using System.IO;
using System.Globalization;
using Concours;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;

namespace Concours
{
    internal class Program
    {
        /// <summary>
        /// mettre nullable pour eviter le soulignement
        /// </summary>
       

        static void Main()
        {
            Console.WriteLine("Résultat Concours Étudiant !");
            string cheminFichier = "Etudiants.csv";

            if (File.Exists(cheminFichier))
            {
                DAL.ChargerDonnees(cheminFichier);
                DAL.AfficherEtudiants();
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
                AfficherTexte("Résultats du etudiants etrangers admis :\n", ConsoleColor.Blue);
                AfficherEtudiantsEtrangerAdmis(cheminFichier);
                Console.ReadKey();
                Console.Clear();
                AfficherTexte("Résultats du etudiants frnçais admis :\n", ConsoleColor.Blue);
                AfficherEtudiantsEtrangerAdmis(cheminFichier);
                Console.ReadKey();
                Console.Clear();
                AfficherTexte("Résultats du concours :\n", ConsoleColor.Cyan);
                AfficherResultatsConcours(cheminFichier);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Fichier introuvable !");
            }
            //attendre une touche et vider l'écran
            AfficherTexte("\nAppuyer sur une touche pour continuer ...", ConsoleColor.Cyan);
            Console.ReadKey();
            Console.Clear();

            //Tableau avec les nom des étudiants sortants
            //string[] sortants = { "Léa Douglas", "Claude Cartier", "Justin Leduc" };
            string[] remplacés = { "Léa Douglas", "Claude Cartier", "Justin Leduc" };

            //remplacer les admis et récupérer les nouveaux
            //List<string> nouveaux = DAL.RemplacerEtudiantsAdmis(sortants);
            string[] remplaçants = DAL.RemplacerEtudiantsAdmis(remplacés);
            for (int r = 0; r < remplacés.Length ; r++)
            {
                AfficherTexte($"\nRemplacement de {remplacés[r]} par {remplaçants[r]}", ConsoleColor.Blue);
            }

            //for (int i = 0; i < nouveaux.Count && i < sortants.Length; i++)
            //{
            //    AfficherTexte($"\nRemplacement de {sortants[i]} par {nouveaux[i]}", ConsoleColor.Blue);
            //Console.WriteLine($"{nomSortant} trouvé mais non admis, donc non remplacé");

            //affichage des remplacements


            //reaffichage des resultats avec la nouvelle mise à jour
            AfficherTexte("\nNouveaux résultats du concours", ConsoleColor.Yellow);
            AfficherResultatsConcours(cheminFichier);

            Console.WriteLine("\n-----------------------------------------------");


            Console.ReadKey();

        }





        public static void AfficherResultatsConcours(string cheminFichier)
        {
            if (!File.Exists(cheminFichier))
            {
                Console.WriteLine($"Le fichier {cheminFichier} est introuvable.");
                return;
            }

            string[] lignes = File.ReadAllLines(cheminFichier);
            //const int NbAdmis = 50;
           

            if (DAL.Etudiants == null) return;
            {
                int compteurAdmis = 0;
                foreach (var (nom, moyenne, statut) in DAL.Etudiants)
                {
                    if (statut.HasFlag(Statuts.Admis))
                    {
                        compteurAdmis++;
                        if (compteurAdmis > DAL.NbAdmis)
                            break;

                        var mention = Notation.GetMention(moyenne);
                        string res = statut.HasFlag(Statuts.Admis) ? "Admis" : "";
                        Console.WriteLine($"{nom,-20} : {moyenne,5:N1}  {mention.Item2,-12} {res}");
                    }
                    
                    //string res = "";
                    //if (moyenne >= 10 && compteurAdmis < NbAdmis)
                    //{
                    //res = "Admis";
                    //    compteurAdmis++;
                    //}


                    //string res = moyenne >= 10 ? "Admis" : "";
                    //Console.WriteLine($"{nom,-20} : {moyenne,5:N1}  {mention.Item2,-12} {res}");

                }
            }

            




        }
        public static void AfficherEtudiantsEtrangerAdmis(string cheminFichier)
        {
            if (DAL.Etudiants == null)
            {
                Console.WriteLine("Aucune donnée trouvée");
                return;
            }
            AfficherTexte("Etudiants étrangers admis : ", ConsoleColor.Red);
            Console.WriteLine();

            int compteur = 0;

            foreach (var (nom, moyenne, Statut) in DAL.Etudiants)
            {
                if (Statut.HasFlag(Statuts.Etranger) && Statut.HasFlag(Statuts.Admis))
                {
                    Console.WriteLine(nom);
                    compteur++;
                }
            }
        
            Console.WriteLine($"\nTotal : {compteur} étudiant etrangers admis");
        }

        public static void AfficherEtudiantsFrançaisBoursiers()
        {
            if (DAL.Etudiants == null) return;

            AfficherTexte("Etudiants français boursiers :\n", ConsoleColor.Gray);
            int cpt = 0;

            for (int i = 0; i < DAL.Etudiants.Length; i++)
            {
                if (!DAL.Etudiants[i].statut.HasFlag(Statuts.Etranger) &
                    DAL.Etudiants[i].statut.HasFlag(Statuts.Boursier))
                {
                    cpt++;
                    Console.WriteLine($"{DAL.Etudiants[i].nomComplet,-20}");
                }
            }

            AfficherTexte($"\nTotal : {cpt} étudiants français boursiers", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Affiche le texte dans difeeentes couleur
        /// </summary>
        /// <param name="texte"></param>
        /// <param name="couleur"></param>
        public static void AfficherTexte(string texte, ConsoleColor couleur)
        {
                ConsoleColor consoleOrig = Console.ForegroundColor;
                Console.ForegroundColor = couleur;
                Console.WriteLine(texte);
                Console.ForegroundColor = consoleOrig;


     
            Console.WriteLine(); // retour à la ligne




        }
    }
    
}







   
