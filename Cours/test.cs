
namespace Fonctions
{
    internal class OutilsTexte
    {
        public static int CompterMots(string phrase)
        {
            int nbMots = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                //on compte simplement les espaces, apostropes et tab
                if (phrase[i] == ' ' || phrase[i] == '\'' || phrase[i] == '\t')
                    nbMots++;
            }
            return nbMots++;
        }
    }
}