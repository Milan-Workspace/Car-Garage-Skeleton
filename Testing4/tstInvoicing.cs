using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing4
{
    [TestClass]
    public class tstInvoicing
    {
        // Validation Test Data
        string serviceId = "1";
        string issueDate = DateTime.Now.ToShortDateString();
        string paymentDate = DateTime.Now.ToShortDateString();
        string totalAmount = "99.99";

        // Instantiation Test
        [TestMethod]
        public void TestInvoicingInstantiation()
        {
            clsInvoicing invoicing = new clsInvoicing();

            Assert.IsNotNull(invoicing);
        }

        // Property Tests
        [TestMethod]
        public void TestInvoiceIdProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            invoicing.InvoiceId = 1;
            Assert.AreEqual(1, invoicing.InvoiceId);
        }

        [TestMethod]
        public void TestServiceIdProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            invoicing.ServiceId = 1;
            Assert.AreEqual(1, invoicing.ServiceId);
        }

        [TestMethod]
        public void TestIssueDateProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            DateTime testData = DateTime.Now.Date;
            invoicing.IssueDate = testData;
            Assert.AreEqual(testData, invoicing.IssueDate);
        }

        [TestMethod]
        public void TestPaymentDateProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            DateTime TestData = DateTime.Now.Date;
            invoicing.PaymentDate = TestData;
            Assert.AreEqual(invoicing.PaymentDate, TestData);
        }

        [TestMethod]
        public void TestIsPaidProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean TestData = true;
            invoicing.IsPaid = TestData;
            Assert.AreEqual(invoicing.IsPaid, TestData);
        }

        [TestMethod]
        public void TestTotalAmountProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            invoicing.TotalAmount = 99.99m;
            Assert.AreEqual(99.99m, invoicing.TotalAmount);
        }

        // Find Method Tests
        [TestMethod]
        public void FindMethodOK()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean Found = false;
            int InvoiceId = 1;
            Found = invoicing.Find(InvoiceId);
        }

        [TestMethod]
        public void TestInvoiceIdFound()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean Found = false;
            Boolean OK = true;
            int invoiceId = 1;
            Found = invoicing.Find(invoiceId);

            if (invoicing.InvoiceId != 1)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestServiceIdFound()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean Found = false;
            Boolean OK = true;
            int serviceId = 1;
            Found = invoicing.Find(serviceId);

            if (invoicing.ServiceId != 1)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIssueDateFound()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean Found = false;
            Boolean OK = true;
            int IssueDate = 1;
            Found = invoicing.Find(IssueDate);

            if (invoicing.IssueDate != Convert.ToDateTime("23/12/2022"))
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPaymentDateFound()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean Found = false;
            Boolean OK = true;
            int PaymentDate = 1;
            Found = invoicing.Find(PaymentDate);

            if (invoicing.PaymentDate != Convert.ToDateTime("23/12/2022"))
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIsPaidFound()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean Found = false;
            Boolean OK = true;
            int IsPaid = 1;
            Found = invoicing.Find(IsPaid);

            if (invoicing.IsPaid != true)
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestTotalAmountFound()
        {
            clsInvoicing invoicing = new clsInvoicing();
            Boolean Found = false;
            Boolean OK = true;
            int TotalAmount = 1;
            Found = invoicing.Find(TotalAmount);

            if (invoicing.TotalAmount != Convert.ToDecimal(99.99m))
            {
                OK = false;
            }

            Assert.IsTrue(OK);
        }

        // ServiceId Validation Tests

        [TestMethod]
        public void ServiceIdMinLessOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string serviceId = "0";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ServiceIdMin()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string serviceId = "1";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ServiceIdMinPlusOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string serviceId = "2";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        // IssueDate Validation Tests

        [TestMethod]
        public void IssueDateExtremeMin()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddYears(-100);
            string issueDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

       [TestMethod]
        public void IssueDateMinLessOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddDays(-1);
            string issueDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void IssueDateMin()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            string issueDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void IssueDateMinPlusOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddDays(1);
            string issueDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void IssueDateExtremeMax()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddYears(100);
            string issueDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        // PaymentDate Validation Tests

        [TestMethod]
        public void PaymentDateExtremeMin()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddYears(-100);
            string paymentDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateMinLessOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddDays(-1);
            string paymentDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateMin()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            string paymentDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateMinPlusOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddDays(1);
            string paymentDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateExtremeMax()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            DateTime TestDate;
            TestDate = DateTime.Now.Date;
            TestDate = TestDate.AddYears(100);
            string paymentDate = TestDate.ToString();
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        // TotalAmount Validation Tests

        [TestMethod]
        public void TotalAmountMinLessOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string totalAmount = "0.00";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TotalAmountMin()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string totalAmount = "0.01";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TotalAmountMinPlusOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string totalAmount = "1.01";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TotalAmountMaxLessOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string totalAmount = "498.99";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TotalAmountMax()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string totalAmount = "499.99";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TotalAmountMaxPlusOne()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string totalAmount = "500.99";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TotalAmountMid()
        {
            clsInvoicing invoicing = new clsInvoicing();
            string Error = "";
            string totalAmount = "250.50";
            Error = invoicing.Valid(serviceId, issueDate, paymentDate, totalAmount);
            Assert.AreEqual(Error, "");
        }
    }
}