using System;

namespace Services.Interfaces
{
    public interface IServiceFacture
    {
        IClient? Client { get; set; }
        DateTime DateCréation { get; set; }
        long Numéro { get; }
        IPrestation? Prestation { get; set; }

        string Editer();
    }
}
