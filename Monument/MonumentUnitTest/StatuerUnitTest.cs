using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Monument;
using Monument.Facade;

namespace MonumentUnitTest
{
    [TestClass]
    public class StatuerUnitTest
    {
        [TestMethod]
        public void TestGetStatuer()
        {
            //arrange
            var testStatuerName = new Statuer();

            var facade = new Facade();

            testStatuerName.Statue_Id = 1;

            //act
            Statuer result = facade.GetStatuer(testStatuerName).Result;//kald facade

            //assert
            Assert.AreEqual("Den høje mand" , result.Navn);
        }


        [TestMethod]
        public void TestPostStatuer()
        {
            //arrange
            var testStatuer = new Statuer();

            var facade = new Facade();

            Adresse adresse = new Adresse();
            //adresse.ByNavn = "Roskilde";
            adresse.PostNr = 4100;
            adresse.ByNavn = "Ringsted";

            testStatuer.Navn = "TestStatue";
            testStatuer.Prioritet = "A";
            //testStatuer.FK_PostNr = 1308;
            //testStatuer.ByNavn = "Klerkegade";
            testStatuer.Adresse = adresse;

            //act
            Statuer result = facade.PostStatuer(testStatuer).Result;

            //assert

            Assert.AreEqual(testStatuer.Navn, result.Navn);
            

             //Assert.AreNotEqual("10" + "b" + "Klerkegade" + "1308", result.Navn + result.Prioritet + result.ByNavn + result.FK_PostNr);
        }

    }
}
