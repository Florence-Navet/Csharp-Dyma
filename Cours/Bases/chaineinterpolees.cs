using System;
using System.Globalization;

namespace ChaineInterpolees
{
    internal class DateAge
    {
        public void AfficherAge()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //chaines interpolees

            Console.WriteLine("Bonjour ! Comment t'appelles-tu ?");

            //pour recupérer données utilisateur
            string? rep = Console.ReadLine();

            Console.WriteLine("Bonjour " + rep + "!");


            Console.WriteLine("Quel est ton ann�e de naissance ?");


            string repAnn = Console.ReadLine();

            int anneeNais = int.Parse(repAnn);

            //int age = 2024 - anneeNais;

            int age = DateTime.Today.Year - anneeNais;

            Console.WriteLine(anneeNais);

            Console.WriteLine("Tu vas avoir " + age + " ans.");

            Console.WriteLine($"{rep},tu vas avoir {age} ans en {DateTime.Today.Year}.");

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("chaînes interpolées ");
            string nom = "Tristan";
            decimal somme = 1300000;
            DateTime date = new DateTime(2025, 6, 14);
            Console.WriteLine($"""
                {nom} a gagne {somme}€ au loto le {date}.
                """);
            string s = $"""
                {nom, 15} a gagne {somme:C0} au loto le {date:D}.
                """;
            Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("chaînes de formats composites ");
            string res1 = string.Format(CultureInfo.GetCultureInfo("en-US"),
                "{0, -15} a gagné {1:CO} au loto le {2:D}", nom, somme, date);
            string res = string.Format("{0} a gagné {1:CO} au loto le {2:D}", nom, somme, date);
            Console.WriteLine(res);
            Console.WriteLine(res1);

            String produit = "chocolat";
            int quantite = 2;
            decimal PU = 2.15m;

            Console.WriteLine();


            string s2 = $"""
            Produit         | Qté |      PU   |
            -----------------------------------
            {produit,-16} | {quantite,3} | {PU,8:C2} |
            """;
            Console.WriteLine(s2);




        }
    }
}





