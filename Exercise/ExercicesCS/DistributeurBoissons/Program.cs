using System;

namespace DistributeurBoissons
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Distributeur distributeur = new Distributeur();

            // Création des cartes de test
            Carte carteValide = new Carte(Distributeur.CODE_DISTRI, 1) { Solde = 10.0m };
            Carte carteInvalide = new Carte("Wrong_Code", 2) { Solde = 5.0m };
            Carte carteSoldeInsuffisant = new Carte(Distributeur.CODE_DISTRI, 3) { Solde = 0.5m };

            Carte carteValide2 = new Carte(Distributeur.CODE_DISTRI, 1) { Solde = 12.0m };
            Distributeur distributeur1 = new Distributeur();
            distributeur1.Recharger(5);


            Console.WriteLine("=== TESTS DE RECHARGE ===");
            try
            {
                Console.WriteLine("Recharge tous les stocks avec 50 unités...");
                distributeur.Recharger(50);
                Console.WriteLine("✓ Recharge réussie.\n");

                Console.WriteLine("Recharge du stock de café avec 30 unités...");
                distributeur.Recharger(30, Distributeur.CAFE);
                Console.WriteLine("✓ Recharge réussie.\n");

                Console.WriteLine("Recharge avec 150 unités (invalide)...");
                distributeur.Recharger(150);
            }
            catch (Distributeur.UnitesIncorrectesException ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
            catch (Distributeur.IndiceStockInvalideException ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur inattendue: {ex.Message}");
            }

            Console.WriteLine("\n=== VALIDATION DES CARTES ===");
            try
            {
                Console.WriteLine("Validation d'une carte valide...");
                distributeur.ValiderCarte(carteValide);
                Console.WriteLine("✓ Carte valide.\n");

                Console.WriteLine("Validation d'une carte invalide...");
                distributeur.ValiderCarte(carteInvalide);
                Console.WriteLine("✗ Carte invalide.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }

            Console.WriteLine("\n=== TESTS DES STOCKS ===");

            // Cas : stock vide
            try
            {
                Console.WriteLine("Vidage complet des stocks...");
                distributeur.Recharger(0);
                Console.WriteLine("Test du stock de café (doit échouer)...");
                distributeur.VérifierStocks(TypesBoissons.Café);
                Console.WriteLine("✓ Stocks suffisants.");
            }
            catch (Distributeur.StockInsuffisantException ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }

            // Cas : manque eau
            try
            {
                Console.WriteLine("\nRecharge café = 10, eau = 0...");
                distributeur.Recharger(10, Distributeur.CAFE);
                distributeur.Recharger(0, Distributeur.EAU);
                Console.WriteLine("Test du stock de café (eau manquante)...");
                distributeur.VérifierStocks(TypesBoissons.Café);
                Console.WriteLine("✓ Stocks suffisants.");
            }
            catch (Distributeur.StockInsuffisantException ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }

            // Cas : manque gobelets
            try
            {
                Console.WriteLine("\nRecharge eau = 10, gobelets = 0...");
                distributeur.Recharger(10, Distributeur.EAU);
                distributeur.Recharger(0, Distributeur.GOBELETS);
                Console.WriteLine("Test du stock de café (gobelets manquants)...");
                distributeur.VérifierStocks(TypesBoissons.Café);
                Console.WriteLine("✓ Stocks suffisants.");
            }
            catch (Distributeur.StockInsuffisantException ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }

            Console.WriteLine("\n=== TESTS DE DÉBIT DE CARTE ===");

            try
            {
                Console.WriteLine("Débit d'une carte avec solde suffisant...");
                distributeur.DébiterCarte(carteValide, 1.0m);
                Console.WriteLine($"✓ Débit réussi. Solde restant : {carteValide.Solde}");
            }
            catch (Distributeur.SoldeInsuffisantException ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }

            try
            {
                Console.WriteLine("Débit d'une carte avec solde insuffisant...");
                distributeur.DébiterCarte(carteSoldeInsuffisant, 1.0m);
                Console.WriteLine("✓ Débit réussi.");
            }
            catch (Distributeur.SoldeInsuffisantException ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }

            Console.WriteLine("\n=== TEST COMMANDE CHOCOLAT AVEC PEU DE SUCRE ===");

            try
            {
                // On recharge uniquement le nécessaire sauf le sucre
                distributeur.Recharger(5, Distributeur.CHOCOLAT);
                distributeur.Recharger(5, Distributeur.EAU);
                distributeur.Recharger(5, Distributeur.GOBELETS);
                distributeur.Recharger(2, Distributeur.SUCRE); // sucre insuffisant pour demande

                Console.WriteLine("Commande d'un chocolat avec 5 doses de sucre (mais stock = 2)...");
                Boisson chocolat = distributeur.CommanderBoisson(carteValide, TypesBoissons.Chocolat, 5);

                Console.WriteLine($"✓ Chocolat préparé avec {chocolat.DoseSucre} dose(s) de sucre (ajusté).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }

            Console.WriteLine("\n=== TEST COMMANDE AVEC CARTE NON VALIDE ===");

            try
            {
                distributeur.Recharger(10); // Stocks suffisants
                Boisson b = distributeur.CommanderBoisson(carteInvalide, TypesBoissons.Thé, 2);
                Console.WriteLine($"Boisson servie : {b.Type} avec {b.DoseSucre} sucre(s)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
            Console.WriteLine("\n=== TEST DOUBLE COMMANDE D'UNE MÊME BOISSON ===");

            try
            {
                // On recharge uniquement 1 dose de café + les autres éléments
                distributeur.Recharger(1, Distributeur.CAFE);
                distributeur.Recharger(5, Distributeur.SUCRE);
                distributeur.Recharger(5, Distributeur.EAU);
                distributeur.Recharger(5, Distributeur.GOBELETS);

                Console.WriteLine("Commande 1 : Café...");
                Boisson b1 = distributeur.CommanderBoisson(carteValide, TypesBoissons.Café, 1);
                Console.WriteLine($"✓ Première commande OK : {b1.Type}, sucre : {b1.DoseSucre}");

                Console.WriteLine("Commande 2 : Café (stock épuisé)...");
                Boisson b2 = distributeur.CommanderBoisson(carteValide, TypesBoissons.Café, 1);
                Console.WriteLine($"✓ Deuxième commande OK : {b2.Type}, sucre : {b2.DoseSucre}");
            }
            catch (Distributeur.StockInsuffisantException ex)
            {
                Console.WriteLine($"Erreur attendue : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Autre erreur : {ex.Message}");
            }

            Console.WriteLine("\n=== SIMULATION DE 15 COMMANDES DE THÉ ===");

            int sucre = 2;
            int numeroCommande = 1;

            for (int i = 0; i < 15; i++)
            {
                try
                {
                    Boisson b = distributeur1.CommanderBoisson(carteValide2, TypesBoissons.Thé, sucre);
                    Console.WriteLine($"Thé N°{numeroCommande} sucré à {b.DoseSucre} servi. Solde de carte : {carteValide2.Solde} €");

                    if (sucre > 0)
                        sucre--;

                    numeroCommande++;
                }
                catch (Distributeur.StockInsuffisantException ex)
                {
                    Console.WriteLine($"Boisson N°{numeroCommande} non servie. {ex.Message} Rechargement de la machine.");

                    distributeur1.Recharger(5);

                    try
                    {
                        Boisson b = distributeur1.CommanderBoisson(carteValide2, TypesBoissons.Thé, sucre);
                        Console.WriteLine($"Thé N°{numeroCommande} sucré à {b.DoseSucre} servi. Solde de carte : {carteValide2.Solde} €");

                        if (sucre > 0)
                            sucre--;

                        numeroCommande++;
                    }
                    catch (Distributeur.SoldeInsuffisantException)
                    {
                        Console.WriteLine("Solde de carte insuffisant.");
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Erreur inattendue : {e.Message}");
                        break;
                    }
                }
                catch (Distributeur.SoldeInsuffisantException)
                {
                    Console.WriteLine("Solde de carte insuffisant.");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erreur inattendue : {e.Message}");
                    break;
                }
            }

            try
            {
                Carte carte = new("XYZ", 1) { Solde = 12m };
                Distributeur distri = new();
                distri.Recharger(5);

                int numCmd = 1;
                while (numCmd <= 15)
                {
                    try
                    {
                        Boisson b = distri.CommanderBoisson(carte, TypesBoissons.Thé, 2);
                        Console.WriteLine($"{b.Type} N°{numCmd} sucré à {b.DoseSucre} servi. Solde de carte : {carte.Solde:C0}");
                        numCmd++;
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine($"Boisson N°{numCmd} non servie. {e.Message} Rechargement de la machine.");
                        distri.Recharger(5);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
