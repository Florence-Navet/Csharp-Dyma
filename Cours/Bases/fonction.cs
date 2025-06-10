using System;

namespace Fonctions
{
    internal class OutilsTexte
    {
        public static int CompterMots(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return 0;

            int nbMots = 0;
            bool estDansUnMot = false;

            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == ' ' || phrase[i] == '\'' || phrase[i] == '\t')
                {
                    if (estDansUnMot)
                    {
                        nbMots++;
                        estDansUnMot = false;
                        Console.WriteLine($"Nombre de mots : {nbMots}");

                    }
                }
                else
                {
                    estDansUnMot = true;
                }
            }

            if (estDansUnMot)
                nbMots++;

            return nbMots;
        }

        public static string Traduire(string texte, string Langue = "EN")
        {
            return string.Empty;
        }
    }
}
