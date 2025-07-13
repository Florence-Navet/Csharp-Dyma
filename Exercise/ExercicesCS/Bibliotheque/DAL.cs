using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Bibliotheque
{
    public class DAL
    {
        public static List<Livre> GetLivres(string chemin)
        {
            List<Livre> livres = new();
            Livre livre = new(); // on instancie le record
            string? ligne;

            using StreamReader reader = new(chemin);

            while ((ligne = reader.ReadLine()) != null)
            {
                if (ligne.StartsWith("ISBN"))
                    livre.ISBN = ligne.Substring(7);
                else if (ligne.StartsWith("Titre"))
                    livre.Titre = ligne.Substring(8);
                else if (ligne.StartsWith("Auteur"))
                    livre.Auteur = ligne.Substring(9);
                else if (ligne.StartsWith("Image"))
                    livre.NomImage = ligne.Substring(8);
                else if (ligne.StartsWith("Publication"))
                    livre.DatePublication = DateOnly.Parse(ligne.Substring(14));
                else if (ligne.StartsWith("Description"))
                {
                    livre.Description = ligne.Substring(14);
                    livres.Add(livre with { }); // ajoute une copie du livre à la liste grace au record
                }
            }

            return livres;
        }

        public static void ExporterEnJson(List<Livre> livres, string cheminFichier)
        {
            string json = JsonSerializer.Serialize(livres, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(cheminFichier, json);
            Console.WriteLine("Export JSON terminé !");
        }

        public static void ExporterEnCSV(List<Livre> livres, string chemin)
        {
            using StreamWriter writer = new(chemin, false, Encoding.UTF8);
            writer.WriteLine("ISBN;Titre;Auteur;Image;Publication;Description");
            foreach (Livre l in livres)
            {
                writer.WriteLine($"{l.ISBN};{l.Titre};{l.Auteur};{l.NomImage};" +
                    $"{l.DatePublication};{l.Description}");

               
            }
            Console.WriteLine("Export CSV terminé ! Fichier : " + chemin);

        }
    }


    //public static void ExporterLivresJSON(List<Livre> livres, string chemin)
    //{
    //    using FileStream fs = File.Create(chemin);
    //    var options = new JsonSerializerOptions { WriteIndented = true };
    //    JsonSerializer.Serialize(fs, livres, options);
    //}

}

