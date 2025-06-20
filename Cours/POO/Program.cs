using System.Numerics;
using System.Text;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Instancie un compte bancaire en sépcifiant son numéro
            long numero = 123456; //long numero = 123456~~
            CompteBancaire compte1 = new CompteBancaire(numero);
            // Instancie un compte bancaire et initialise son numéro
            long numero2 = 8456122;
            CompteBancaire compte2 = new CompteBancaire(numero2);


            // Les 2 lignes suivantes provoqueraient des erreurs,
            // car elles tentent d'accéder à des membres qui ne sont pas publics
            //compte1._solde = 1000m;
            //decimal i = compte2.CalculerInterets();


            // Les lignes suivantes sont OK, car elles utilisent des membres publics
            compte2.Libelle = "Compte d'épargne";
            compte2.Crediter(500);
            compte2.Debiter(60);
            decimal solde = compte2.GetSolde();

            // Utilise le compte en appelant ses méthodes publiques
            compte1.Crediter(800m);
            compte1.Debiter(60m);
            decimal solde1 = compte1.GetSolde();

            // Récupère le solde courant via une méthode publique
            Console.WriteLine($"Le solde du compte {numero} est de {solde:C2}");
            Console.WriteLine($"Le solde du compte {numero2} est de {solde1:C2}");
        }
    }
}
