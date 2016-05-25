using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Monument;
using Monument.Facade;
using Monument.ViewModels;


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


    }
}
