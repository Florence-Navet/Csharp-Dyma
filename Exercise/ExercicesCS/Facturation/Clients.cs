using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation
{
    public abstract class Client
    {
        private static int _compteur;
        public int Id { get; }
        public string Adresse { get; set; } = string.Empty;
        public abstract string NomComplet { get; }

        public Client(string adresse)
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


        public enum Civilités { Mme, Mr, Mlle };

        public class Particulier : Client
        {
            public Civilités Civilité { get; set; }
            public string Nom { get; set; }
            public string Prénom { get; set; }
            public override string NomComplet => $"{Civilité} {Nom} {Prénom}";

            public Particulier(Civilités civilité, string nom, string prénom, string adresse) : base(adresse)
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

            public Entreprise(string raisonSociale, long siret, string adresse) : base(adresse)
            {
                RaisonSociale = raisonSociale;
                SIRET = siret;
            }

            public override string ToString()
            {
                return $"""
			{base.ToString()}
			SIRET : {SIRET:### ### ### #####}
			""";
            }


        }
    }

}