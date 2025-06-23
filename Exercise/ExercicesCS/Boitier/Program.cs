namespace Boitier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Job sur les Boites");
            //1.instancier une boite
            Boite maBoite = new Boite();

            //2.Affiche volume et matiere de la boite
            Console.WriteLine($"Le volume de la boite est de {maBoite.Volume} cm3");
            Console.WriteLine($"La matiere de la boite est en {maBoite.Matiere}");



            //3.appeler sa methode Etiqueter
            maBoite.Etiqueter("Adeline Patenne", true);

            //4.afficher si contenu fragile ou pas
            Console.WriteLine($"Destinataire : {maBoite.Destinataire}");
            Console.WriteLine($"Contenu fragile : {(maBoite.Fragile ? "Oui" : "Non")}");
        }
    }
}
