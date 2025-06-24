using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    internal class Client

    {
        public int NrClient { get; set; }
        public required string Nom { get; init; }
        public required string Prenom { get; init; }
        public required string Adresse { get; init; }
    }
}
