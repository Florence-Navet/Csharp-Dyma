using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    internal class Client

    {
        public required long NrClient { get; init; }//non modifiable donc init
        public required string Nom { get; set; } //modifiable en dehors de la classe donc get set
        public required string Prenom { get; set; }
        public required string Adresse { get; set; }
    }
}
