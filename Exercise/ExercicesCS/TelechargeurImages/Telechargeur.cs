using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using System.Text.RegularExpressions;

namespace TelechargeurImages
{
    
    public static class Telechargeur
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string[]> GetUrllsImages(string url)
        {
            //using HttpClient client = new HttpClient();

            //recupération du code html de la page
            HttpResponseMessage reponse = await client.GetAsync(url);
            reponse.EnsureSuccessStatusCode();
            string html = await reponse.Content.ReadAsStringAsync();

            //recupération du code html de la page
            //string html = await client.GetStringAsync(url);

            //Recherche des urls d'images jpeg avec une regex
            var matches = Regex.Matches(html, @"=""(?<image>https://[^:""]*(\.jpg|\.jpeg))""");

            //Extraction des URL
            string[] urls = matches
                .Select(m => m.Groups["image"].Value)
                .Distinct()
                .ToArray();

            return urls;
        }

        public static async Task<string> TelechargerImageAsync(string url)
        {
            //forcer une erreur
            if (url.Contains("alouette"))
                throw new Exception("Téléchargement interdit pour les alouettes");


            using HttpClient client = new HttpClient();

            //Télécharger l'image en mémoire (flux)
            using Stream stream = await client.GetStreamAsync(url);

            //charger depuis le flux
           Image img = await Image.LoadAsync(stream);

            //Extraire un nom de fichier propre depuis URL
            string nomFichier = Path.GetFileNameWithoutExtension(url);
            if (string.IsNullOrWhiteSpace(nomFichier)) 
                nomFichier = "image" + Guid.NewGuid().ToString("N");

            nomFichier += ".webp";

            //chemin fichier dans dossier travail (deja defini via currentdirectory)
            string cheminComplet = Path.Combine(Directory.GetCurrentDirectory(), nomFichier);

            //Enregistre l'image en Webp
            await img.SaveAsWebpAsync(cheminComplet);

            //Retourner juste le nom du fichier (ou chemin complet)
            return nomFichier;
        }


    }
}
