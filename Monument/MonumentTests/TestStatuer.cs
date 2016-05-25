using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Monument;
using Monument.Facade;

namespace MonumentTests
{
    [TestClass]
    public class TestStatuer
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var testStatuerName = new Statuer();

            var facade = new Facade();

            testStatuerName.Statue_Id = 1;

            //act
            Statuer result = facade.GetStatuer(testStatuerName).Result;//kald facade

            //assert
            Assert.AreEqual("Den høje mand", result.Navn);
        }
    }
}
