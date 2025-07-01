using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Boites
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Job sur les Boites");
            //1.instancier une boite
            Boite maBoite = new Boite(15, 12, 10);
            Console.WriteLine($"Nombre total de boites crées : {Boite.NbBoites}");

            //Etiquetage d'une boite sans classe client
            //maBoite.Etiqueter("Flo, 19, rue des fleurs, - 83000 Toulon", 456789, true);
            //if (maBoite.EtiquetteColis != null) {
            //    Console.WriteLine($"""
            //        Colis N° : {maBoite.EtiquetteColis.NumeroColis}
            //        Destinataire : {maBoite.Destinataire}
            //        {(maBoite.Fragile ? "Fragile" : "Non fragile")}
            //        """);
            //}


            //2.Affiche volume et matiere de la boite
            Console.WriteLine($"Le volume de la boite est de {maBoite.Volume} cm3");
            Console.WriteLine($"La matiere de la boite est en {maBoite.Matiere}");
            Console.WriteLine("________________________");
            Console.WriteLine();

            Boite maBoite1 = new Boite(10, 10, 10, Matieres.Plastique);
            Console.WriteLine($"Nombre total de boites crées : {Boite.NbBoites}");
            Console.WriteLine($"Le volume de la boite est de {maBoite1.Volume} cm3");
            Console.WriteLine($"La matiere de la boite est en {maBoite1.Matiere}");
            Console.WriteLine("________________________");
            Console.WriteLine();
            Boite maBoite2 = new Boite(25, 30, 10, Matieres.Carton);
            Console.WriteLine($"Nombre total de boites crées : {Boite.NbBoites}");
            Console.WriteLine($"Le volume de la boite est de {maBoite2.Volume} cm3");

            Boite.Comparer(maBoite1, maBoite2);
            //comparer les boite
            Console.WriteLine($"Boites identiques: {Boite.Comparer(maBoite1, maBoite2)}");

            Boite maBoite3 = new Boite(25, 30, 10);
            Console.WriteLine($"Boites identiques: {Boite.Comparer(maBoite2, maBoite3)}");
            Console.WriteLine("________________________");

            bool resultat1 = maBoite1.Comparer(maBoite2);
            Console.WriteLine($"La boite 1 est -elle identique à la boite 2 ? {resultat1}");
            bool resultat2 = maBoite2.Comparer(maBoite3);
            Console.WriteLine($"La boite 1 est -elle identique à la boite 2 ? {resultat2}");
            Console.WriteLine("________________________");



            Client nouveauClient = new Client
            {
                NrClient = 1,
                
                Prenom = "Adeline",
                Nom = "Patenne",
                Adresse = "3 rue du Paradis - 13007 Marseille"
            };
            Boite boite1 = new Boite(20, 15, 10, Matieres.Carton);
    
            boite1.Etiqueter(nouveauClient, 123456789, true);







            if (boite1.EtiquetteColis != null)
            {
                Console.WriteLine($"""
                    colis N° : {boite1.EtiquetteColis.NumeroColis}
                    Console.WriteLine($"Destinataire : {nouveauClient.Nom} {nouveauClient.Prenom}
                    {nouveauClient.Adresse}");
                    {(boite1.Fragile ? "Fragile" : "Non Fragile")}
                    """);
            }
            Console.WriteLine($"Nouveau volume de maBoite1 : {maBoite1.Volume} cm3");


            Client nouveauClient1 = new Client
            {
                NrClient = 2,

                Prenom = "Jolyne",
                Nom = "Mangeot",
                Adresse = "18 rue des oiseaux - 13002 Marseille"
            };



            Boite boite2 = new Boite(10, 15, 10, Matieres.Bois);
            Boite myBoite2 = new Boite(25, 30, 10, Matieres.Carton);
            Console.WriteLine($"Nombre total de boites crées : {Boite.NbBoites}");
            Console.WriteLine($"Le volume de la boite est de {maBoite2.Volume} cm3");

            // Modification des dimensions pour atteindre 6000 cm³
            myBoite2.Hauteur = 30;
            myBoite2.Largeur = 20;
            myBoite2.Longueur = 10;

            Console.WriteLine($"Nouveau volume de maBoite2 : {myBoite2.Volume} cm³");

            Article a2 = new Article("Lot de assiettes plates", 6);
            // Ajout d’un article dans maBoite2 (exemple)
            Article a1 = new Article("Lot de assiettes plates", 4000);
            if (myBoite2.TryAddArticle(a1))
            {
                Console.WriteLine("Article bien ajouté !");
            }
            else
            {
                Console.WriteLine("Article non ajouté (pas assez d’espace)");
            }

            Console.WriteLine("Description mise à jour de maBoite2 :");
            Console.WriteLine(myBoite2.Description);
            Console.WriteLine("________________________");


            boite2.Etiqueter(nouveauClient1, 123567, true);


            Boite Boite2 = new Boite(25, 30, 10, Matieres.Carton);


            // 🔧 Modification des dimensions pour atteindre 6000 cm³
            myBoite2.Hauteur = 30;
            myBoite2.Largeur = 20;
            myBoite2.Longueur = 10; // 20×20×15 = 6000

            Console.WriteLine($"µ****Nouveau volume de maBoite2 : {maBoite2.Volume} cm³******");

            if (boite2.EtiquetteColis != null)
            {
                Console.WriteLine($"""
                    colis N° : {boite2.EtiquetteColis.NumeroColis}
                    Console.WriteLine($"Destinataire : {nouveauClient1.Nom} {nouveauClient1.Prenom}
                    {nouveauClient1.Adresse}");
                    {(boite2.Fragile ? "Fragile" : "Non Fragile")}
                    """);
            }

            
            Console.WriteLine("-----------------------------------------");
           


            if (boite1.TryAddArticle(a2))
            {
                Console.WriteLine("Article bien ajouté :" );
            }else
            {
                Console.WriteLine("Article non ajouté");
            }
            Console.WriteLine(maBoite2.Description);

            if (boite2.EtiquetteColis != null)
            {
                Console.WriteLine($"""
                    colis N° : {boite2.EtiquetteColis.NumeroColis}
                    Console.WriteLine($"Destinataire : {nouveauClient1.Nom} {nouveauClient1.Prenom}
                    {nouveauClient1.Adresse}");
                    {(boite2.Fragile ? "Fragile" : "Non Fragile")}
                    """);
            }
            Console.WriteLine("Description boîte modifiée:");
            Console.WriteLine(myBoite2.Description);

            Console.WriteLine("\nAppuyer sur une touche pour continuer ...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("####Nouveaux Articles######");



            Article a3 = new Article("un ordinateur", 500);

            if (maBoite2.TryAddArticle(a3))
                Console.WriteLine("Article 1 ajouté");
            else
                Console.WriteLine("Article 1 non ajouté");
            Console.WriteLine(maBoite2.Description);


            Article a4 = new Article("un rétroprojecteur", 1000);

            if (maBoite2.TryAddArticle(a4))
                Console.WriteLine("Article 2 ajouté");
            else
                Console.WriteLine("Article 2 non ajouté");
            Console.WriteLine(maBoite2.Description);


            Article a5 = new Article("Un canapé convertible", 2000);
            if (maBoite2.TryAddArticle(a5))
                Console.WriteLine("Article 3 ajouté");
            else
                Console.WriteLine("Article 3 non ajouté");


            Console.WriteLine("------Nouvelle --boite------");
            Console.WriteLine(maBoite2.Description);


            Console.WriteLine("\nAppuyer sur une touche pour exercice suivant ...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("------Exercice 3------");
            Boite boite3 = new Boite(10, 10, 10);
            Boite boite4 = new Boite(20, 20, 20);

            //creation d'articles
            Console.WriteLine();
            Article a7 = new Article ("Livre", 50);
            Article a8 = new Article ("Stylo", 150); ;
            Article a9 = new Article ("Lampe", 20);
            Article a10 = new Article ("Bureau", 200);

            //Ajoute dans boite 3
            boite3.TryAddArticle(a7);
            boite3.TryAddArticle(a8);
            boite3.TryAddArticle(a9);
            boite3.TryAddArticle(a10);
            Console.WriteLine("Contenu initial des boites :");
            Console.WriteLine(boite3.Description);
            Console.WriteLine(boite4.Description);

            //transfert vers boite 4
            Console.WriteLine();
            Console.WriteLine("Transfert en cours");

            int Transfert = boite3.TransfererVers(boite4);

            Console.WriteLine($"Nombre d'aticles transferes : {Transfert}");
            Console.WriteLine();

            Console.WriteLine("Contenu après transfer :");
            Console.WriteLine("boite 3 :");
            Console.WriteLine(boite3.Description);
            Console.WriteLine("boite 4 :");
            Console.WriteLine(boite4.Description);


















            //Etiquette e1 = new Etiquette
            //{
            //    NumeroColis = 1235,
            //    Client = "Melle Adeline Patenne,\n7, rue de La Plateforme,\n13007 Marseille",
            //    Couleur = Couleurs.Vert,
            //    Format = Formats.M
            //};



            Console.WriteLine("________________________");
            //Console.WriteLine($"Etiquette marquée {e1.Client} de couleur {e1.Couleur} et " +
            //    $"de format {e1.Format}");




            Console.WriteLine();
            //3.appeler sa methode Etiqueter
            //maBoite.Etiqueter("Adeline Patenne", true,123456);
            //maBoite1.Etiqueter("Anya Spy X Family", false,123456);
            //Console.WriteLine();

            //4.afficher si contenu fragile ou pas
            //Console.WriteLine($"Destinataire : {maBoite.EtiquetteColis}");
            //Console.WriteLine($"Contenu fragile : {(maBoite.Fragile ? "Oui" : "Non")}");
            //Console.WriteLine($"Boîte destinée à {maBoite.EtiquetteColis}, " +
            //    $"contenu {(maBoite.Fragile ? "fragile" : "non fragile")}");
            //Console.WriteLine();

            //Console.WriteLine($"Destinataire : {maBoite1.EtiquetteColis}");
            //Console.WriteLine($"Contenu fragile : {(maBoite1.Fragile ? "Oui" : "Non")}");
            //Console.WriteLine($"Boîte destinée à {maBoite1.EtiquetteColis}, " +
            //    $"contenu {(maBoite.Fragile ? "fragile" : "non fragile")}");
            //Console.WriteLine();


            //Console.WriteLine($"Destinataire : {maBoite2.EtiquetteColis}");
            //Console.WriteLine($"Contenu fragile : {(maBoite2.Fragile ? "Oui" : "Non")}");
            //Console.WriteLine($"Boîte destinée à {maBoite2.EtiquetteColis}, " +
            //    $"contenu {(maBoite.Fragile ? "fragile" : "non fragile")}");
            //Console.WriteLine();


            //appeler la methode d 'instance
            //Console.WriteLine($"Boites identiques avec methode instance : {maBoite1.Comparer(maBoite2)}");

           





        }
    }
}
