namespace Boitier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Job sur les Boites");
            //1.instancier une boite
            Boite maBoite = new Boite(15,12,10);
            Console.WriteLine($"Nombre total de boites crées : {Boite.NbBoites}");


            //2.Affiche volume et matiere de la boite
            Console.WriteLine($"Le volume de la boite est de {maBoite.Volume} cm3");
            Console.WriteLine($"La matiere de la boite est en {maBoite.Matiere}");

            Boite maBoite1 = new Boite(15, 10, 10, Matieres.Plastique);
            Console.WriteLine($"Nombre total de boites crées : {Boite.NbBoites}");
            Console.WriteLine($"Le volume de la boite est de {maBoite1.Volume} cm3");
            Console.WriteLine($"La matiere de la boite est en {maBoite1.Matiere}");

            Boite maBoite2 = new Boite(10, 18, 20);
            Console.WriteLine($"Nombre total de boites crées : {Boite.NbBoites}");
            Console.WriteLine($"Le volume de la boite est de {maBoite2.Volume} cm3");
           





            //3.appeler sa methode Etiqueter
            maBoite.Etiqueter("Adeline Patenne", true);
            maBoite1.Etiqueter("Anya Spy X Family", false);

            //4.afficher si contenu fragile ou pas
            Console.WriteLine($"Destinataire : {maBoite.Destinataire}");
            Console.WriteLine($"Contenu fragile : {(maBoite.Fragile ? "Oui" : "Non")}");
            Console.WriteLine($"Boîte destinée à {maBoite.Destinataire}, " +
                $"contenu {(maBoite.Fragile ? "fragile" : "non fragile")}");
           

            Console.WriteLine($"Destinataire : {maBoite1.Destinataire}");
            Console.WriteLine($"Contenu fragile : {(maBoite1.Fragile ? "Oui" : "Non")}");
            Console.WriteLine($"Boîte destinée à {maBoite1.Destinataire}, " +
                $"contenu {(maBoite.Fragile ? "fragile" : "non fragile")}");
            

            Console.WriteLine($"Destinataire : {maBoite2.Destinataire}");
            Console.WriteLine($"Contenu fragile : {(maBoite2.Fragile ? "Oui" : "Non")}");
            Console.WriteLine($"Boîte destinée à {maBoite2.Destinataire}, " +
                $"contenu {(maBoite.Fragile ? "fragile" : "non fragile")}");

            
        }
    }
}
