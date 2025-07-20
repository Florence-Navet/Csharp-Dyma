namespace ClassesEtendues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======CLASSES ETENDUES=======");

            // dt0 = new DateTime(2001, 04, 15);
            //DateTime dt0 = new DateTime(2025, 07, 20);
            DateTime dt0 = new DateTime(2000, 12, 25);

            Console.WriteLine($"Date de départ :  {dt0:D}");
            Console.WriteLine($"Premier jour du mois :  {dt0.GetBeginnigOfTheMonth():D}");
            Console.WriteLine($"Dernier jour du mois :  {dt0.GetEndOfTheMonth():D}");
            Console.WriteLine();
            Console.WriteLine($"Nombre d'années entières entre la date de départ le {dt0:D}" +
                $" et le {DateTime.Today:d} : {dt0.GetAge()}");
            Console.WriteLine();
            Console.WriteLine($"Départ : {dt0:dddd dd MMM yyyy}");
            Console.WriteLine($"+ 5 jours ouvrés : {dt0.AddWorkedDays(5):dddd dd MMMM yyyy}");

            Console.WriteLine();

            foreach (Status stat in Enum.GetValues(typeof(Status)))
            {
                Console.WriteLine(stat.ToDisplayString());
            }
            

         




        }
    }
}
