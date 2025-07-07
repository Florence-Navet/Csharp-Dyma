using Services.Interfaces;
using Services.Test;
using System;

namespace Services.UI
{
    public class PageFacture : Page
    {
        private IServiceFacture _serviceFacture;

        // ✅ Constructeur avec injection de dépendance
        public PageFacture(IServiceFacture serviceFacture)
        {
            _serviceFacture = serviceFacture;
        }

        public override void Executer()
        {

            Console.WriteLine("Page de Facture !");
            Console.WriteLine("-------------------------------");

            // Utilise l'objet injecté
            DemoUtils.TesterFacturation(_serviceFacture);

           
            

        }
    }
}
