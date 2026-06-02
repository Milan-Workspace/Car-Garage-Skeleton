using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingServiceRepair
{
    [TestClass]
    public class tstProperties
    {
        [TestMethod]
        public void PropertyOK()
        {
            ServiceRepair sr = new ServiceRepair();

            sr.ServiceID = 1;
            sr.VehicleID = 1;
            sr.Description = "Brake Repair";
            sr.LaborName = "Hamza";
            sr.Status = "Pending";

            Assert.AreEqual(1, sr.ServiceID);
            Assert.AreEqual(1, sr.VehicleID);
            Assert.AreEqual("Brake Repair", sr.Description);
            Assert.AreEqual("Hamza", sr.LaborName);
            Assert.AreEqual("Pending", sr.Status);
        }
    }
}