using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PrestationLT : Prestation, IPrestationLT
    {
        private List<Etape> _étapes = new();
        public IReadOnlyList<Etape> Etapes => _étapes;

        public PrestationLT(int idClient, DateTime dateDébut, string intitulé, decimal prixHT)
            : base(idClient, dateDébut, intitulé, prixHT) { }

        public void AjouterEtapes(DateTime dateFin, float avancement, string libellé = "étape intermédiaire")
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
}
