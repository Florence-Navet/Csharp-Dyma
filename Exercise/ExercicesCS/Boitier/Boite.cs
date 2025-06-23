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
        //juste en lecteur donc juste le get

        public double Hauteur { get; } = 30.0;
        public double Largeur { get; } = 30.0;
        public double Longueur { get; } = 30.0;

        //propriété Volume en lecture qui retourne le volume
        public double Volume => Hauteur * Largeur;
        // Champ privé associé à la propriété en lecture seule
        private string _destinataire = string.Empty;

      

        //Propriete en lecture seule initialisé à carton
        public Matieres Matiere { get; } = Matieres.Carton;

        //Créer une propriete Destinaire de type string en lecture seule
        public string Destinataire { get; private set; } = string.Empty;
        //créer une propriete fragile en lecture seule
        public bool Fragile { get; private set; }


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


        //créer ensuite une surchage permettant d'affectant
        //les valeurs des proprietes Destinataires et Fragile




    }
      



    }

