//iteration

//byte?[] scoresJ1 = new byte?[5];
//byte?[] scoresJ2 = { 6, 3, 5, 6, 7 };

//scoresJ1[0] = 6;
//scoresJ1[1] = 3;
//scoresJ1[2] = 5;
//scoresJ1[3] = 7;
//scoresJ1[4] = 6;



//scoresJ2[0] = 9;


//for (int s = 0; s < scoresJ1.Length; s++)
//{
//    Console.WriteLine($"set {s + 1}: {scoresJ1[s]} - {scoresJ2[s]}.");
//}

//Console.WriteLine("###################################");

/*******************************/
//for (int s = scoresJ1.Length - 1; s >= 0; s--)
//{
//    Console.WriteLine($"set {s + 1}: {scoresJ1[s]} - {scoresJ2[s]}.");
//}

//Console.WriteLine();

/*******************************/

//int premierSetPerdu = 0;



//for (int s = 0; s < scoresJ1.Length; s++)
//{
//    if (scoresJ1[s] < scoresJ2[s])
//    {
//        premierSetPerdu = s + 1;
//        break;
//    }

//}
//Console.WriteLine($"N� du premier set perdu par le joueur 1 : {premierSetPerdu}");
///*******************************/

//Console.WriteLine();

//Console.WriteLine("Sets perdus par le Joueur 1 :");
//for (int s = 0; s < scoresJ1.Length; s++)
//{
//    if (scoresJ1[s] >= scoresJ2[s])
//        continue;


//    Console.WriteLine($"set {s+1}");


//}


/***************foreach****************/

//int nbJeux = 0;

//foreach (byte score in scoresJ1)
//{
//    nbJeux += score;
//}

//Console.WriteLine($"Le premier joueur a remport� {nbJeux}jeux.");

//***************do while**************************
//bool saisieOk = false;



//do
//{
//    Console.WriteLine("Saisissez un chiffre entre 1 et 2 :");
//    string? rep = Console.ReadLine();

//    if (rep == "1" || rep == "2" || rep == "3")
//        saisieOk = true;

//}
//while (!saisieOk);


/**************************************/
//while (!saisieOk)
//{
//    Console.WriteLine("Saisissez un chiffre entre 1 et 2 :");
//    string? rep = Console.ReadLine();
//    if (rep == "1" || rep == "2" || rep == "3")
//        saisieOk = true;
//}


