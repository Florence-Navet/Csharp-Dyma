using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    public record class Livre
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public DateOnly DatePublication { get; set; }
        public string NomImage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Titre} ({Auteur}) - {DatePublication:yyyy-MM-dd}";
        }

    }
}
