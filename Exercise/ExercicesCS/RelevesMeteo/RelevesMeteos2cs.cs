﻿/*using System;

namespace RelevesMeteo2
{
    internal class Program2
    {
        static void Main2(string[] args)
        {
            Afficherliste2();
            Console.WriteLine();
            AfficherTableau2();
        }

        static void Afficherliste2()
        {
            string[] lignes = File.ReadAllLines("meteoParis.csv");

            float sommeTemp = 0f;
            for (int i = 0; i < lignes.Length; i++)
            {
                //simplifie le format des des heures d'ensoleillement
                string ligne = lignes[i].Replace("h ", "h").Replace("min", " ");

                //récupère les infos de la ligne sous la forme souhaitée
                string[] infos = ligne.Split(";");

                //construit une ligne sous la forme souhaitée
                Console.WriteLine($"{infos[0]}/{infos[1]} : [{infos[2]} ; {infos[3]}]°C\t" +
                    $"{infos[6]} de soleil\t{infos[7]} mm de pluie");

                //Ajoute la température moyenne au cumul
                if (float.TryParse(infos[4], out float temp))
                    sommeTemp += temp;
                
            }
            Console.WriteLine();
            Console.WriteLine($"T° moyenne globale : {sommeTemp /(lignes.Length) -1}");

        }
        static void AfficherTableau2()
        {
            const string entetes = """
			Mois | T° min | T° max | Soleil | Pluie (mm)
		-----------------------------------------------
		""";
            Console.WriteLine(entetes);

            string[] lignes = File.ReadAllLines("meteoParis.csv");
            for (int i = 1; i < lignes.Length; i++)
            {
                // Simplifie le format des heures d'ensoleillement
                string ligne = lignes[i].Replace("h ", "h").Replace("min", "");

                // Récupère les infos de la ligne dans un tableau
                string[] infos = ligne.Split(';');

                // Transforme les chaînes en nombres
                if (float.TryParse(infos[2], out float tmin) &&
                    float.TryParse(infos[3], out float tmax) &&
                    float.TryParse(infos[7], out float pluie))
                {
                    // Affiche la ligne sous la forme souhaitée
                    Console.WriteLine($"{infos[0]}/{infos[1]} | {tmin,6:N1} | {tmax,6:N1} | {infos[6],6} | {pluie,10:N1}");
                }
                else
                    Console.WriteLine("Erreur à la ligne {0}", i);
            }
        }
    }
}*/