using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace TelechargeurImages
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string dossierImages = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            string dossierWeb = Path.Combine(dossierImages, "DossierWeb", "ImagesWeb");

            if (!Directory.Exists(dossierWeb))
            {
                Directory.CreateDirectory(dossierWeb);
            }

            string urlPage = "https://binette-et-jardin.ouest-france.fr/dossiers-cat3-59-oiseaux.html";

            Directory.SetCurrentDirectory(dossierWeb);

            Console.WriteLine("Dossier de travail défini : " + Directory.GetCurrentDirectory());

            string[] urls = await Telechargeur.GetUrllsImages(urlPage);

            Console.WriteLine($"Nombre d'images trouvées : {urls.Length}");

            foreach (var img in urls)
            {
                Console.WriteLine(img);
            }

  
            await TelechargerImagesUneParUne(urls);
            //await TelechargerImagesEnParallele(urls);
        }
        public static async Task TelechargerImagesUneParUne(string[] urls)
        {
            Stopwatch chrono = Stopwatch.StartNew();
            int ok = 0, erreur = 0;

            foreach (string url in urls)
            {
                try
                {
                    string nom = await Telechargeur.TelechargerImageAsync(url);
                    Console.WriteLine($"✅ Image téléchargée : {nom}");
                    ok++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur pour {url} : {ex.Message}");
                    erreur++;
                }
            }

            chrono.Stop();
            Console.WriteLine($"\nTemps total : {chrono.ElapsedMilliseconds} ms");
            Console.WriteLine($"{ok} image(s) téléchargée(s)");
            Console.WriteLine($"{erreur} échec(s)");
        }

        public static async Task TelechargerImagesEnParallele(string[] urls)
        {
            Stopwatch chrono = Stopwatch.StartNew();
            int ok = 0, erreur = 0;

            var taches = urls.Select(async url =>
            {
                try
                {
                    string nom = await Telechargeur.TelechargerImageAsync(url);
                    Console.WriteLine($"Images {nom}");
                    Interlocked.Increment(ref ok);
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Erreur pour {url} : {ex.Message}");
                    Interlocked.Increment(ref ok);

                }
            });
            await Task.WhenAll(taches);

            chrono.Stop();
            Console.WriteLine($"\nTemps total : {chrono.ElapsedMilliseconds} ms");
            Console.WriteLine($"{ok} image(s) téléchargée(s)");
            Console.WriteLine($"{erreur} échec(s)");
        }

    }
}