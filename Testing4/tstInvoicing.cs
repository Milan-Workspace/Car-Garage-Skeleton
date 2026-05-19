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
        public void TestTotalAmountProperty()
        {
            clsInvoicing invoicing = new clsInvoicing();
            invoicing.TotalAmount = 99.99m;
            Assert.AreEqual(99.99m, invoicing.TotalAmount);
        }
    }
}