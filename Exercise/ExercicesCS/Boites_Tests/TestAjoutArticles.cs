using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites_Tests
{
    [TestClass]
    public class TestAjoutArticles
    {
        [TestMethod]
        public void AjouterArticleDansBoiteAssezGrande()
        {
            Boite maboite = new Boite(3,4, 5);
            Article monArticle = new Article("Cafetière portable", 40);

            bool res = maboite.TryAddArticle(monArticle);
            Assert.IsTrue(res);
            Assert.AreEqual(1, maboite.Articles.Count);
        }

        [TestMethod]
        public void Ajouter2ArticlesDansBoiteAssezGrande()
        {
            Boite maboite = new Boite(3, 4, 6);
            Article monArticle = new Article("Cafetière portable", 40);
            Article monArticle2 = new Article("Verres en plastique", 20);

            bool res = maboite.TryAddArticle(monArticle);
            Assert.IsTrue(res);
            res = maboite.TryAddArticle(monArticle2);
            Assert.IsTrue(res);

            Assert.AreEqual(2, maboite.Articles.Count);


        }

        [TestMethod]
        public void AjouterArticleDansBoiteTropPetite()
        {
            Boite maboite = new Boite(2, 3, 4);
            Article monArticle = new Article("Cafetière portable", 40);

            bool res = maboite.TryAddArticle(monArticle);
            Assert.IsFalse(res);
            Assert.AreEqual(0, maboite.Articles.Count);



        }

        [TestMethod]
        public void Ajouter2Article2DansBoiteTropPetite()
        {
            Boite maboite = new Boite(2, 3, 4);
            Article monArticle = new Article("Cafetière portable", 20);
            Article monArticle2 = new Article("Verres en plastique", 40);


            bool res = maboite.TryAddArticle(monArticle);
            Assert.IsTrue(res);
            res = maboite.TryAddArticle(monArticle2);
            Assert.IsFalse(res);

            Assert.AreEqual(1, maboite.Articles.Count);
        }
    }

   
}
