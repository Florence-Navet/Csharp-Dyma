using System;
using Services.Interfaces;

namespace Services
{
    public class Prestation : IPrestation
    {
        public int IdClient { get; set; }
        public DateTime DateDébut { get; }
        public string Intitulé { get; set; }
        public decimal PrixHT { get; set; }

        public Prestation(int idClient, DateTime dateDébut, string intitulé, decimal prixHT)
        {
            IdClient = idClient;
            DateDébut = dateDébut;
            Intitulé = intitulé;
            PrixHT = prixHT;
        }

        public override string ToString()
        {
            return $"Prestation du {DateDébut:d} : {Intitulé}";
        }
    }
}
