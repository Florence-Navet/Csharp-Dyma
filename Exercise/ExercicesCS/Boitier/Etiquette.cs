using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boites

{

    //creation des etiquettes couleurs et formats
    public enum Couleurs { Blanc, Bleu, Vert, Jaune, Orange, Rouge, Marron }
    public enum Formats { XS, S, L, M, XL }

    internal class Etiquette

    {
        //lecture seule initialisables à l'aide d'un initialiseurs et tte obligatoires
        public required string Client { get; init; } = string.Empty;
        public required Couleurs Couleur { get; init; }
        public required Formats Format { get; init; }

        public required long NumeroColis { get; init; }


    }
}
