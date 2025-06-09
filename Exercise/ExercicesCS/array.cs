byte?[] pays = {"Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Biélorussie",
    "Bosnie-Herzgovine", "Bulgarie", "Chypre", "Croatie"};

byte?[] capitale = {"Tirana", "Berlin", "Andorre-La-Vieille", "Vienne",
    "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb"};



for (for p = 0; p < pays.Length; p++)
{
        Console.WriteLine($"Quelle est la capitale de {pays}?");
        string repPays = Console.ReadLine();

        if (pays[i] == capitale[int])
        {
            Console.WriteLine($"Bravo ! Tu as donné la bonne réponse ! {repPays} est bien la capitable de {pays}");
        } else
        {
            Console.WriteLine($"Mauvaise réponse !! La réponse était : {capitale}!!");
        }

}


