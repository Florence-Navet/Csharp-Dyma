using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CompteBancaire
    {
        #region Champs privés (invisibles en dehors de la classe) ~~   #region Champs privés (accessibles uniquement à l’intérieur de la classe)~~
        private long _numero;
        private decimal _solde;
        #endregion

        // Contructeur
        public CompteBancaire(long num)
        {
            _numero = num; // Initialise le numéro du compte
        }

        #region Méthodes publiques
        // Crédite le compte du montant spécifié
        public void Crediter(decimal montant)
        {
            _solde += montant;
        }

        // Débite le compte du montant spécifié
        public void Debiter(decimal montant)
        {
            _solde -= montant;
        }

        // Renvoie la valeur du solde courant
        public decimal GetSolde()
        {
            return _solde;
        }
        #endregion
    }
}
