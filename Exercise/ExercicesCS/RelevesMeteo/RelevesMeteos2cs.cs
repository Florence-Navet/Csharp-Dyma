/*using System;

namespace RelevesMeteo2
{
    internal class Program2
    {
        static void Main2(string[] args)
        {
            Afficherliste2();
            Console.WriteLine();
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
    }
}*/