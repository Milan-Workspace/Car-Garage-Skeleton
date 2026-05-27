using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing4
{
    [TestClass]
    public class tstInvoicingCollection
    {
        [TestMethod]        
        public void InstanceOk()
        {
            clsInvoicing allInvoices = new clsInvoicing();
            Assert.IsNotNull(allInvoices);
        }

        [TestMethod]
        public void InvoicingListOK()
        {
            clsInvoicingCollection allInvoices = new clsInvoicingCollection();
            List<clsInvoicing> TestList = new List<clsInvoicing>();
            clsInvoicing TestItem = new clsInvoicing();
            TestItem.ServiceId = 1;
            TestItem.IssueDate = DateTime.Now;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.TotalAmount = 0.01m;

            TestList.Add(TestItem);
            allInvoices.InvoicingList = TestList;
            Assert.AreEqual(allInvoices.InvoicingList, TestList);
        }

        [TestMethod]
        public void ThisInvoicePropertyOK()
        {
            clsInvoicingCollection allInvoices = new clsInvoicingCollection();
            clsInvoicing TestInvoicing = new clsInvoicing();
            TestInvoicing.ServiceId = 1;
            TestInvoicing.IssueDate = DateTime.Now;
            TestInvoicing.PaymentDate = DateTime.Now;
            TestInvoicing.TotalAmount = 0.01m;
            allInvoices.ThisInvoice = TestInvoicing;
            Assert.AreEqual(allInvoices.ThisInvoice, TestInvoicing);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            clsInvoicingCollection allInvoices = new clsInvoicingCollection();
            List<clsInvoicing> TestList = new List<clsInvoicing>();
            clsInvoicing TestItem = new clsInvoicing();
            TestItem.ServiceId = 1;
            TestItem.IssueDate = DateTime.Now;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.TotalAmount = 0.01m;
            TestList.Add(TestItem);
            allInvoices.InvoicingList = TestList;
            Assert.AreEqual(allInvoices.Count, TestList.Count);
        }
    }
}
