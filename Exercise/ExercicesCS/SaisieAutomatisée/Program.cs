namespace SaisieAutomatisée
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Saisie d'un client\n");
            Console.WriteLine();
            Client client = new Client();
            client.SaisirValeursPropriétés();

            /*methode statique, et methode generique donc paramètre entre chevron mais on peut aussi ne pas le mettre*/
            Input.SaisirValeursPropriétés<Client>(client);
            Console.WriteLine($"\nCompte crée : {client.Nom}, {client.Prenom}, {client.DateNais:d}");

        }
    }
}
