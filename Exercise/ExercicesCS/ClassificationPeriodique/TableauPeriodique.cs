using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
        #region Partie 2

        //charge le contenu du fichier html
        public static void ChargerFichierHtml() 
        {
            string html = File.ReadAllText("TableauPeriodique.html");

            //1. charger les familles
            // <td bgcolor="#F66" align="center">Métaux Alcalins</td>

            /*<td veut j'enlève la ballisde <td
             * cree un groupe nommé couleur : bgcolor="(?<couleur>)
             puis #[A-F0-9]+ pour les couleurs puis
            on enleve le align_center
            [^>] tout sauf
            * repété autant que nécessaire
            > fin de la balise
            (?<nom>...) groupe nomme nom[^<] a la place des points
            [^<]+ tout sauf le texte visible
            </td> reconnaitre la fin de la balise

            */


            string fam= @"<td bgcolor=""(?<couleur>#[A-F0-9]+)""align=""center"">(?<nom>[^<]+)</td>";

            //string fam = "<td bgcolor="(?<couleur>#[A-F0-9]+)"[^>]*>(?<nom>[^<]+)</td>";
            short f = 0;

            foreach (Match match in Regex.Matches(html, fam, RegexOptions.IgnoreCase))
            {
                Famille famille = new Famille
                {
                    Id = ++f,
                    Nom = match.Groups[2].Value,
                    Couleur = match.Groups[1].Value,
                };
            }
            /*regex :
            <span style="color:black">Solide</span>

             */

            // Charge les états

            string eta = @"<span style=""color:(?<couleur>#?[A-Fa-f0-9]+|[a-zA-Z]+)"">(?<nom>[^<]+)</span>";
            foreach (Match match in Regex.Matches(html, eta, RegexOptions.IgnoreCase))
            {
                Etat état = new Etat
                {
                    Code = match.Groups[2].Value[0],
                    Nom = match.Groups[2].Value,
                    Couleur = match.Groups[1].Value
                };

                Etats.Add(état.Code, état);
            }

            //2. charge mes élements
            /*
             <td style="...background-color:#A0FFA0;...">
                1
                    <br><big><b><a href="/wiki/Hydrogène" title="Hydrogène"> H </a></b></big>
                </td>
            */



            string elem = @"<td style="".*background-color:(#\w+);.*;color:(\w+);"">\s*(\d+)\s*<br><big><b><a href=.*\s+title=""(\w+)"">\s*(\w+)\s*</a></b></big>\s*</td>";


            ;

            foreach (Match match in Regex.Matches(html, elem, RegexOptions.IgnoreCase)) 
            {
                Element e = new Element
                {
                    NumFamille = GetCodeFamille(match.Groups[1].Value),
                    CodeEtat = GetCodeEtat(match.Groups[2].Value),
                    NumAtomique = short.Parse(match.Groups[3].Value),
                    Nom = match.Groups[4].Value,
                    Symbole = match.Groups[5].Value

                };
                Elements.Add(e.NumAtomique, e);
            }

        }
        public static char GetCodeEtat(string couleur) => couleur switch
        {
           "black" => 'S',
            "blue" => 'L',
            "red" => 'G',
            _ => '?'
           
              
        };

        public static short GetCodeFamille(string couleurHtml) => couleurHtml.ToUpper() switch
        {
            "#F66"    => 1,  // Métax Alcalins
            "#F6CFA1" => 2,  // Métaux alcalino-terreux
            "#FFBFFF" => 3,  // Lanthanides
            "#FF99CC" => 4,  // Actinides
            "#FFC0C0" => 5,  // Métaux de transition
            "#CCC"    => 6,  // Métaux pauvres
            "#CC9"    => 7,  // Métalloïdes
            "#A0FFA0" => 8,  // Autres non-métaux
            "#FF9"    => 9,  // Halogènes
            "#C0E8FF" => 10, // Gaz nobles
            "#F7F8FF" => 11, // Éléments non classés
            _         => -1  // Couleur inconnue 
        };

        public static void TransformerFichier()
        {
            string html = File.ReadAllText("TableauPeriodique.html");

            //regex pour capturer le style complet et extraire uniquement le background
            /*transformer ça : 
             <td style="text-align:center;line-height:1.4;background-color:#A0FFA0;border:1px solid black;color:black;">
            en 
            ça :
            <td style="background-color:#A0FFA0;">

*/


            string background = @"<td\s+style=""[^""]*background-color:(?<bgcolor>#[A-Fa-f0-9]+)[^""]*""[^>]*>";

            string nouveauHtml = Regex.Replace(html, background, match =>
            {
                string couleur = match.Groups["bgcolor"].Value;
                return $@"<td style=""background-color:{couleur}"">";
            }, 
            
            RegexOptions.IgnoreCase);

            //sauvegarde dans un nouveau fichier

            File.WriteAllText("TableauPeriodique_modifié.html", nouveauHtml);

}

        #endregion


    }

}


 


