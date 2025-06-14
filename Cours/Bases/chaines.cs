using System;
using System.Globalization;
using System.Text;

namespace Chaines
{
    internal class ChaineCaracteres
    {
        public void AfficherChaines()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string s1 = "abc"; // la plus commune

            string s2 = new string('*', 7); // N fois la  meme chaine

            char[] ar = { 'a', 'b', 'c', };
            
            string s3 = new string(ar);

            Console.WriteLine("------------------------------");
            Console.WriteLine("formatage avec ToSTring");
            decimal prix = 3.5m;
            double temp = 9.8;
            Console.WriteLine(temp.ToString("N1"));
            Console.WriteLine(DateTime.Today.ToString());
            Console.WriteLine(prix.ToString("N3")); //3,500
            Console.WriteLine(prix.ToString("C2"));  // 3,50€
            Console.WriteLine(prix.ToString("C2", CultureInfo.GetCultureInfo("en-US"))); // 3,50$
            Console.WriteLine(prix.ToString("N2", CultureInfo.InvariantCulture)); //
            Console.WriteLine(prix.ToString("C2", CultureInfo.InvariantCulture)); //
            Console.WriteLine();
            long siren = 123456789;
            Console.WriteLine(siren.ToString("000 000 000"));//123 456 789
            Console.WriteLine();
            long siren2 = 12345678;
            Console.WriteLine(siren2.ToString("### ### ###"));//12 345 678
            Console.WriteLine();
            long siren3 = 12345678;
            Console.WriteLine(siren3.ToString("000 000 000"));//012 345 678

            Console.WriteLine();

            double d = 2.4587;
            Console.WriteLine(d.ToString("###.###"));//2.459
            Console.WriteLine(d.ToString("00.0%"));//245.9%

            Console.WriteLine("------------------------------");


            Console.WriteLine();
            Console.WriteLine("Formats de date");

            DateTime date = new DateTime(2030, 07, 14, 13, 58, 35); //14/07/2030 à 13:58:35

            Console.WriteLine(date.ToString("d")); // date courte
            Console.WriteLine(date.ToString("D")); // date longue
            Console.WriteLine(date.ToString("MM/yyyy")); // date longue y, mois année.....
            Console.WriteLine(date.ToString("ddd dd/MMM-yyyy à HH:mm z")); // 2 lettres = nombres - 3 l = text abreges - 4l =  text entier

            Console.WriteLine("------------------------------");


            Console.WriteLine();
            Console.WriteLine("Formatage des duree");
            TimeSpan duree = new TimeSpan(40, 37, 28); // 40h 37min 28s
            Console.WriteLine(duree.ToString());//1:16:37:28
            Console.WriteLine(duree.ToString("G"));//1:16:37:28,0000000
            Console.WriteLine(duree.ToString("g"));//1:16:37:2
            Console.WriteLine(duree.ToString("d'j 'hh'h 'mm'min 'ss's '"));
   





            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine();

            string s4 = "Chemin complet du fichier \"essai\":\n" +
                "c:\\Temp\\essai.txt";

            Console.WriteLine(s4);

            string texte = @"Dans une chaine verbatim :
- les retours à la ligne sont bien interprêtés
- pas besoin d'échapper les caractères spéciaux (ex : C:\Temp\essai.txt)
- mais il faut ""doubler"" les guillemets";

            Console.WriteLine(texte);

            string texte2 = """
                Dans un litteral de chaine brut :
                - pas besoin d'échapper les caractères spéciaux, y compris les "guillemets"
                - on peut indenter la chaine  comme le reste du code
                - mais il faut
                """;

            Console.WriteLine(texte2);

            Console.WriteLine();


            Console.OutputEncoding = new UnicodeEncoding();

            string symboles = "🖫 🖉 🗑 ✓ 🛈 🗙 ⭮ ⭯";
            string flèches = "⏶ ⏷ ⏴ ⏵";

            Console.WriteLine(symboles);
            Console.WriteLine(flèches);


            Console.OutputEncoding = new UnicodeEncoding();

            string symboles2 = "\u2713 \u2B6E \u2B6F";
            Console.WriteLine(symboles2);


            Console.WriteLine();
        }
    }
}