namespace QuizzCapitale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string?[] pays = {"Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Biélorussie",
    "Bosnie-Herzgovine", "Bulgarie", "Chypre", "Croatie"};
            string?[] capitale = {"Tirana", "Berlin", "Andorre-La-Vieille", "Vienne",
    "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb"};

            bool rejouer = true;

            while (rejouer)
            {
                int bonRep = 0;



                for (int p = 0; p < pays.Length; p++)
                {
                    Console.WriteLine($"\nQuelle est la capitale de {pays[p]}?");
                    string repPays = Console.ReadLine();

                    if (repPays.Equals(capitale[p], StringComparison.OrdinalIgnoreCase))

                    {
                        bonRep++;
                        Console.WriteLine($"Bravo ! Tu as donné la bonne réponse ! {repPays} est bien la capitable de {pays[p]}");
                        
                        
                    }
                    else
                    {
                        Console.WriteLine($"Mauvaise r�ponse !! La réponse était : {capitale[p]}!!");
                    }
                    

                }
                Console.WriteLine($"Vous avez {bonRep} bonnes réponses.");
                ;
                Console.WriteLine("Veux-tu rejouer ? (o/O pour oui, autre touche pour non)");
                string reponse = Console.ReadLine();

                if (reponse.ToLower() == "o")
                {
                    Console.Clear();
                }
                else
                {
                    rejouer = false;
                    Console.WriteLine("Merci d'avoir joué ! A bientôt");
                }



            }







        }
    }
}
