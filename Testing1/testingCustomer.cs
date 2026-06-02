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
        // FirstName tests
        [TestMethod]
        public void FirstNameMinBoundary()
        {
            clsCustomer c = new clsCustomer();
            string firstName = "A"; // 1 char - min boundary
            string error = c.Valid(firstName, LastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void FirstNameMinPlusOne()
        {
            clsCustomer c = new clsCustomer();
            string firstName = "AB"; // 2 chars
            string error = c.Valid(firstName, LastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void FirstNameMaxMinusOne()
        {
            clsCustomer c = new clsCustomer();
            string firstName = new string('a', 49);
            string error = c.Valid(firstName, LastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void FirstNameMaxBoundary()
        {
            clsCustomer c = new clsCustomer();
            string firstName = new string('a', 50);
            string error = c.Valid(firstName, LastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void FirstNameMid()
        {
            clsCustomer c = new clsCustomer();
            string firstName = new string('a', 25);
            string error = c.Valid(firstName, LastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void FirstNameExtremeMax()
        {
            clsCustomer c = new clsCustomer();
            string firstName = new string('a', 1000);
            string error = c.Valid(firstName, LastName, Email, Phone);
            Assert.AreNotEqual(error, "");
        }

        // LastName tests
        [TestMethod]
        public void LastNameMinBoundary()
        {
            clsCustomer c = new clsCustomer();
            string lastName = "A";
            string error = c.Valid(FirstName, lastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void LastNameMinPlusOne()
        {
            clsCustomer c = new clsCustomer();
            string lastName = "AB";
            string error = c.Valid(FirstName, lastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void LastNameMaxMinusOne()
        {
            clsCustomer c = new clsCustomer();
            string lastName = new string('a', 49);
            string error = c.Valid(FirstName, lastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void LastNameMaxBoundary()
        {
            clsCustomer c = new clsCustomer();
            string lastName = new string('a', 50);
            string error = c.Valid(FirstName, lastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void LastNameMaxPlusOne()
        {
            clsCustomer c = new clsCustomer();
            string lastName = new string('a', 51);
            string error = c.Valid(FirstName, lastName, Email, Phone);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void LastNameMid()
        {
            clsCustomer c = new clsCustomer();
            string lastName = new string('a', 25);
            string error = c.Valid(FirstName, lastName, Email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void LastNameExtremeMax()
        {
            clsCustomer c = new clsCustomer();
            string lastName = new string('a', 1000);
            string error = c.Valid(FirstName, lastName, Email, Phone);
            Assert.AreNotEqual(error, "");
        }

        // Email tests
        [TestMethod]
        public void EmailMinBoundary()
        {
            clsCustomer c = new clsCustomer();
            string email = "a@b"; // 3 chars with @
            string error = c.Valid(FirstName, LastName, email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void EmailMinPlusOne()
        {
            clsCustomer c = new clsCustomer();
            string email = "a@bc";
            string error = c.Valid(FirstName, LastName, email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void EmailMaxMinusOne()
        {
            clsCustomer c = new clsCustomer();
            string email = new string('a', 49) + "@" + new string('b', 49); // 99 chars
            string error = c.Valid(FirstName, LastName, email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void EmailMaxBoundary()
        {
            clsCustomer c = new clsCustomer();
            string email = new string('a', 50) + "@" + new string('b', 49); // 100 chars
            string error = c.Valid(FirstName, LastName, email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void EmailMaxPlusOne()
        {
            clsCustomer c = new clsCustomer();
            string email = new string('a', 50) + "@" + new string('b', 50); // 101 chars
            string error = c.Valid(FirstName, LastName, email, Phone);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void EmailMid()
        {
            clsCustomer c = new clsCustomer();
            string email = new string('a', 25) + "@" + new string('b', 24); // 50 chars
            string error = c.Valid(FirstName, LastName, email, Phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void EmailExtremeMax()
        {
            clsCustomer c = new clsCustomer();
            string email = new string('a', 500) + "@" + new string('b', 499);
            string error = c.Valid(FirstName, LastName, email, Phone);
            Assert.AreNotEqual(error, "");
        }

        // Phone tests
        [TestMethod]
        public void PhoneMinBoundary()
        {
            clsCustomer c = new clsCustomer();
            string phone = "0"; // 1 char
            string error = c.Valid(FirstName, LastName, Email, phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void PhoneMinPlusOne()
        {
            clsCustomer c = new clsCustomer();
            string phone = "07";
            string error = c.Valid(FirstName, LastName, Email, phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void PhoneMaxMinusOne()
        {
            clsCustomer c = new clsCustomer();
            string phone = new string('0', 14);
            string error = c.Valid(FirstName, LastName, Email, phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void PhoneMaxBoundary()
        {
            clsCustomer c = new clsCustomer();
            string phone = new string('0', 15);
            string error = c.Valid(FirstName, LastName, Email, phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void PhoneMaxPlusOne()
        {
            clsCustomer c = new clsCustomer();
            string phone = new string('0', 16);
            string error = c.Valid(FirstName, LastName, Email, phone);
            Assert.AreNotEqual(error, "");
        }

        [TestMethod]
        public void PhoneMid()
        {
            clsCustomer c = new clsCustomer();
            string phone = new string('0', 8);
            string error = c.Valid(FirstName, LastName, Email, phone);
            Assert.AreEqual(error, "");
        }

        [TestMethod]
        public void PhoneExtremeMax()
        {
            clsCustomer c = new clsCustomer();
            string phone = new string('0', 1000);
            string error = c.Valid(FirstName, LastName, Email, phone);
            Assert.AreNotEqual(error, "");
        }
    }
}



