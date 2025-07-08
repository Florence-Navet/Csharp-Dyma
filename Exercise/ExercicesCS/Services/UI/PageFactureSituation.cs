using Services.Interfaces;
using Services.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Services.Test;
using System;

namespace Services.UI
{
    public class PageFactureSituation : Page
    {

        private IServiceFacture _serviceFacture;

        // ✅ Constructeur avec injection de dépendance
        public PageFactureSituation(IServiceFacture serviceFacture)
        {
            _serviceFacture = serviceFacture;
        }

        public override void Executer()
        {
            Console.WriteLine("***Nouvelle Facture Entreprise ***");
            Console.WriteLine("-----------------------------------");
            DemoUtils.TesterFactureSituation();

        }
    }
}
