using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    public class Article
    {
        public Article(string libelle, double volume)
        {
            Libelle = libelle;
            Volume = volume;
        }

        public string Libelle { get; init; }
        public double Volume { get; init; }
    }
}
