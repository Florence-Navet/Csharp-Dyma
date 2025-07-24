using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationPeriodique
{
    public record class Famille
    {
        public required short Id { get; init; }
        public required string Nom { get; init; }
        public string? Couleur { get; init; }
    }

    public record class Etat
    {
        public required char Code { get; init; }
        public required string Nom { get; init; }
        public string? Couleur { get; init; }
    }

    public record class Element
    {
        public short Période { get; init; }
        public required short NumAtomique { get; init; }
        public required string Symbole { get; init; }
        public required char CodeEtat { get; init; }

        public short NumFamille { get; init; }

        public required string Nom { get; init; }
    }
}
