using System;
using System.Collections.Generic;
using System.IO;

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

        public List<clsInvoicing> InvoicingList { get; set; }

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

        public string InvoiceSummary
        {
            get
            {
                return "ID:" + InvoiceId + " - Amount: " + TotalAmount;
            }
        }

        public string Valid(string serviceId,
            string issueDate,
            string paymentDate,
            string totalAmount)
        {
            string Error = "";
            DateTime DateTemp;
            DateTime DateComp = DateTime.Now.Date;
            decimal AmountTemp;
            int IdTemp;

            if (serviceId == "")
            {
                Error = Error + "The serviceId may not be blank : ";
            }
            else
            {
                if (!int.TryParse(serviceId, out IdTemp))
                {
                    Error = Error + "The serviceId must be a valid integer : ";
                }
                else
                {

                    if (IdTemp < 1)
                    {
                        Error = Error + "The serviceId cannot be less than 1 :";
                    }

                    if (IdTemp > 10)
                    {
                        Error = Error + "The serviceId cannot be more than 10 : ";
                    }
                }
            }

                try
                {
                    // Issue Date
                    DateTemp = Convert.ToDateTime(issueDate);

                    if (DateTemp < DateComp)
                    {
                        Error = Error + "The issueDate cannot be in the past : ";
                    }

                    if (DateTemp > DateComp)
                    {
                        Error = Error + "The issueDate cannot be in the future : ";
                    }

                    // Payment Date
                    DateTemp = Convert.ToDateTime(paymentDate);
                    if (DateTemp < DateComp)
                    {
                        Error = Error + "The paymentDate may not be in the past : ";
                    }

                    if (DateTemp > DateComp)
                    {
                        Error = Error + "The paymentDate cannot be in the future : ";
                    }
                }

                catch
                {
                    Error = Error + "The date was not a valid date : ";
                }


            if (totalAmount == "")
            {
                Error = Error + "The totalAmount may not be blank : ";
            }
            else
            {
                if (!decimal.TryParse(totalAmount, out AmountTemp))
                {
                    Error = Error + "The totalAmount must be a valid decimal : ";
                }

                else
                {
                    if (AmountTemp < 0.01m)
                    {
                        Error = Error + "The totalAmount cannot be less than 0.01 : ";
                    }

                    if (AmountTemp > 499.99m)
                    {
                        Error = Error + "The totalAmount cannot be more than 499.99 : ";
                    }
                }
            }

            return Error;
        }
    }
}