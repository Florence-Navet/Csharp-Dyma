//string?[] pays = {"Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Bi�lorussie",
//    "Bosnie-Herzgovine", "Bulgarie", "Chypre", "Croatie"};
//string?[] capitale = {"Tirana", "Berlin", "Andorre-La-Vieille", "Vienne",
//    "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb"};

//bool rejouer = true;

//while (rejouer)
//{
//    int boolCount = 0;



//    for (int p = 0; p < pays.Length; p++)
//    {
//        Console.WriteLine($"Quelle est la capitale de {pays[p]}?");
//        string repPays = Console.ReadLine();

//        if (repPays.Equals(capitale[p], StringComparison.OrdinalIgnoreCase))

//        {
//            Console.WriteLine($"Bravo ! Tu as donn� la bonne r�ponse ! {repPays} est bien la capitable de {pays[p]}");
//            boolCount++;
//            Console.WriteLine($"Vous avez {boolCount} bonnes r�ponses.");
//        }
//        else
//        {
//            Console.WriteLine($"Mauvaise r�ponse !! La r�ponse �tait : {capitale[p]}!!");
//        }

//    }
//    ;
//    Console.WriteLine("Veux-tu rejouer ? (o/O pour oui, autre touche pour non)");
//    string reponse = Console.ReadLine();

//    if (reponse.ToLower() == "o")
//    {
//        Console.Clear(); 
//    }
//    else
//    {
//        rejouer = false; 
//        Console.WriteLine("Merci d'avoir jou� ! A bient�t");
//    }



//}






