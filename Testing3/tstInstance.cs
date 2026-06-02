using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingServiceRepair
{
    [TestClass]
    public class tstInstance
    {
        [TestMethod]
        public void InstanceOK()
        {
            ServiceRepair sr = new ServiceRepair();

            Assert.IsNotNull(sr);
        }
    }
}