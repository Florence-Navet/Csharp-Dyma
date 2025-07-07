using System;


namespace Services.Interfaces
{
    public interface IPrestation
    {
        int IdClient { get; set; }
        DateTime DateDébut { get; }
        string Intitulé { get; set; }
        decimal PrixHT { get; set; }


    }
}