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
            Stopwatch sw = new();
            sw.Start();
            //await TelechargerImagesUneParUne(urls);
            //await TelechargerImagesEnParalleleAsync(urls);
           
            await TelechargerImagesEnParallele2Async(urls);
            sw.Stop();
            Console.WriteLine($"\nTemps d'execution : {sw.ElapsedMilliseconds} ms");
            sw.Reset();
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

        public static async Task TelechargerImagesEnParalleleAsync(string[] urls)
        {
            Stopwatch chrono = Stopwatch.StartNew();
            int ok = 0, erreur = 0;

            List<Task<string>> taches = new();
            foreach (string url in urls)
            {
                taches.Add(Telechargeur.TelechargerImageAsync(url));
            }

            //..puis attends leurs resultat et les affiche dans l'ordre de la liste

            foreach (Task<string> tache in taches)
            {
                {
                    try
                    {
                        string nom = await tache;
                        Console.WriteLine($"Images telechargées {nom}");
                        Interlocked.Increment(ref ok);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Erreur pour {tache} : {ex.Message}");
                        Interlocked.Increment(ref ok);

                    }
                };
            }
          
            //await Task.WhenAll(taches);

            chrono.Stop();
            Console.WriteLine($"\nTemps total : {chrono.ElapsedMilliseconds} ms");
            Console.WriteLine($"{ok} image(s) téléchargée(s)");
            Console.WriteLine($"{erreur} échec(s)");
        }


        private static async Task TelechargerImagesEnParallele2Async(string[] urls)
        {
            // Lance les tâches pour télécharger et enregistrer les images
            List<Task<string>> taches = new();
            foreach (string url in urls)
            {
                taches.Add(Telechargeur.TelechargerImageAsync(url));
            }

            // ...puis affiche leurs résultats dans l'ordre où elles se terminent
            while (taches.Any())
            {
                Task<string> tache = await Task.WhenAny(taches);
                try
                {
                    Console.WriteLine("Image téléchargée : " + tache.Result);
                }
                catch (AggregateException ae)
                {
                    foreach (Exception e in ae.InnerExceptions)
                    {
                        Console.WriteLine($"Image non téléchargée : {e.Message}");
                    }
                }
                taches.Remove(tache);
            }
        }
    }
}