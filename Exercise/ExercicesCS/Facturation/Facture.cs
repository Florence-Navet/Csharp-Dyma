using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Facturation
{
    public class Facture
    {
        private static int cpt;
        public static readonly decimal TAUX_TVA = 0.2m;

        public long Numéro { get; }
        public DateTime DateCréation { get; }
        public int DélaiPaiement { get; set; }
        public Client Client { get; }
        public Prestation Prestation { get; }
       

        public decimal MontantHT => Prestation.PrixHT;
        public decimal TVA => Prestation.PrixHT * TAUX_TVA;
        public decimal MontantTTC => MontantHT + TVA;


        //constructeur

        public Facture(Client client, Prestation prestation, DateTime dateCréation)
        {
            Numéro = ++cpt;
            Client = client;
            Prestation = prestation;
            DateCréation = dateCréation;
            DélaiPaiement = 30;
        }

        // Surcharge si on veut spécifier un autre délai
        public Facture(Client client, Prestation prestation, DateTime dateCréation, int délaiPaiement)
            : this(client, prestation, dateCréation)
        {
            DélaiPaiement = délaiPaiement;
        }

        public virtual string Editer()
        {
            var sb = new StringBuilder();

            //TODO à faire
            sb.AppendLine("------------------------------------------");
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
    public class FactureSituation : Facture
    {
        public FactureSituation(Client client, PrestationLongTerme presta, DateTime dateCréation) :
            base(client, presta, dateCréation)
        {

        }

        public override string Editer()
        {
            var sb = new StringBuilder();

            sb.AppendLine("------------------------------------------");
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
            var prestationLT = (PrestationLongTerme)Prestation;
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
