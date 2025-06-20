using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CompteBancaire
    {
        #region Champs privés (invisibles en dehors de la classe) ~~   #region Champs privés (accessibles uniquement à l’intérieur de la classe)~~
        private readonly long _numero;
        private decimal _solde;
        private const decimal TAUX_AGIOS = 0.15m;
        public static readonly decimal TAUX_INTERET = 0.2m; //mieux pour les public
        #endregion

        #region Champs publics (accessibles de partout)
        public string Libelle;
        #endregion

        // Contructeur
        public CompteBancaire(long num)
        {
            _numero = num; // Initialise le numéro du compte
            Libelle = "Compte N°" + num;

           
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
            if (_solde < 0)
                _solde -= _solde * TAUX_AGIOS;
        }

        // Renvoie la valeur du solde courant
        public decimal GetSolde()
        {
            return _solde;
        }
        #endregion
        #region Méthodes protégées (accessibles à l’intérieur de la classe et de ses dérivées)
        protected virtual decimal CalculerInterets()
        {
            decimal interets = _solde * 0.005m;
            _solde += interets;
            return interets;
        }
        #endregion
    }
}
