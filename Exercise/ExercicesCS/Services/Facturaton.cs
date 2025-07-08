using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceFacture : IServiceFacture
    {
        private static int cpt;
        public static readonly decimal TAUX_TVA = 0.2m;

        public long Numéro { get;} 
        public DateTime DateCréation { get; set; }
        public int DélaiPaiement { get; set; }
        public IClient? Client { get; set; }
        public IPrestation? Prestation { get; set; }


        public decimal MontantHT => Prestation?.PrixHT ?? 0;
        public decimal TVA => Prestation?.PrixHT * TAUX_TVA ?? 0;
        public decimal MontantTTC => MontantHT + TVA;


        //constructeur

        public ServiceFacture()
        {
            Numéro = ++cpt;
            DateCréation = DateTime.Now;
            DélaiPaiement = 30;

        }

        public virtual string Editer()
        {
            if (Client == null || Prestation == null)

                return "impossible d'editer la facture : client ou prestation manquant :";
            var sb = new StringBuilder();

            //TODO à faire
            sb.AppendLine("*** FACTURE SIMPLE ***");
            sb.AppendLine($"Facture N°{Numéro} du {DateCréation:dd/MM/yy}");
            sb.AppendLine();
            sb.AppendLine("Emetteur :");
            sb.AppendLine("Société ABC");
            sb.AppendLine("3 avenue des champs Elysées - 75008 Paris");
            sb.AppendLine("Siren : 687 456 321");
            sb.AppendLine();
            sb.AppendLine("Client :");
            sb.AppendLine(Client.ToString());
            sb.AppendLine();
            sb.AppendLine($"  Prix HT :  {MontantHT,8:0.00} €");
            sb.AppendLine($"      TVA :  {TVA,8:0.00} €");
            sb.AppendLine($"Total TTC :  {MontantTTC,8:0.00} €");
            sb.AppendLine("------------------------------------------");

            return sb.ToString();


        }


    }
    public class FactureSituation : ServiceFacture
    {
        public FactureSituation(IClient client, IPrestationLT presta, DateTime dateCréation) :
            base()
        {
            Client = client;
            Prestation = presta;
            DateCréation = dateCréation;
        }

        public override string Editer()
        {
            if(Client ==null ||  Prestation ==null)

            return "impossible d'editer la facture : client ou prestation manquant :";   
                    var sb = new StringBuilder();

            sb.AppendLine("*** FACTURE DE SITUATION ***");
            sb.AppendLine($"Facture N°{Numéro} du {DateCréation:dd/MM/yy}");
            sb.AppendLine();
            sb.AppendLine("Emetteur :");
            sb.AppendLine("Société ABC");
            sb.AppendLine("3 avenue des champs Elysées - 75008 Paris");
            sb.AppendLine("Siren : 687 456 321");
            sb.AppendLine();
            sb.AppendLine("Client :");
            sb.AppendLine(Client.ToString());
            sb.AppendLine();

            // 🔍 On caste la prestation et récupère l'étape directement
            var prestationLT = (PrestationLT)Prestation;
            var etape = prestationLT.Etapes.Last();

            sb.AppendLine($"Prestation : {etape.Libellé}");
            sb.AppendLine($"Période du {etape.DateDébut:dd/MM/yy} au {etape.DateFin:dd/MM/yy}");
            sb.AppendLine($"Avancement : {etape.Avancement:P0}");
            sb.AppendLine();

            sb.AppendLine($"  Prix HT :  {MontantHT,8:0.00} €");
            sb.AppendLine($"      TVA :  {TVA,8:0.00} €");
            sb.AppendLine($"Total TTC :  {MontantTTC,8:0.00} €");
            sb.AppendLine("------------------------------------------");

            return sb.ToString();
        }

    }
}
