using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Boites
{
    public enum Matieres
    {
        Carton,
        Plastique,
        Bois,
        Metal
    }
    internal class Boite

    {

        #region Champs et propriétés statiques



        // Propriété statique en lecture seule
        //public static int NbBoites => _nbBoites;

        #endregion


        #region Constructeurs

        public Boite (double hauteur, double largeur, double longueur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Longueur = longueur;
            NbBoites++;
        }

        public Boite(double hauteur, double largeur, double longueur, Matieres matiere) :
            this(hauteur, largeur, longueur)
        {
            Matiere = matiere;
        }
        #endregion

        #region Proprietes


        //juste en lecteur donc juste le get

        public double Hauteur { get; set; } = 30.0;
        public double Largeur { get; set; } = 30.0;
        public double Longueur { get; set; } = 30.0;

        public static int NbBoites { get; private set; }

        private readonly List<Article> _articles = new(); // liste interne
        public IReadOnlyList<Article> articles => _articles.AsReadOnly(); // lecture seule externe

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Boite  de volume de {Volume} en {Matiere} contenant :");
                if (_articles.Count == 0)
                {
                    sb.AppendLine(" - Aucun article n'est trouvé.");
                }
                else
                {
                    foreach (var article in _articles)
                    {
                        sb.AppendLine($"- Lot de : {article.Libelle}");
                    }
                }
                return sb.ToString();
            }

        }



        public Matieres Matiere { get; } = Matieres.Carton;


        //propriété Volume en lecture qui retourne le volume
        public double Volume => Hauteur * Largeur * Longueur ;
        // Champ privé associé à la propriété en lecture seule
        private string destinataire;


        //Créer une propriete Destinaire de type string en lecture seule
        public Etiquette? EtiquetteColis { get; private set; }//juste c
        //créer une propriete fragile en lecture seule
        public bool Fragile { get; private set; }

        #endregion


        #region Methodes publiques

        //Créer une methode publique Etiqueter permettant
        //d'affecter la valeur de la propriete Destinataire
        //public void Etiqueter(Client client, long NumeroColis)
        //{
        //    EtiquetteColis = new Etiquette {
        //        NumeroColis = NumeroColis,
        //        Client = $"{client.Nom},{client.Prenom},  {client.Adresse}",

        //        Couleur = Couleurs.Blanc,
        //        Format = Formats.XL

        //    };
        //}
        #endregion
        #region Méthodes publiques
        public void Etiqueter(Client dest, long numColis)
        {
            EtiquetteColis = new Etiquette
            {
                Destinataire = dest,
                NumeroColis = numColis,
                Couleur = Couleurs.Blanc,
                Format = Formats.XL
            };
        }

        //public void Etiqueter(Client client, bool f, long NumeroColis)
        //{
        //    Etiqueter(client, NumeroColis);
        //        Fragile = f;
        //}
        public void Etiqueter(Client dest, long numColis, bool f)
        {
            Etiqueter(dest, numColis);
            Fragile = f;
        }

        //public void Comparer(Boite boite1, Boite boite2)
        //{
        //    if (boite1.Hauteur == boite2.Hauteur &&
        //        boite1.Largeur == boite2.Largeur &&
        //        boite1.Longueur == boite2.Longueur)
        //    {
        //        Console.WriteLine($" Les deux boites sont de meme dimansions.");
        //        return;
        //    } else
        //    {
        //        Console.WriteLine($"Les dimensions de la boîte sont : {boite1.Volume} cm³, " +
        //            $"{boite1.Largeur} cm, {boite1.Hauteur} cm, {boite1.Longueur} cm");



        //        Console.WriteLine($"Les dimension de la boite 1 sont {boite2.Volume} cm3" +  
        //           $"{boite2.Largeur} cm, {boite2.Hauteur}cm, {boite2.Longueur}cm.");
        //    }
        //}

        public static bool Comparer(Boite boite1, Boite boite2)
        {
            return (boite1.Hauteur == boite2.Hauteur &&
                boite1.Largeur == boite2.Largeur &&
                boite1.Longueur == boite2.Longueur &&
                boite1.Matiere == boite2.Matiere);

        }
        //public bool Comparer(Boite autreBoite)
        //{
        //    return this.Hauteur == autreBoite.Hauteur &&
        //        this.Largeur == autreBoite.Largeur &&
        //        this.Longueur == autreBoite.Longueur &&
        //        this.Matiere == autreBoite.Matiere;

        //}
        //public bool Comparer(Boite boite1)
        //{
        //    return (boite1.Hauteur == Hauteur &&
        //        boite1.Largeur == Largeur &&
        //        boite1.Longueur == Longueur &&
        //        boite1.Matiere == Matiere);
        //}

        public bool Comparer(Boite boite1)
        {
            return Comparer(boite1, this);
        }


        public bool TryAddArticle(Article article)
        {
            double volumeDisponible = Volume;
            double volumeArticles = _articles.Sum(a => a.Volume);

            // ✅ ici, on utilise l'objet passé en paramètre
            if (volumeArticles + article.Volume <= volumeDisponible)
            {
                _articles.Add(article);
                return true;
            }

            return false;
        }



    }

    #endregion


}





