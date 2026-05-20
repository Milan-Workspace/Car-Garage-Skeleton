using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing4
{
    [TestClass]
    public class tstInvoicing
    {
        [TestMethod]
        public void TestInvoicingInstantiation()
        {
            clsInvoicing invoicing = new clsInvoicing();

            Assert.IsNotNull(invoicing);
        }

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
            DateTime testData = DateTime.Now.Date;
            invoicing.PaymentDate = testData;
            Assert.AreEqual(testData, invoicing.PaymentDate);
        }

        [TestMethod]
        public void TestIsPaidProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            invoicing.IsPaid = true;
            Assert.IsTrue(invoicing.IsPaid);
        }

        [TestMethod]
        public void TestTotalAmountProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            invoicing.TotalAmount = 99.99m;
            Assert.AreEqual(99.99m, invoicing.TotalAmount);
        }
    }
}