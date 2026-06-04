using System;
using System.Collections.Generic;
using System.Configuration;

namespace ClassLibrary
{
    public class clsInvoicingCollection
    {

        public clsInvoicingCollection() 
        {
            Int32 Index = 0;
            Int32 RecordCount = 0;
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("dbo.usp_SelectAllInvoices");
            RecordCount = DB.Count;

            // Debugging
            System.Diagnostics.Debug.WriteLine("RecordCount = " + RecordCount);

            while (Index < RecordCount)
            {
                clsInvoicing TestItem = new clsInvoicing();
                TestItem.InvoiceId = Convert.ToInt32(DB.DataTable.Rows[Index]["InvoiceId"]);
                TestItem.ServiceId = Convert.ToInt32(DB.DataTable.Rows[Index]["ServiceId"]);
                TestItem.IssueDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["IssueDate"]);
                TestItem.PaymentDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["PaymentDate"]);
                TestItem.TotalAmount = Convert.ToDecimal(DB.DataTable.Rows[Index]["TotalAmount"]);
                mInvoicingList.Add(TestItem);
                Index++;
            }
        }

        List<clsInvoicing> mInvoicingList = new List<clsInvoicing>();
        clsInvoicing mThisInvoice = new clsInvoicing();

        public List<clsInvoicing> InvoicingList
        {
            get
            {
                return mInvoicingList;
            }
            set
            {
                mInvoicingList = value;
            }
        }
        public int Count
        {
            get
            {
                return mInvoicingList.Count;
            }
            set
            {
                //
            }
        }
        public clsInvoicing ThisInvoice
        {
            get
            {
                return mThisInvoice;
            }
            set
            {
                mThisInvoice = value;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ServiceId", mThisInvoice.ServiceId);
            DB.AddParameter("@IssueDate", mThisInvoice.IssueDate);
            DB.AddParameter("@PaymentDate", mThisInvoice.PaymentDate);
            DB.AddParameter("@IsPaid", mThisInvoice.IsPaid);
            DB.AddParameter("@TotalAmount", mThisInvoice.TotalAmount);

            return DB.Execute("dbo.usp_InsertInvoice");
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@InvoiceId", mThisInvoice.InvoiceId);
            DB.AddParameter("@ServiceId", mThisInvoice.ServiceId);
            DB.AddParameter("@IssueDate", mThisInvoice.IssueDate);
            DB.AddParameter("@PaymentDate", mThisInvoice.PaymentDate);
            DB.AddParameter("@IsPaid", mThisInvoice.IsPaid);
            DB.AddParameter("@TotalAmount", mThisInvoice.TotalAmount);

            DB.Execute("dbo.usp_UpdateInvoice");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@InvoiceId", mThisInvoice.InvoiceId);
            DB.Execute("dbo.usp_DeleteInvoice");
        }

        public void ReportByTotalAmount(string v)
        {
            
        }
    }
}