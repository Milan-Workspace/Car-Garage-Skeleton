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
            while (Index < RecordCount)
            {
                clsInvoicing TestItem = new clsInvoicing();
                TestItem.ServiceId = Convert.ToInt32(DB.DataTable.Rows[Index]["ServiceId"]);
                TestItem.IssueDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["IssueDate"]);
                TestItem.PaymentDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["PaymentDate"]);
                TestItem.TotalAmount = Convert.ToDecimal(DB.DataTable.Rows[Index]["TotalAmount"]);
                mInvoicingList.Add(TestItem);
                Index++;
            }
        }

        List<clsInvoicing> mInvoicingList = new List<clsInvoicing>();

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
        public clsInvoicing ThisInvoice { get; set; }
    }
}