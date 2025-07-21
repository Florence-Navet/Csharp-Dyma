namespace SaisieAutomatisée
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saisie d'un client\n");
            Console.WriteLine();
            Client client = new Client();
            client.SaisirValeursPropriétés();
            Console.WriteLine($"\nCompte crée : {client.Nom}, {client.Prenom}, {client.DateNais:d}");

        }
    }
}
