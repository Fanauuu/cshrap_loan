using System;

namespace WinFormsApp1.Models
{
    public class LoanTerm
    {
        public int TID { get; set; }
        public int Term { get; set; } // Number of months
        public decimal AnnualInterestRate { get; set; } // Percentage (e.g., 12.50 for 12.5%)
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }

        // Calculated property for monthly interest rate
        public decimal MonthlyInterestRate => AnnualInterestRate / 12 / 100;

        // Display property
        public string DisplayText => $"{Term} Months - {AnnualInterestRate:F2}% APR";
    }
}
