using System;

namespace WinFormsApp1.Models
{
    public class LoanRepaymentSchedule
    {
        public int ScheduleID { get; set; }
        public int LC { get; set; }
        public int CID { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal RemainingBalance { get; set; }
        public string Action { get; set; } = "Unpaid"; // Paid, Unpaid, Late
        public DateTime? PaymentDateActual { get; set; }
        public DateTime CreatedDate { get; set; }

        // Calculated properties
        public bool IsOverdue => Action == "Unpaid" && DueDate < DateTime.Today;
        public int DaysOverdue => IsOverdue ? (DateTime.Today - DueDate).Days : 0;
    }
}
