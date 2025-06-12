using System;
using System.Text;

namespace Chaines
{
    internal class ChaineCaracteres
    {
        public void AfficherChaines()
        {
            string s1 = "abc"; // la plus commune

            string s2 = new string('*', 7); // N fois la  meme chaine

            char[] ar = { 'a', 'b', 'c', };
            
            string s3 = new string(ar);

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