//chaines interpolees

Console.WriteLine("Bonjour ! Comment t'appelles-tu ?");

//pour recup�rer donn�es utilisateur
string? rep = Console.ReadLine();

Console.WriteLine("Bonjour " + rep + "!");


Console.WriteLine("Quelle est ton ann�e de naissance ?");


string repAnn = Console.ReadLine();

int anneeNais = int.Parse(repAnn);


int age = DateTime.Today.Year - anneeNais;


Console.WriteLine($"{rep},tu vas avoir {age} ans en {DateTime.Today.Year}.");

//if (age <= 25)
//{
//    Console.WriteLine("Tu as moins de 25 ans");
//}
//else
//{
//    Console.WriteLine("Tu as plus de 25 ans");
//}









