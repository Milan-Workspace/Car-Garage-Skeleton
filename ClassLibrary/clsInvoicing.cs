using System;

namespace ClassLibrary
{
    public class clsInvoicing
    {
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDate {  get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalAmount { get; set; }
    }
}