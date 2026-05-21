using System;

namespace ClassLibrary
{
    public class clsInvoicing
    {
        private int mInvoiceId;
        private int mServiceId;
        public DateTime mIssueDate;
        public DateTime mPaymentDate;
        public Boolean mIsPaid;
        public decimal mTotalAmount;

        public int InvoiceId
        {
            get
            {
                return mInvoiceId;
            }
            set
            {
                mInvoiceId = value;
            }
        }

        public int ServiceId
        {
            get
            {
                return mServiceId;
            }
            set
            {
                mServiceId = value;
            }
        }

        public DateTime IssueDate
        {
            get
            {
                return mIssueDate;
            }
            set
            {
                mIssueDate = value;
            }
        }

        public DateTime PaymentDate
        {
            get
            {
                return mPaymentDate;
            }
            set
            {
                mPaymentDate = value;
            }
        }

        public bool IsPaid
        {
            get
            {
                return mIsPaid;
            }
            set
            {
                mIsPaid = value;
            }
        }
        public decimal TotalAmount
        {
            get
            {
                return (decimal)mTotalAmount;
            }
            set
            {
                mTotalAmount = value;
            }
        }

        public bool Find(int InvoiceId)
        {
            mInvoiceId = 1;
            mServiceId = 1;
            mIssueDate = Convert.ToDateTime("23/12/2022");
            mPaymentDate = Convert.ToDateTime("23/12/2022");
            mIsPaid = true;
            mTotalAmount = Convert.ToDecimal(99.99m);
            return true;
        }
    }
}