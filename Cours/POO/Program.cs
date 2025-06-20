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

            // Utilise le compte en appelant ses méthodes publiques
            compte1.Crediter(500m);
            compte1.Debiter(60m);
            decimal solde = compte1.GetSolde();

            // Récupère le solde courant via une méthode publique
            Console.WriteLine($"Le solde du compte {numero} est de {solde:C2}");
        }
    }
}
