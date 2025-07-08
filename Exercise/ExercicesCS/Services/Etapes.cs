using System;

namespace Services
{
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
