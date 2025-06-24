using System;
using System.Globalization;

namespace Boites
{
    internal class Program
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
            boite1.Etiqueter(nouveauClient, 123456789, false);

            if (boite1.EtiquetteColis != null)
            {
                Console.WriteLine($"""
                    colis N° : {boite1.EtiquetteColis.NumeroColis}
                    Destinataire : {nouveauClient.Nom}\n{nouveauClient.Prenom}\n {nouveauClient.Adresse}
                    {(boite1.Fragile ? "Fragile" : "Non Fragile")}
                    """);
            }



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
