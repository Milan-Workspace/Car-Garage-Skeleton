using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingServiceRepair
{
    [TestClass]
    public class tstFindMethod
    {
        [TestMethod]
        public void FindMethodOK()
        {
            ServiceRepair sr = new ServiceRepair();

            bool Found = sr.Find(1);

            Assert.IsTrue(Found);
        }
    }
}