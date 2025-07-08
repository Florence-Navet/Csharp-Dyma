using Services.Interfaces;
using System;



namespace Services.Test
{
    public static class DemoUtils
    {
        public static void TesterClientsPresta()
        {
            var particulier = new Particulier(Civilités.Mr, "Dupont", "Eric", "25 rue de Paris");
            var prestaSimple = new Prestation(particulier.Id, new DateTime(2024, 5, 15), "Déclaration de revenus 2023", 300m);

            Console.WriteLine($"Client N°{particulier.Id} : {particulier.NomComplet}");
            Console.WriteLine($"Prestation : {prestaSimple.Intitulé}");
            Console.WriteLine($"Prix : {prestaSimple.PrixHT:0.00} €");
            Console.WriteLine($"Date : {prestaSimple.DateDébut:dd/MM/yy}");
            Console.WriteLine();

            var entreprise = new Entreprise("Microsoft France", 32773318400516, "100 avenue Tech");
            var prestationLT = new PrestationLT(entreprise.Id, new DateTime(2024, 1, 1), "Compta trimestrielle", 2000m);

            prestationLT.AjouterEtapes(new DateTime(2024, 3, 31), 0.25f, "Compta du trimestre 1");
            prestationLT.AjouterEtapes(new DateTime(2024, 6, 30), 0.50f, "Compta du trimestre 2");
            prestationLT.AjouterEtapes(new DateTime(2024, 9, 30), 0.75f, "Compta du trimestre 3");
            prestationLT.AjouterEtapes(new DateTime(2024, 12, 31), 1.00f, "Compta du trimestre 4");

            Console.WriteLine($"Client N°{entreprise.Id} : {entreprise.NomComplet}, SIRET : {entreprise.SIRET}");
            Console.WriteLine($"Prestation : {prestationLT.Intitulé} ({prestationLT.Etapes.Count} étapes)");
            Console.WriteLine($"Prix : {prestationLT.PrixHT:0.00} €");
            Console.WriteLine($"Date début : {prestationLT.DateDébut:dd/MM/yy}");
            Console.WriteLine("Etapes :");

            foreach (var étape in prestationLT.Etapes)
                Console.WriteLine($"- {étape.Libellé} du {étape.DateDébut:dd/MM/yy} au {étape.DateFin:dd/MM/yy} ({étape.Avancement:P0})");
        }

        public static void TesterFactureSimple(IServiceFacture facture)
        {
            //Console.WriteLine("***Nouvelle Facture Particulier ***");

            var particulier = new Particulier(Civilités.Mr, "Dupont", "Eric", "29 rue de la liberté - 88000 Epinal");
            var dt0 = new DateTime(2024, 5, 15);
            var presta = new Prestation(particulier.Id, dt0, "Déclaration de revenus 2023", 300m);

            facture.Client = particulier;
            facture.Prestation = presta;
            facture.DateCréation = dt0.AddDays(10);

            Console.WriteLine(facture.Editer());
        }

        public static void TesterFactureSituation()
        {
            

            var entreprise = new Entreprise("Microsoft France", 32773318400516, "19 rue du bois fleuri 75015 Paris");
            var dt = new DateTime(2024, 1, 1);
            var plt = new PrestationLT(entreprise.Id, dt, "Compta trimestrielle", 2000m);

            // Ajouter les 4 étapes et générer 4 factures
            for (int i = 1; i <= 4; i++)
            {
                DateTime dateFinEtape = dt.AddMonths(3 * i).AddDays(-1);
                plt.AjouterEtapes(dateFinEtape, i / 4f, $"Compta du trimestre {i}");

                var fs = new FactureSituation(entreprise, plt, dateFinEtape.AddDays(10));
                Console.WriteLine(fs.Editer());
            }
        }

        //public static void TesterFacturation(IServiceFacture facture)
        //{
        //    var particulier = new Particulier(Civilités.Mr, "Dupont", "Eric", "29 rue de la liberté - 88000 Epinal");
        //    var dt0 = new DateTime(2024, 5, 15);
        //    var presta = new Prestation(particulier.Id, dt0, "Déclaration de revenus 2023", 300m);
        //    //var facture = new ServiceFacture();
        //    facture.Client = particulier;
        //    facture.Prestation = presta;
        //    facture.DateCréation = dt0.AddDays(10);


        //    Console.WriteLine(facture.Editer());

        //    var entreprise = new Entreprise("Microsoft France", 32773318400516, "19 rue du bois fleuri 75015 Paris");
        //    var dt = new DateTime(2024, 1, 1);
        //    var plt = new PrestationLT(entreprise.Id, dt, "Compta trimestrielle", 2000m);

        //    for (int i = 1; i <= 4; i++)
        //    {
        //        DateTime dateFinEtape = dt.AddMonths(3 * i).AddDays(-1);
        //        plt.AjouterEtapes(dateFinEtape, i / 4f, $"Compta du trimestre {i}");
        //        var fs = new FactureSituation(entreprise, plt, dateFinEtape.AddDays(10));
        //        Console.WriteLine(fs.Editer());
        //    }
        //}
    }
}
