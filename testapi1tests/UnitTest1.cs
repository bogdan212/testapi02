using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testapi1;

namespace testapi1tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //act
            Program coma = new Program();
            int actual = coma.GetDataFromServer(10,10);
            int expected = 20;
            //assert
            Assert.AreEqual(expected, actual);
            
        }
    }
}
