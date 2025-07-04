using Facturation;
using System;
using static Facturation.Client;

namespace Facturation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool continuer = true;
            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("========= MENU FACTURATION =========");
                Console.WriteLine("1. Afficher les clients et prestations");
                Console.WriteLine("2. Générer et afficher les factures");
                Console.WriteLine("0. Quitter");
                Console.Write("Votre choix : ");
                string choix = Console.ReadLine();
                Console.Clear();

                switch (choix)
                {
                    case "1":
                        TesterClientsPresta();
                        break;
                    case "2":
                        TesterFacturation();
                        break;
                    case "0":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }

                if (continuer)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
                    Console.ReadKey();
                }
            }
        }

        static void TesterClientsPresta()
        {
            var particulier = new Particulier(Civilités.Mr, "Dupont", "Eric", "25 rue de Paris");
            var prestaSimple = new Prestation(particulier.Id, new DateTime(2024, 5, 15), "Déclaration de revenus 2023", 300m);

            Console.WriteLine($"Client N°{particulier.Id} : {particulier.NomComplet}");
            Console.WriteLine($"Prestation : {prestaSimple.Intitulé}");
            Console.WriteLine($"Prix : {prestaSimple.PrixHT:0.00} €");
            Console.WriteLine($"Date : {prestaSimple.DateDébut:dd/MM/yy}");
            Console.WriteLine();

            var entreprise = new Entreprise("Microsoft France", 32773318400516, "100 avenue Tech");
            var prestationLT = new PrestationLongTerme(entreprise.Id, new DateTime(2024, 1, 1), "Compta trimestrielle", 2000m);

            prestationLT.AjouterEtape(new DateTime(2024, 3, 31), 0.25f, "Compta du trimestre 1");
            prestationLT.AjouterEtape(new DateTime(2024, 6, 30), 0.50f, "Compta du trimestre 2");
            prestationLT.AjouterEtape(new DateTime(2024, 9, 30), 0.75f, "Compta du trimestre 3");
            prestationLT.AjouterEtape(new DateTime(2024, 12, 31), 1.00f, "Compta du trimestre 4");

            Console.WriteLine($"Client N°{entreprise.Id} : {entreprise.NomComplet}, SIRET : {entreprise.SIRET}");
            Console.WriteLine($"Prestation : {prestationLT.Intitulé} ({prestationLT.Etapes.Count} étapes)");
            Console.WriteLine($"Prix : {prestationLT.PrixHT:0.00} €");
            Console.WriteLine($"Date début : {prestationLT.DateDébut:dd/MM/yy}");
            Console.WriteLine("Etapes :");

            foreach (var étape in prestationLT.Etapes)
                Console.WriteLine($"- {étape.Libellé} du {étape.DateDébut:dd/MM/yy} au {étape.DateFin:dd/MM/yy} ({étape.Avancement:P0})");
        }

        static void TesterFacturation()
        {
            // Particulier et prestation simple
            var particulier = new Particulier(Civilités.Mr, "Dupont", "Eric", "29 rue de la liberté - 88000 Epinal");

          

            var dt0 = new DateTime(2024, 5, 15);
            var presta = new Prestation(particulier.Id, dt0, "Déclaration de revenus 2023", 300m);
            var facture = new Facture(particulier, presta, dt0.AddDays(10));

            Console.WriteLine(facture.Editer());

            // Entreprise et prestation long terme
            var entreprise = new Entreprise("Microsoft France", 32773318400516, "19 rue du bois fleuri 75015 Paris");
       

            var dt = new DateTime(2024, 1, 1);
            var plt = new PrestationLongTerme(entreprise.Id, dt, "Compta trimestrielle", 2000m);

            for (int i = 1; i <= 4; i++)
            {
                DateTime dateFinEtape = dt.AddMonths(3 * i).AddDays(-1);
                plt.AjouterEtape(dateFinEtape, i / 4f, $"Compta du trimestre {i}");
                var fs = new FactureSituation(entreprise, plt, dateFinEtape.AddDays(10));

                Console.WriteLine(fs.Editer());
            }
        }
    }
}
