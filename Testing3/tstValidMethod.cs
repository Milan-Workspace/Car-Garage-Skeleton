using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingServiceRepair
{
    [TestClass]
    public class tstValidMethod
    {
        [TestMethod]
        public void ValidMethodOK()
        {
            ServiceRepair sr = new ServiceRepair();

            string Error = sr.Valid(
                "1",
                "",
                DateTime.Now.Date.ToString(),
                "Brake Repair",
                "Hamza",
                "Pending"
            );

            Assert.AreEqual("", Error);
        }
    }
}