using System;
using ClassLibrary; // <--- THIS IS THE MAGIC LINK
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingVehicle
{
    [TestClass]
    public class tstVehicle
    {
        [TestMethod]
        public void InstanceOK()
        {
            // Create an instance of the class we want to create
            clsVehicle AnVehicle = new clsVehicle();
            // Test to see that it exists
            Assert.IsNotNull(AnVehicle);
        }

        [TestMethod]
        public void VehicleIdPropertyOK()
        {
            clsVehicle AnVehicle = new clsVehicle();
            int TestData = 1;
            AnVehicle.VehicleId = TestData;
            Assert.AreEqual(AnVehicle.VehicleId, TestData);
        }

        [TestMethod]
        public void MakePropertyOK()
        {
            clsVehicle AnVehicle = new clsVehicle();
            string TestData = "Ford";
            AnVehicle.Make = TestData;
            Assert.AreEqual(AnVehicle.Make, TestData);
        }

        [TestMethod]
        public void ModelPropertyOK()
        {
            clsVehicle AnVehicle = new clsVehicle();
            string TestData = "Focus";
            AnVehicle.Model = TestData;
            Assert.AreEqual(AnVehicle.Model, TestData);
        }

        [TestMethod]
        public void EngineSizePropertyOK()
        {
            clsVehicle AnVehicle = new clsVehicle();
            int TestData = 1600;
            AnVehicle.EngineSize = TestData;
            Assert.AreEqual(AnVehicle.EngineSize, TestData);
        }

        [TestMethod]
        public void DateAddedPropertyOK()
        {
            clsVehicle AnVehicle = new clsVehicle();
            DateTime TestData = DateTime.Now.Date;
            AnVehicle.DateAdded = TestData;
            Assert.AreEqual(AnVehicle.DateAdded, TestData);
        }

        [TestMethod]
        public void ActivePropertyOK()
        {
            clsVehicle AnVehicle = new clsVehicle();
            bool TestData = true;
            AnVehicle.Active = TestData;
            // The missing comma has been fixed here:
            Assert.AreEqual(AnVehicle.Active, TestData);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            clsVehicle AnVehicle = new clsVehicle();
            Boolean Found = false;
            int VehicleId = 1;
            Found = AnVehicle.Find(VehicleId);
            Assert.IsTrue(Found);
        }
    }
}