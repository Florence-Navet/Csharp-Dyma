using System;
using System.Collections.Generic;

namespace ModelesDeDocuments
{
    internal class Document
    {
        #region Données et constructeur statiques

        // Liste statique de modèles de documents
        private static readonly List<Document> Modeles;

        static Document()
        {
            Modeles = new List<Document>();

            Modeles.Add(new Document
            {
                Titre = "Modèle A",
                DateCreation = new DateTime(2023, 1, 1),
                Marges = (2.5, 2.5, 1.5, 1.5)
            });

            Modeles.Add(new Document
            {
                Titre = "Modèle B",
                DateCreation = new DateTime(2023, 6, 30),
                Marges = (2, 2, 1, 1)
            });
        }

        #endregion

        #region Propriétés

        public string Titre { get; set; } = string.Empty;
        public Personne? Auteur { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public (double Haut, double Bas, double Gauche, double Droite) Marges { get; set; }

        public string PiedDePage =>
            $"{Auteur?.Prenom} {Auteur?.Nom ?? "Société XYZ"} - {Titre} - créé le {DateCreation:d}";

        #endregion

        #region Methodes publiques

        //public static Document? CreerDepuisModele(string TitreModele, Personne? Auteur = null)
        //{
        //    foreach (var modele in Modeles)
        //    {
        //        if (modele.Titre == TitreModele)
        //        {
        //            // Création d’un nouveau document basé sur le modèle trouvé
        //            Document nouveau = new Document
        //            {
        //                Titre = modele.Titre,         // même titre que le modèle
        //                Marges = modele.Marges,       // mêmes marges
        //                Auteur = Auteur,              // auteur reçu en paramètre
        //                DateCreation = DateTime.Now   // date actuelle
        //            };

        //            return nouveau;
        //        }
        //    }

        //    // Aucun modèle trouvé correspondant au titre
        //    return null;
        //}
        public static Document? CreerDepuisModele(string TitreModele, Personne? auteur = null)
        {
            Document? doc = null;

            //Recherche le modele ayant le titre souhaité
            Document? modele = Modeles.Find(n => n.Titre.ToLower() == TitreModele.ToLower());

            //si on a trouvé un moèle, on crée un doc avec les mêmes titre et marge
            if (modele != null)
            {
                doc = new Document
                {
                    Titre = modele.Titre,
                    Auteur = auteur,
                    Marges = modele.Marges,

                };
            }
            return doc;
        }
        #endregion
    }
}