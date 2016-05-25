using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Monument;
using Monument.Facade;



namespace MonumentUnitTest
{
    [TestClass()]
    public class StatuerUnitTest
    {
        [TestMethod()]
        public void TestGetStatuer()
        {
            //arrange
            Statuer testStatuerName = new Statuer(1 , "Hav", "A");


            Facade facade = new Facade();
            //testStatuerName.Statue_Id = 1;

            //act
            Statuer result = facade.GetStatuer(testStatuerName).Result;//kald facade

            //assert
           
            Assert.AreEqual("Hav" , result.Navn);
        }


    }
}
