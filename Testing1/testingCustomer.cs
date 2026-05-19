using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace Testing1
{
        [TestClass]
        public class tstCustomer
        {
            string FirstName = "John";
            string LastName = "Smith";
            string Email = "john.smith@email.com";
            string Phone = "07700123456";

            [TestMethod]
            public void InstanceOK()
            {
                clsCustomer c = new clsCustomer();
                Assert.IsNotNull(c);
            }

            [TestMethod]
            public void CustomerIDPropertyOK()
            {
                clsCustomer c = new clsCustomer();
                int testData = 1;
                c.CustomerID = testData;
                Assert.AreEqual(c.CustomerID, testData);
            }

            [TestMethod]
            public void FirstNamePropertyOK()
            {
                clsCustomer c = new clsCustomer();
                string testData = "John";
                c.FirstName = testData;
                Assert.AreEqual(c.FirstName, testData);
            }

            [TestMethod]
            public void LastNamePropertyOK()
            {
                clsCustomer c = new clsCustomer();
                string testData = "Smith";
                c.LastName = testData;
                Assert.AreEqual(c.LastName, testData);
            }

            [TestMethod]
            public void EmailPropertyOK()
            {
                clsCustomer c = new clsCustomer();
                string testData = "john@email.com";
                c.Email = testData;
                Assert.AreEqual(c.Email, testData);
            }

            [TestMethod]
            public void PhonePropertyOK()
            {
                clsCustomer c = new clsCustomer();
                string testData = "07700123456";
                c.Phone = testData;
                Assert.AreEqual(c.Phone, testData);
            }

            [TestMethod]
            public void DateRegisteredPropertyOK()
            {
                clsCustomer c = new clsCustomer();
                DateTime testData = DateTime.Now.Date;
                c.DateRegistered = testData;
                Assert.AreEqual(c.DateRegistered, testData);
            }

            [TestMethod]
            public void IsActivePropertyOK()
            {
                clsCustomer c = new clsCustomer();
                bool testData = true;
                c.IsActive = testData;
                Assert.AreEqual(c.IsActive, testData);
            }

            [TestMethod]
            public void FindMethodOK()
            {
                clsCustomer c = new clsCustomer();
                bool found = false;
                int customerID = 1;
                found = c.Find(customerID);
                Assert.IsTrue(found);
            }

            [TestMethod]
            public void TestCustomerIDFound()
            {
                clsCustomer c = new clsCustomer();
                bool found = false;
                bool ok = true;
                int customerID = 1;
                found = c.Find(customerID);
                if (c.CustomerID != 1) ok = false;
                Assert.IsTrue(ok);
            }

            [TestMethod]
            public void ValidMethodOK()
            {
                clsCustomer c = new clsCustomer();
                string error = "";
                error = c.Valid(FirstName, LastName, Email, Phone);
                Assert.AreEqual(error, "");
            }

            [TestMethod]
            public void FirstNameMinLessOne()
            {
                clsCustomer c = new clsCustomer();
                string error = "";
                string firstName = "";
                error = c.Valid(firstName, LastName, Email, Phone);
                Assert.AreNotEqual(error, "");
            }

            [TestMethod]
            public void FirstNameMaxPlusOne()
            {
                clsCustomer c = new clsCustomer();
                string error = "";
                string firstName = new string('a', 51);
                error = c.Valid(firstName, LastName, Email, Phone);
                Assert.AreNotEqual(error, "");
            }

            [TestMethod]
            public void LastNameMinLessOne()
            {
                clsCustomer c = new clsCustomer();
                string error = "";
                string lastName = "";
                error = c.Valid(FirstName, lastName, Email, Phone);
                Assert.AreNotEqual(error, "");
            }

            [TestMethod]
            public void EmailMinLessOne()
            {
                clsCustomer c = new clsCustomer();
                string error = "";
                string email = "";
                error = c.Valid(FirstName, LastName, email, Phone);
                Assert.AreNotEqual(error, "");
            }

            [TestMethod]
            public void EmailInvalidNoAtSymbol()
            {
                clsCustomer c = new clsCustomer();
                string error = "";
                string email = "john.smithmail.com";
                error = c.Valid(FirstName, LastName, email, Phone);
                Assert.AreNotEqual(error, "");
            }

            [TestMethod]
            public void PhoneMinLessOne()
            {
                clsCustomer c = new clsCustomer();
                string error = "";
                string phone = "";
                error = c.Valid(FirstName, LastName, Email, phone);
                Assert.AreNotEqual(error, "");
            }
        }
    }



