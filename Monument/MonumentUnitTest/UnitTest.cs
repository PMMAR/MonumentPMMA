using System;
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

            Statuer StatuerNavnTest = new Statuer("lille havfrue", "A");
            StatuerNavnTest.Statue_Id = 1;
           
            //StatuerNavnTest.

            //act
            Facade facade = new Facade();
            Statuer result = facade.GetStatuer(StatuerNavnTest).Result;//kald facade

            //assert
            Assert.AreEqual("lille havfrue", result.Navn);
        }
    }
}
