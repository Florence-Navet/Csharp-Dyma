using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPrestationLT : IPrestation
    {
        IReadOnlyList<Etape> Etapes { get; }

        void AjouterEtapes(DateTime dateFin, float avancement, string libellé = "étape intermédiaire");
    }
}
