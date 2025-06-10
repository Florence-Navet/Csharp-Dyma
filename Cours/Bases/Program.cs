namespace Fonctions
{
    internal class Program
    {
        static void Main(string[] args)


        {
            int nbMots = OutilsTexte.CompterMots("J'aime ma chouqette !!");

            //double[] tabNombres = { 4.21, 5.54, 2.13, 3.47 };
            double max = OutilsMaths.GetValeurMaxi(4.21, 5.54, 2.13, 3.47, 4.58, 59);
            Console.WriteLine($"Valeur maxi : {max}");

            string traduction = OutilsTexte.Traduire("Je suis seule à l'école.");
        }
    }
}
