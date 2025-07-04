using System;
using System.Collections.Generic;

namespace Facturation
{
    public class Prestation
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

    public class PrestationLongTerme : Prestation
    {
        private List<Etape> _étapes = new();
        public IReadOnlyList<Etape> Etapes => _étapes;

        public PrestationLongTerme(int idClient, DateTime dateDébut, string intitulé, decimal prixHT)
            : base(idClient, dateDébut, intitulé, prixHT) { }

        public void AjouterEtape(DateTime dateFin, float avancement, string libellé = "étape intermédiaire")
        {
            DateTime dateDébut = DateDébut;
            if (_étapes.Any())
                dateDébut = Etapes.Last().DateFin.AddDays(1);

            _étapes.Add(new Etape(dateDébut, dateFin, avancement, libellé));
        }

        public override string ToString()
        {
            return Etapes[^1].ToString();
        }
    }

    public class Etape
    {
        public DateTime DateDébut { get; }
        public DateTime DateFin { get; }
        public float Avancement { get; }
        public string Libellé { get; }

        public Etape(DateTime dateDébut, DateTime dateFin, float avancement, string libellé)
        {
            DateDébut = dateDébut;
            DateFin = dateFin;
            Avancement = avancement;
            Libellé = libellé;
        }

        public override string ToString()
        {
            return $"""
            Prestation : {Libellé}
            Période du {DateDébut:dd/MM/yy} au {DateFin:dd/MM/yy}
            Avancement : {Avancement:P0}
            """;
        }
    }
}
