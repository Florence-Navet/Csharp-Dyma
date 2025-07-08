using Services.Interfaces;
using System;

namespace Services
{
    public enum Civilités { Mme, Mr, Mlle }

    public abstract class Client : IClient
    {
        private static int _compteur;

        public int Id { get; }
        public string Adresse { get; set; } = string.Empty;
        public abstract string NomComplet { get; }

        // L'interface attend un "object Id" en lecture seule
        int IClient.Id => Id;

        protected Client(string adresse)
        {
            Id = ++_compteur;
            Adresse = adresse;
        }

        public override string ToString()
        {
            return $"""
            Référence : {Id}
            {NomComplet}
            Adresse : {Adresse}
            """;
        }
    }

    public class Particulier : Client
    {
        public Civilités Civilité { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }

        public override string NomComplet => $"{Civilité} {Nom} {Prénom}";

        public Particulier(Civilités civilité, string nom, string prénom, string adresse)
            : base(adresse)
        {
            Civilité = civilité;
            Nom = nom;
            Prénom = prénom;
        }
    }

    public class Entreprise : Client
    {
        public string RaisonSociale { get; set; }
        public long SIRET { get; set; }

        public override string NomComplet => $"Société {RaisonSociale}";

        public Entreprise(string raisonSociale, long siret, string adresse)
            : base(adresse)
        {
            RaisonSociale = raisonSociale;
            SIRET = siret;
        }

        public override string ToString()
        {
            return $"""
            Référence : {Id}
            {NomComplet}
            Adresse : {Adresse}
            SIRET : {SIRET:### ### ### #####}
            """;
        }
    }
}
