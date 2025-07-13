using System;
using System.Collections.Generic;
using System.IO;


namespace Bibliotheque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chemin = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    "Bibliotheque",
    "livres.txt"
);


            if (!File.Exists(chemin))
            {
                Console.WriteLine($"le fichier {chemin} n'existe pas");
                return;
            }


            List<string> list = new List<string>();

            // Appel à la méthode pour charger les livres
            List<Livre> livres = DAL.GetLivres(chemin);

            //string cheminHtml = Path.Combine("C:\\Users\\enola\\Documents\\Bibliotheque", "bibliotheque.html");
            string cheminHtml = Path.Combine("Bibliotheque", "bibliotheque.html");
            //HTMLWriter.GénérerPage(livres, cheminHtml);
            HTMLWriter.GénérerPage(livres, Path.ChangeExtension(chemin, ".htm"));
            //DAL.ExporterLivresJSON(livres, Path.ChangeExtension(chemin, ".json"));

            string dossierExport = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    "Bibliotheque"
);

            Directory.CreateDirectory(dossierExport); // ← très important


            //string cheminJson = Path.Combine("Bibliotheque", "livres.json");
            //DAL.ExporterEnJson(livres, cheminJson);

            DAL.ExporterEnJson(livres, Path.ChangeExtension(chemin, ".json"));




            //string cheminCsv = Path.Combine(dossierExport, "livres_export.csv");
            //DAL.ExporterEnCSV(livres, cheminCsv);
            DAL.ExporterEnCSV(livres, Path.ChangeExtension(chemin, ".csv"));

            //System.Diagnostics.Process.Start("code", cheminCsv);
            //System.Diagnostics.Process.Start("code", cheminJson);


            Console.WriteLine("Page HTML générée !");

            Console.WriteLine("Livres chargés : " + livres.Count);
        }
    }
}
