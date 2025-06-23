using System;

namespace POO
{
    internal class CompteBancaire
    {
        #region Champs privés
        private const decimal PLAFOND_MAXI = 1000m;
        private readonly long _numero;
        private decimal _solde;
        private const decimal TAUX_AGIOS = 0.15m;
        public static readonly decimal TAUX_INTERET = 0.2m;
        private static decimal _tauxAgios;
        private decimal _plafondRetrait;
        #endregion

        #region Propriétés publiques
        public long Numero => _numero;

        public string Libelle { get; set; } = string.Empty;

        public decimal Solde => _solde;

        public decimal PlafondRetrait
        {
            get { return _plafondRetrait; }
            set
            {
                if (value <= PLAFOND_MAXI)
                    _plafondRetrait = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(PlafondRetrait), "Valeur de plafond trop élevée");
            }
        }
        #endregion

        #region Constructeur
        public CompteBancaire(long num)
        {
            _numero = num;
            Libelle = "Compte N°" + num;
        }
        #endregion

        #region Méthodes publiques
        public void Crediter(decimal montant)
        {
            _solde += montant;
        }

        public void Debiter(decimal montant)
        {
            _solde -= montant;
            if (_solde < 0)
                _solde -= _solde * TAUX_AGIOS;
        }

        public void Debiter(decimal montant, string libelle)
        {
            Debiter(montant);
            // Gestion du libellé si nécessaire
        }

        public void Debiter(decimal montant, string libelle, DateOnly dateEffet)
        {
            Debiter(montant, libelle);
            // Gestion de la date d'effet si nécessaire
        }

        public decimal GetSolde()
        {
            return _solde;
        }
        #endregion

        #region Méthodes protégées
        protected virtual decimal CalculerInterets()
        {
            decimal interets = _solde * 0.005m;
            _solde += interets;
            return interets;
        }
        #endregion
    }
}
