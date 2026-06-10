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
            TestItem.InvoiceId = 1;
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
            TestInvoicing.InvoiceId = 1;
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
            TestItem.InvoiceId = 1;
            TestItem.ServiceId = 1;
            TestItem.IssueDate = DateTime.Now;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.TotalAmount = 0.01m;
            TestList.Add(TestItem);
            allInvoices.InvoicingList = TestList;
            Assert.AreEqual(allInvoices.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            clsInvoicingCollection allInvoices = new clsInvoicingCollection();
            clsInvoicing TestItem = new clsInvoicing();
            Int32 PrimaryKey = 0;
            TestItem.InvoiceId = 1;
            TestItem.ServiceId = 1;
            TestItem.IssueDate = DateTime.Now;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.IsPaid = true;
            TestItem.TotalAmount = 499.99m;

            allInvoices.ThisInvoice = TestItem;
            PrimaryKey = allInvoices.Add();
            TestItem.InvoiceId = PrimaryKey;
            allInvoices.ThisInvoice.Find(PrimaryKey);
            Assert.AreEqual(allInvoices.ThisInvoice, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            clsInvoicingCollection allInvoices = new clsInvoicingCollection();
            clsInvoicing TestItem = new clsInvoicing();
            Int32 PrimaryKey = 0;
            TestItem.ServiceId = 1;
            TestItem.IssueDate = DateTime.Now;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.IsPaid = true;
            TestItem.TotalAmount = 499.99m;
            allInvoices.ThisInvoice = TestItem;
            TestItem.InvoiceId = PrimaryKey;

            TestItem.ServiceId = 3;
            TestItem.IssueDate = DateTime.Now;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.IsPaid = false;
            TestItem.TotalAmount = 250.49m;
            allInvoices.ThisInvoice = TestItem;

            allInvoices.Update();
            allInvoices.ThisInvoice.Find(PrimaryKey);
            Assert.AreEqual(allInvoices.ThisInvoice, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            clsInvoicingCollection allInvoices = new clsInvoicingCollection();
            clsInvoicing TestItem = new clsInvoicing();

            Int32 PrimaryKey = 0;
            TestItem.InvoiceId = 1;
            TestItem.ServiceId = 1;
            TestItem.IssueDate = DateTime.Now;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.TotalAmount = 249.50m;
            TestItem.IsPaid = true;

            allInvoices.ThisInvoice = TestItem;
            PrimaryKey = allInvoices.Add();

            allInvoices.ThisInvoice.Find(PrimaryKey);
            allInvoices.Delete();

            Boolean Found = allInvoices.ThisInvoice.Find(PrimaryKey);
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByTotalAmountOK()
        {
            clsInvoicingCollection allInvoices = new clsInvoicingCollection();
            clsInvoicingCollection FilteredTotalAmounts = new clsInvoicingCollection();
            FilteredTotalAmounts.ReportByTotalAmount("");
            Assert.AreEqual(allInvoices.Count, FilteredTotalAmounts.Count);
        }

        [TestMethod]
        public void ReportByTotalAmountNoneFound()
        {
            clsInvoicingCollection FilteredTotalAmounts = new clsInvoicingCollection();
            FilteredTotalAmounts.ReportByTotalAmount("xxx xxx");
            Assert.AreEqual(0, FilteredTotalAmounts.Count);
        }
    }
}
