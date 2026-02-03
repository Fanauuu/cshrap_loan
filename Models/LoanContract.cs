using System;

namespace WinFormsApp1.Models
{
    public class LoanContract
    {
        public int LC { get; set; }
        public int CID { get; set; }
        public decimal LoanAmount { get; set; }
        public int TermID { get; set; }
        public decimal MonthlyInterest { get; set; } // Monthly interest rate percentage
        public DateTime LoanDate { get; set; }
        public DateTime StartPaymentDate { get; set; }
        public decimal ServicePayment { get; set; } // Service fee
        public string Status { get; set; } = "Active";
        public string ScheduleStatus { get; set; } = "Pending";
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        // Navigation properties (for display purposes)
        public string? CustomerName { get; set; }
        public string? TermDescription { get; set; }
        public int? TermMonths { get; set; }
    }
}
