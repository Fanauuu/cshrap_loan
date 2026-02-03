using System;
using System.Collections.Generic;
using WinFormsApp1.Models;

namespace WinFormsApp1.services
{
    /// <summary>
    /// Loan Calculation Service
    /// Implements standard loan amortization calculations used in banking and microfinance
    /// 
    /// Formula Explanation:
    /// Monthly Payment = P * [r(1+r)^n] / [(1+r)^n - 1]
    /// Where:
    ///   P = Principal (Loan Amount)
    ///   r = Monthly Interest Rate (Annual Rate / 12 / 100)
    ///   n = Number of Payments (Term in months)
    /// 
    /// For each payment:
    ///   Interest Payment = Remaining Balance * Monthly Interest Rate
    ///   Principal Payment = Monthly Payment - Interest Payment
    ///   New Balance = Previous Balance - Principal Payment
    /// </summary>
    public class LoanCalculationService
    {
        /// <summary>
        /// Calculates the monthly payment amount using standard amortization formula
        /// </summary>
        public decimal CalculateMonthlyPayment(decimal loanAmount, decimal annualInterestRate, int termMonths)
        {
            if (loanAmount <= 0 || termMonths <= 0)
                return 0;

            // If interest rate is 0, simple division
            if (annualInterestRate == 0)
            {
                return loanAmount / termMonths;
            }

            // Convert annual rate to monthly rate (as decimal, not percentage)
            decimal monthlyRate = annualInterestRate / 12 / 100;

            // Calculate (1 + r)^n
            double monthlyRateDouble = (double)monthlyRate;
            double onePlusRate = 1 + monthlyRateDouble;
            double powerTerm = Math.Pow(onePlusRate, termMonths);

            // Calculate monthly payment: P * [r(1+r)^n] / [(1+r)^n - 1]
            double monthlyPayment = (double)loanAmount * (monthlyRateDouble * powerTerm) / (powerTerm - 1);

            return Math.Round((decimal)monthlyPayment, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calculates monthly interest rate from annual interest rate
        /// </summary>
        public decimal CalculateMonthlyInterestRate(decimal annualInterestRate)
        {
            return Math.Round(annualInterestRate / 12, 4, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Generates complete repayment schedule for a loan contract
        /// </summary>
        public List<LoanRepaymentSchedule> GenerateRepaymentSchedule(
            int lc,
            int cid,
            decimal loanAmount,
            decimal annualInterestRate,
            int termMonths,
            DateTime startPaymentDate,
            decimal servicePayment = 0)
        {
            List<LoanRepaymentSchedule> schedule = new List<LoanRepaymentSchedule>();

            if (loanAmount <= 0 || termMonths <= 0)
                return schedule;

            // Calculate monthly payment
            decimal monthlyPayment = CalculateMonthlyPayment(loanAmount, annualInterestRate, termMonths);
            
            // Monthly interest rate as decimal (e.g., 0.01 for 1%)
            decimal monthlyRate = annualInterestRate / 12 / 100;

            // Starting balance includes service payment (if any)
            decimal remainingBalance = loanAmount + servicePayment;

            // Generate schedule for each month
            for (int i = 0; i < termMonths; i++)
            {
                DateTime dueDate = startPaymentDate.AddMonths(i);
                DateTime paymentDate = dueDate; // Default payment date same as due date

                // Calculate interest for this period
                decimal interestPayment = Math.Round(remainingBalance * monthlyRate, 2, MidpointRounding.AwayFromZero);

                // Calculate principal payment
                decimal principalPayment;
                
                if (i == termMonths - 1)
                {
                    // Last payment: adjust to pay off remaining balance exactly
                    principalPayment = remainingBalance - interestPayment;
                    monthlyPayment = principalPayment + interestPayment;
                }
                else
                {
                    principalPayment = monthlyPayment - interestPayment;
                }

                // Ensure principal doesn't exceed remaining balance
                if (principalPayment > remainingBalance)
                {
                    principalPayment = remainingBalance;
                    monthlyPayment = principalPayment + interestPayment;
                }

                // Update remaining balance
                remainingBalance = Math.Max(0, remainingBalance - principalPayment);

                // Round to 2 decimal places to avoid floating point issues
                remainingBalance = Math.Round(remainingBalance, 2, MidpointRounding.AwayFromZero);
                principalPayment = Math.Round(principalPayment, 2, MidpointRounding.AwayFromZero);
                interestPayment = Math.Round(interestPayment, 2, MidpointRounding.AwayFromZero);

                schedule.Add(new LoanRepaymentSchedule
                {
                    LC = lc,
                    CID = cid,
                    PaymentDate = paymentDate,
                    DueDate = dueDate,
                    MonthlyPayment = monthlyPayment,
                    Principal = principalPayment,
                    Interest = interestPayment,
                    RemainingBalance = remainingBalance,
                    Action = "Unpaid"
                });
            }

            return schedule;
        }

        /// <summary>
        /// Calculates total interest to be paid over the loan term
        /// </summary>
        public decimal CalculateTotalInterest(decimal loanAmount, decimal annualInterestRate, int termMonths)
        {
            decimal monthlyPayment = CalculateMonthlyPayment(loanAmount, annualInterestRate, termMonths);
            decimal totalPayments = monthlyPayment * termMonths;
            return totalPayments - loanAmount;
        }

        /// <summary>
        /// Calculates total amount to be repaid (principal + interest)
        /// </summary>
        public decimal CalculateTotalRepayment(decimal loanAmount, decimal annualInterestRate, int termMonths)
        {
            decimal monthlyPayment = CalculateMonthlyPayment(loanAmount, annualInterestRate, termMonths);
            return monthlyPayment * termMonths;
        }

        /// <summary>
        /// Validates if a payment can be made (loan must be Active)
        /// </summary>
        public bool CanMakePayment(string loanStatus)
        {
            return loanStatus == "Active";
        }

        /// <summary>
        /// Updates overdue payments status
        /// </summary>
        public void UpdateOverdueStatus(List<LoanRepaymentSchedule> schedules)
        {
            DateTime today = DateTime.Today;
            foreach (var schedule in schedules)
            {
                if (schedule.Action == "Unpaid" && schedule.DueDate < today)
                {
                    schedule.Action = "Late";
                }
            }
        }
    }
}
