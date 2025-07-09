using System;
using System.Collections.Generic;

namespace RelevésMétéo2
{
    internal class Program
    {
        static void Main()
        {
            var liste = DAL.GetRelevésMensuels();

            bool continuer = true;

            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Afficher tous les relevés mensuels");
                Console.WriteLine("2. Afficher les statistiques trimestrielles");
                Console.WriteLine("0. Quitter");
                Console.Write("\nVotre choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "0":
                        continuer = false;
                        break;

                    case "1":
                        Console.Clear();
                        Console.WriteLine(RelevéMensuel.EnTeteTableau);
                        foreach (var item in liste)
                        {
                            Console.WriteLine(item.Value);
                        }
                        Pause();
                        break;

                    case "2":
                        Console.Clear();
                        AfficherStatsTrimestrielles(liste);
                        Pause();
                        break;

                    default:
                        Console.WriteLine("Choix invalide !");
                        Pause();
                        break;
                }
            }

            Console.WriteLine("Fin du programme. Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

        static void Pause()
        {
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        static void AfficherStatsTrimestrielles(SortedList<DateOnly, RelevéMensuel> liste)
        {
            Console.WriteLine($"Statistiques trimestrielles entre {liste.Keys[0]:MMM yyyy} et {liste.Keys[^1]:MMM yyyy} :\n");

            //var stats = new Dictionary<(int année, int trimestre), (float sommeTemp, float sommePluie, int nb)>();

            Dictionary<string, (float tempMoyenne, float pluieCumulée)> stats = new();
            float cumulTemp = 0f, cumulPluie = 0f;
            int nbMois = 0;

            foreach (var kvp in liste)
            {
                var relevé = kvp.Value;
                cumulTemp += relevé.Tmoy;
                cumulPluie += relevé.Pluie;
                nbMois++;

                // Si c’est la fin d’un trimestre (mois divisible par 3), on stocke les données
                if (relevé.Mois % 3 == 0)
                {
                    int trimestre = (relevé.Mois - 1) / 3 + 1;
                    string clé = $"T{trimestre}-{relevé.Année}";

                    float moyenneTemp = cumulTemp / nbMois;
                    stats[clé] = (moyenneTemp, cumulPluie);

                    // Remise à zéro des cumuls
                    cumulTemp = 0f;
                    cumulPluie = 0f;
                    nbMois = 0;
                }
            }

            // Affichage
            foreach (var clé in stats.Keys)
            {
                var (moyTemp, pluieTotale) = stats[clé];
                Console.WriteLine($"{clé} : {moyTemp,5:N1} °C, {pluieTotale,6:N1} mm");
            }


            //foreach (var kvp in liste)
            //{
            //    var relevé = kvp.Value;
            //    int trimestre = (relevé.Mois - 1) / 3 + 1;
            //    var clé = (relevé.Année, trimestre);

            //    if (!stats.ContainsKey(clé))
            //        stats[clé] = (0, 0, 0);

            //    var (sTemp, sPluie, count) = stats[clé];
            //    stats[clé] = (sTemp + relevé.Tmoy, sPluie + relevé.Pluie, count + 1);
            //}

            //foreach (var clé in stats.Keys)
            //{
            //    var (sTemp, sPluie, count) = stats[clé];
            //    float moyTemp = sTemp / count;
            //    float cumulPluie = sPluie;
            //    Console.WriteLine($"T{clé.trimestre}-{clé.année} : {moyTemp,5:N1} °C, {cumulPluie,6:N1} mm");
            //}
        }
    }
}
