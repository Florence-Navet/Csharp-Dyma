using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelesDeDocuments
{
    internal class Personne
    {
        public required string Nom { get; init; }//car on ne les modifie pas -required pour obligatoire
        public required string Prenom { get; init; }//car on ne les modifie pas


    }
}
