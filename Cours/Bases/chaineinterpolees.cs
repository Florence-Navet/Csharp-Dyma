//chaines interpolees

//Console.WriteLine("Bonjour ! Comment t'appelles-tu ?");

//pour recupérer données utilisateur
string? rep = Console.ReadLine();

Console.WriteLine("Bonjour " + rep + "!");


//Console.WriteLine("Quel est ton année de naissance ?");


string repAnn = Console.ReadLine();

int anneeNais = int.Parse(repAnn);

int age = 2024 - anneeNais;

int age = DateTime.Today.Year - anneeNais;

Console.WriteLine(anneeNais);

Console.WriteLine("Tu vas avoir " + age + " ans.");

Console.WriteLine($"{rep},tu vas avoir {age} ans en {DateTime.Today.Year}.");







