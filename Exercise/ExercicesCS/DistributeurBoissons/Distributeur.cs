using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons
{
    public class Carte
    {
        public string CodeDistributeur { get; }
        public int Id { get; }
        public decimal Solde { get; set; }

        public Carte(string codeDistributeur, int id)
        {
            CodeDistributeur = codeDistributeur;
            Id = id;
        }
    }

    public enum TypesBoissons { Café, Chocolat, Thé }

    public class Boisson
    {
        public TypesBoissons Type { get; set; }
        public int DoseSucre { get; set; }
    }

    public class Distributeur
    {
        public static readonly decimal PRIX_BOISSON = 1m; // Prix des boissons
        public static readonly string CODE_DISTRI = "XYZ"; // Code distributeur pour vérif des cartes

        public static readonly int CAFE = 0, CHOCOLAT = 1, THE = 2, SUCRE = 3, EAU = 4, GOBELETS = 5;

        private int[] _stocks = new int[6]; // Stocks de café, chocolat, thé, sucre, eau et gobelets


        /// <summary>
        /// methodes personalisées pour les exceptions
        /// </summary>
        public class UnitesIncorrectesException : Exception
        {
            public UnitesIncorrectesException(string message) : base(message) { }
        }

        public class IndiceStockInvalideException : Exception
        {
            public IndiceStockInvalideException(string message) : base(message) { }
        }

        public class CarteNonValideException : Exception
        {
            public CarteNonValideException(string message) : base(message) { }
        }
        public class StockInsuffisantException : Exception
        {
            public StockInsuffisantException(string message) : base(message) { }
        }
        public class SoldeInsuffisantException : Exception
        {
            public SoldeInsuffisantException(string message) : base(message) { }
        }



        /// <summary>
        /// Recharge le distributeur avec le nombre d'unités spécifiéa  
        /// pour le stock d'indice spécifié ou pour tous les stocks si indice = -1
        /// </summary>
        /// <param name="nbUnits">Nombre d'unités de recharge</param>
        /// <param name="indiceStock">Indice du stock (optionnel)</param>
        /// <exception cref="...">Nombre d'unités en dehors de la plage [0, 100],
        /// ou indice de stock en dehors de la plage [-1, 5]</exception>
        public void Recharger(int nbUnits, int indiceStock = -1)
        {
            // TODO : vérifier les valeurs des paramètres
            //new ArgumentOutOfRangeException pour les deux
            if (nbUnits < 0 || nbUnits > 100)
            {
                throw new UnitesIncorrectesException("Le nombre d'unites doit être compris entre 0 et 100");
            }

            if (indiceStock < -1 || indiceStock > 5)
            {
                throw new IndiceStockInvalideException("L'indice de stock doit être compris entre 1 et 5.");
            }

            if (indiceStock >= 0)
            {
                _stocks[indiceStock] = nbUnits;
            }
            else
            {
                for (int i = 0; i < _stocks.Length; i++)
                    _stocks[i] = nbUnits;
            }
        }

        /// <summary>
        /// Commande une boisson au distributeur
        /// </summary>
        /// <param name="carte">carte utilisée pour payer</param>
        /// <param name="type">type de boisson</param>
        /// <param name="doseSucre">dose de sucre</param>
        /// <returns>Boisson commandée</returns>
        public Boisson CommanderBoisson(Carte carte, TypesBoissons type, int doseSucre)
        {
            ValiderCarte(carte);
            VérifierStocks(type);
            DébiterCarte(carte, PRIX_BOISSON);
            Boisson boisson = PreparerBoisson(type, doseSucre);
            return boisson;
        }

        // Vérifie si le code distributeur de la carte est le bon
        // et émet une exception si ce n'est pas le cas
        
        public void ValiderCarte(Carte carte)
        {
            if (carte == null)
            {
                throw new ArgumentNullException(nameof(carte), "La carte ne peut pas être null");
                
            }

            if (carte.CodeDistributeur != CODE_DISTRI)
            {
                ////UnauthorizedAccessException   pouvait être utilise
                throw new CarteNonValideException("La carte n'est pas valide pour ce distrbuteur");
            }
        }

        // Vérifie que les stocks sont suffisants pour préparer la boisson demandée
        // et émet une exception si ce n'est pas le cas
        public void VérifierStocks(TypesBoissons typeBoisson)
        {
            //int index = (int)typeBoisson;

            //verifier si stock boisson demandée
            //InvalidOperationException

            if (_stocks[(int)typeBoisson] == 0)
            {
                throw new StockInsuffisantException($"Stock de {typeBoisson} insuffisant.");
            }
            if (_stocks[EAU] == 0)
            {
                throw new StockInsuffisantException("Le stock en eau est insuffisant");
            } 
            if (_stocks[GOBELETS] == 0)
            {
                throw new StockInsuffisantException("Le stock en gobelets st insuffisant");
            }
        }

        // Débite la carte du montant demandé
        // ou émet une exception si le solde est insuffisant
        //ArgumentException
        public void DébiterCarte(Carte carte, decimal montant)
        {
            if (carte.Solde < montant) 
            {
                throw new SoldeInsuffisantException("le solde de la carte est insuffiant pour cet achat.");
            }
            carte.Solde -= montant;
        }

        // Prépare et renvoie la boisson demandée
        public Boisson PreparerBoisson(TypesBoissons type, int doseSucre = 3)
        {
            // Décrémente les stocks de boisoon, sucre, eau et gobelets
            _stocks[(int)type]--;

            if (doseSucre > _stocks[SUCRE])
            {
                doseSucre = _stocks[SUCRE];
                _stocks[SUCRE] = 0;
            }
            else
                _stocks[SUCRE] -= doseSucre;

            _stocks[EAU]--;
            _stocks[GOBELETS]--;

            // Prépare la boisson
            Boisson b = new() { Type = type, DoseSucre = doseSucre };
            return b;
        }
    }
}
