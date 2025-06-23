using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boitier
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

        public Boite(double hauteur, double largeur, double longueur)
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
        public double Largeur { get; } = 30.0;
        public double Longueur { get; } = 30.0;

        public static int NbBoites { get; private set; }


        public Matieres Matiere { get; } = Matieres.Carton;
     

        //propriété Volume en lecture qui retourne le volume
        public double Volume => Hauteur * Largeur;
        // Champ privé associé à la propriété en lecture seule
        private string _destinataire = string.Empty;


        //Créer une propriete Destinaire de type string en lecture seule
        public string Destinataire { get; private set; } = string.Empty;
        //créer une propriete fragile en lecture seule
        public bool Fragile { get; private set; }

        #endregion


        #region Methodes publiques

        //Créer une methode publique Etiqueter permettant
        //d'affecter la valeur de la propriete Destinataire
        public void Etiqueter(string dest)
        {
           Destinataire = dest;
        }
        public void Etiqueter(string dest, bool f)
        {
            Etiqueter(dest);
            Fragile = f;
        }

        #endregion


    }
      



    }

