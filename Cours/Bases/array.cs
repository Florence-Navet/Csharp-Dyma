using System;

namespace Array
{
    internal class Scores
    {
        public void AfficherScores()
        {
            byte?[] scoresJ1 = new byte?[5];
            byte?[] scoresJ2 = { 6, 3, 5, 6, 7 };

            scoresJ1[0] = 6;
            scoresJ1[1] = 3;
            scoresJ1[2] = 5;
            scoresJ1[3] = 7;
            scoresJ1[4] = 6;

            scoresJ2[0] = 9;

            Console.WriteLine(scoresJ2.Length); // 5

            string[] courses = { "chou", "carotte", "viande" };
            string phrase = "J'aime ma chouquette";
            char car = phrase[2];
            Console.WriteLine($"Le 3e caract�re est : {car}");

            byte?[,] scores = new byte?[2, 5];

            scores[0, 0] = 6;
            scores[1, 0] = 2;
            scores[0, 1] = 3;
            scores[1, 1] = 6;
            scores[0, 2] = 5;
            scores[1, 2] = 7;

            byte?[,] scores2 = {
                { 6, 2 },
                { 3, 6 },
                { 5, 7 },
                { 6, 3 },
                { 7, 5 }
            };
        }
    }
}
