using Facturation;
using System;
using static Facturation.Client;

namespace Facturation
{
    internal class Program
    {


        static void Main(string[] args)
        {
            TesterClientsPresta();
        }

        static void TesterClientsPresta()


        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
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
    }
}
