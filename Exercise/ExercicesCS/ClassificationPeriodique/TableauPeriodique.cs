using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassificationPeriodique
{
    public static class TableauPeriodique
    {
        public static readonly string NomFichierTxt = "TableauPeriodique.txt";
        public static readonly Dictionary<int, Famille> Familles = new();
        public static readonly Dictionary<char, Etat> Etats = new();
        public static readonly Dictionary<short, Element> Elements = new();




        #region Partie 1
        public static void ChargerFichierTxt()
        {
            string[] lignes = File.ReadAllLines(NomFichierTxt);

            //charge les familles <12 car on enlève l'entete

            for (short i = 1; i < 12; i++)
            {
                Famille famille = new Famille
                {
                    Id = short.Parse(lignes[i][0..2]),
                    Nom = lignes[i][3..]
                };

                Familles.Add(famille.Id, famille);

            }

            //charge les Etats
            for (short i = 14; i < 18; i++)
            {
                Etat état = new Etat
                {
                    Code = lignes[i][0],
                    Nom = lignes[i][2..]
                };
                Etats.Add(état.Code, état);
            }

            //charge les Elements

            for (int i = 20; i < lignes.Length; i++)
            {
                Element élément = new Element
                {
                    Période = short.Parse(lignes[i][0..1]),
                    NumAtomique = short.Parse(lignes[i][2..5]),
                    Symbole = lignes[i][6..8],
                    CodeEtat = lignes[i][9],
                    NumFamille = short.Parse(lignes[i][11..13]),
                    Nom = lignes[i][14..]
                };

                Elements.Add(élément.NumAtomique, élément);
            }
        }


        public static string GetDetailElement (short numero) 
        {

            Element élément = Elements[numero];
   
     





            string detail = $"""
                Numero atomique : {élément.NumAtomique}
                Symbole  :{élément.Symbole}
                Nom : {élément.Nom}
                Période : {élément.Période}
                Famille : {Familles[élément.NumFamille].Nom}
                Etat naturel : {Etats[élément.CodeEtat].Nom}

                """;

            return detail;
         
        }
        //afiche les detail en couleurs
        public static void AfficherDetailElement(short numero)
        {
            Element élément = Elements[numero];
            ConsoleColor couleur = GetCouleurEtat(élément.CodeEtat);

            Console.ForegroundColor = couleur;
            Console.WriteLine(GetDetailElement(numero));
            Console.ResetColor();
        }



        //blanc pour solide, bleu pour liquide, rouge pour gazeux - 34 -35 -36 -et 109
        public static ConsoleColor GetCouleurEtat(char etat)
        {
            switch (char.ToUpper(etat))
            {
                case 'S': return ConsoleColor.White;
                case 'L': return ConsoleColor.Blue;
                case 'G': return ConsoleColor.Red;
                default: return ConsoleColor.DarkGray;
            }

        }


        public static void AfficherElementColoré(short numero)
        {
            Element élément = Elements[numero];
            ConsoleColor couleur = GetCouleurEtat(élément.CodeEtat);

            Console.ForegroundColor = couleur;

            Console.WriteLine(GetDetailElement(numero));

            Console.ResetColor(); // remet la couleur par défaut
        }

        public static void AfficherElementAvecCouleur(short numero)
        {
            if (!Elements.ContainsKey(numero))
            {
                Console.WriteLine("❌ Élément introuvable.");
                return;
            }

            Element élément = Elements[numero];
            ConsoleColor couleur = GetCouleurEtat(élément.CodeEtat);

            Console.ForegroundColor = couleur;

            Console.WriteLine(GetDetailElement(numero));

            Console.ResetColor();
        }






        #endregion


    }

}


 


