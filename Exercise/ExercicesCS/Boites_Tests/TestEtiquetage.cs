using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boites_Tests
{
    [TestClass]
    public class TestEtiquetage
    {
        [TestMethod]
        public void CreatioBoiteSansMatiere()
        {
            Boite maBoite = new Boite(2,3, 4);
            Assert.AreEqual(24, maBoite.Volume);
            Assert.AreEqual(Matieres.Carton, maBoite.Matiere);
        }

        [TestMethod]
        public void CreationBoiteAvecMatiere()
        {
            Matieres mat = Matieres.Bois;
            Boite maBoite = new Boite(2, 3, 4, mat);
            Assert.AreEqual(24, maBoite.Volume);
            Assert.AreEqual(mat, maBoite.Matiere);
        }

        [TestMethod]
        public void EtiqueterBoiteNonFragile()
        {
            Boite maBoite = new Boite(2, 3, 4);
            Client client = new()
            {
                NrClient = 1234,
                Nom = "Mousquet",
                Prenom = "Julien",
                Adresse = "7 rue des lilas - 06000 Nice"
            };
            long NumeroColis = 789456;

            maBoite.Etiqueter(client, NumeroColis);

            Assert.IsNotNull(maBoite.EtiquetteColis);
            Assert.AreEqual(client.NrClient, maBoite.EtiquetteColis.Destinataire.NrClient);
            Assert.AreEqual(NumeroColis, maBoite.EtiquetteColis.NumeroColis);
            Assert.AreEqual(Couleurs.Blanc, maBoite.EtiquetteColis.Couleur);
            Assert.AreEqual(Formats.XL, maBoite.EtiquetteColis.Format);
        }

        [TestMethod]
        public void EtiquerBoiteFragile()
        {
            Boite maBoite = new Boite(2, 3, 4);
            Client client = new()
            {
                NrClient = 1234,
                Nom = "Mousquet",
                Prenom = "Tristan",
                Adresse = "7 rue des lilas - 06000 Nice"
            };
            long NumeroColis = 789456;

            maBoite.Etiqueter(client, NumeroColis, true);

            Assert.IsTrue(maBoite.Fragile);
        }
    }
}
