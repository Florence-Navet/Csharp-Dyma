using DistributeurBoissons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DistributeurBoissons.Distributeur;


namespace DistributeurBoissonsTest
{
    [TestClass]
    public class TestDistributeur
    {
        private Distributeur _distri;
        private Carte _carte;

        [TestInitialize]
        public void Init()
        {
            _distri = new Distributeur();
            _carte = new Carte(CODE_DISTRI, 1) { Solde = 5m };
        }

        [TestMethod]
        public void TestCommandeValide()
        {
            _distri.Recharger(10);
            Boisson b = _distri.CommanderBoisson(_carte, TypesBoissons.Thé, 2);

            Assert.AreEqual(TypesBoissons.Thé, b.Type);
            Assert.AreEqual(2, b.DoseSucre);
            Assert.AreEqual(4m, _carte.Solde);
        }

        [TestMethod]
        public void CommandeOkMaisSucreInsuffisant()
        {
            TypesBoissons type = TypesBoissons.Chocolat;
            int doseSucre = 6;  // Nb d'unités de sucre demandé
            int unitésSucreDistri = 5; // Nb d'unités de sucre restantes dans le distributeur
            _carte.Solde = 5m;

            _distri.Recharger(10);
            _distri.Recharger(unitésSucreDistri, 3);
            Boisson b = _distri.CommanderBoisson(_carte, type, doseSucre);

            Assert.AreEqual(type, b.Type, "type de boisson");
            Assert.AreEqual(unitésSucreDistri, b.DoseSucre, "dose de sucre");
        }

        [TestMethod]
        [ExpectedException(typeof(CarteNonValideException))]
        public void CommandeAvecCarteNonValide()
        {
            Carte carte = new Carte("ABC", 0) { Solde = 3 };
            _distri.CommanderBoisson(carte, TypesBoissons.Thé, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(SoldeInsuffisantException))]
        public void CommandeAvecSoldeCarteInsuffisant()
        {
            _carte.Solde = 0m;
            _distri.Recharger(10);
            _distri.CommanderBoisson(_carte, TypesBoissons.Café, 0);
        }

        [DataTestMethod]
        [DataRow(0, DisplayName = "Stock de café vide")]
        [DataRow(1, DisplayName = "Stock de chocolat vide")]
        [DataRow(2, DisplayName = "Stock de thé vide")]
        [DataRow(4, DisplayName = "Stock d'eau vide")]
        [DataRow(5, DisplayName = "Stock de gobelets vide")]
        [ExpectedException(typeof(StockInsuffisantException))]


     
        public void CommandeAvecStockInsuffisant(int indiceStock)
        {
            _distri.Recharger(1);   // Initialise tous les stocks à 1
            _distri.Recharger(0, indiceStock); // Vide le stock d'indice donné
            TypesBoissons typeBoisson = TypesBoissons.Café;
            if (indiceStock < 3)
                typeBoisson = (TypesBoissons)indiceStock;
            int doseSucre = 0;

            _distri.CommanderBoisson(_carte, typeBoisson, doseSucre);
        }

        [TestMethod]
        [ExpectedException(typeof(StockInsuffisantException))]
        public void CommandeOkPuisStockInsufisant()
        {
            TypesBoissons typeBoisson = TypesBoissons.Thé;
            int doseSucre = 3;

            _distri.Recharger(2);
            _distri.Recharger(1, 2);
            _carte.Solde = 2m;
            Boisson b = _distri.CommanderBoisson(_carte, typeBoisson, doseSucre);

            Assert.AreEqual(typeBoisson, b.Type, "type de boisson");
            Assert.AreEqual(2, b.DoseSucre, "dose de sucre");

            // Nouvelle commande du même type de boisson
            _distri.CommanderBoisson(_carte, typeBoisson, doseSucre);
        }
    }

}