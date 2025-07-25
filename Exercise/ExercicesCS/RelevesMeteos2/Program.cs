﻿using System;
using System.Collections.Concurrent;
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
                Console.WriteLine("3. CalculerStats1");
                Console.WriteLine("4. CalculerStats2");
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

                    case "3":
                        Console.Clear();
                        CalculerStats1();
                        Pause();
                        break;

                    case "4":
                        Console.Clear();
                        CalculerStats2();
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

        static void CalculerStats1()
        {
            IList<RelevéMensuel> relevés = DAL.GetRelevésMensuels().Values;

            //1. Mois où la T° minimale a été <= 0C et le vent >= 80km/h
            var req1 = from rel in relevés
                       where rel.Tmin <= 0 && rel.Vent >= 80
                       select rel;
            

            //2.releves de l'année 2022 par T° moyenne décroissante
            var req2 = from rel in relevés
                       where rel.Année == 2022
                       orderby rel.Tmoy descending
                       select rel;

            //3. Température maximale
            RelevéMensuel req3 = (from rel in relevés
                                  orderby rel.Tmax
                                  select rel).Last();

            Console.WriteLine("Mois où la T° min a été <= 0°C et le vent >= 80 km/h :");

           foreach (RelevéMensuel rel in req1)
            { 
                Console.WriteLine($"{rel.Mois:00}/{rel.Année} : {rel.Tmin}°C, {rel.Vent} km/h");
                
            }
            Console.WriteLine();

            Console.WriteLine("Relevés de l'année 2022 par T° décroissante");
            foreach (RelevéMensuel rel in req2)
            {
                Console.WriteLine($"{rel.Mois:00}/{rel.Année} : {rel.Tmin}°C, {rel.Vent} km/h");
                
            }
            Console.WriteLine();
            
            Console.WriteLine("Temperature maximale");
            Console.WriteLine($"T° max atteinte en {req3.Mois}/{req3.Année} : {req3.Tmax} °C");


        }

        static void CalculerStats2()
        {

            var relevés = DAL.GetRelevésMensuels().Values;
            //1. Durée moyenne d'ensoleillement des mois de juillet(F1 pour un chiffre après la virgule

            float soleil = (from rel in relevés
                            where rel.Mois == 07
                            select rel.Soleil).Average();

            Console.WriteLine($"Durée moyenne d'ensoleilemment des mois de juillet : {soleil:F1} h");
            Console.WriteLine();

            //2. Cumul de pluie par année

            var req4 = from rel in relevés
                       group rel by rel.Année into anneeGroup
                       orderby anneeGroup.Key
                       select new
                       {
                           Annee = anneeGroup.Key,
                           cumulPluie = anneeGroup.Sum(r => r.Pluie)
                       };

            foreach (var item in req4)
            {
                Console.WriteLine($"Année : {item.Annee}, Cumul de pluie : {item.cumulPluie:F1}");
            }
            Console.WriteLine();

            //3.Température moyenne et cumul de pluie par trimestre

            var req5 = from rel in relevés
                       group rel by $"T{rel.Mois / 3 + 1} - {rel.Année}" into GroupAnnée
                       select (GroupAnnée.Key, GroupAnnée.Average(rel => rel.Tmoy), GroupAnnée.Sum(r => r.Pluie));


            Console.WriteLine("Température moyenne et cumul de pluie par Trimestre : \n");

            foreach ((string trimestre, float TempMoyenne, float PluieCumulée) in req5)
            {
                Console.WriteLine($"{trimestre} : {TempMoyenne, 5:N1} °C, {PluieCumulée, 6:N1} mm.");
            }

            //4. classement temp années par temp décroissantes que années avec 12 Temp

            var req6 = from rel in relevés
                       group rel by rel.Année into groupes
                       orderby groupes.Average(rel => rel.Tmoy) descending
                       where groupes.Count() == 12
                       select (groupes.Key, groupes.Average(rel => rel.Tmoy));

            Console.WriteLine("\n Classement des années par température moyenne : ");

            foreach ((int année, float temp) in req6)
            {
                Console.WriteLine($"{année} : {temp:N1} °C.");
            }

        }
    }
  
}
