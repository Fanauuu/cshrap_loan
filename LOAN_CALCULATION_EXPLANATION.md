# Loan Calculation Explanation

## Overview
This document explains how the loan calculation logic works in the Loan Management System. The system uses **standard amortization formulas** commonly used in banking and microfinance institutions.

---

## Loan Amortization Formula

### Monthly Payment Calculation

The monthly payment is calculated using the standard amortization formula:

```
Monthly Payment = P × [r(1+r)^n] / [(1+r)^n - 1]
```

**Where:**
- **P** = Principal (Loan Amount)
- **r** = Monthly Interest Rate (Annual Rate ÷ 12 ÷ 100)
- **n** = Number of Payments (Term in months)

### Example Calculation

For a loan of **$10,000** at **12% annual interest** for **12 months**:

1. **Monthly Interest Rate (r):**
   - Annual Rate: 12%
   - Monthly Rate: 12% ÷ 12 = 1% = 0.01 (as decimal)

2. **Calculate (1+r)^n:**
   - (1 + 0.01)^12 = 1.126825...

3. **Calculate Monthly Payment:**
   - Monthly Payment = 10,000 × [0.01 × 1.126825] / [1.126825 - 1]
   - Monthly Payment = 10,000 × [0.01126825] / [0.126825]
   - Monthly Payment = 10,000 × 0.088848...
   - **Monthly Payment = $888.49**

---

## Repayment Schedule Generation

For each payment period, the system calculates:

### 1. Interest Payment
```
Interest Payment = Remaining Balance × Monthly Interest Rate
```

### 2. Principal Payment
```
Principal Payment = Monthly Payment - Interest Payment
```

### 3. New Remaining Balance
```
New Balance = Previous Balance - Principal Payment
```

### Example Schedule (First 3 Payments)

**Loan:** $10,000 at 12% APR for 12 months  
**Monthly Payment:** $888.49

| Payment # | Due Date | Monthly Payment | Principal | Interest | Remaining Balance |
|-----------|-----------|-----------------|-----------|----------|-------------------|
| 1 | Month 1 | $888.49 | $788.49 | $100.00 | $9,211.51 |
| 2 | Month 2 | $888.49 | $796.37 | $92.12 | $8,415.14 |
| 3 | Month 3 | $888.49 | $804.33 | $84.16 | $7,610.81 |
| ... | ... | ... | ... | ... | ... |
| 12 | Month 12 | $888.49 | $879.69 | $8.80 | $0.00 |

**Note:** The last payment is adjusted to ensure the remaining balance becomes exactly $0.00.

---

## Key Features

### 1. **Accurate Interest Calculation**
- Interest is calculated on the **remaining balance** each month
- As the principal decreases, interest payments decrease
- Principal payments increase over time

### 2. **Balance Reduction**
- Each payment reduces the principal balance
- The system ensures the balance reaches exactly $0.00 at the end

### 3. **Service Payment Handling**
- Service fees are added to the initial loan balance
- The repayment schedule includes the service fee in calculations

### 4. **Payment Status Tracking**
- **Paid:** Payment received on or before due date
- **Unpaid:** Payment not yet received
- **Late:** Payment overdue (due date has passed)

---

## Business Rules

### Payment Validation
- Payments can only be processed if loan status is **"Active"**
- Cannot make payments on "Closed" or "Default" loans

### Overdue Detection
- System automatically marks payments as "Late" when due date passes
- Overdue payments are highlighted in red in the UI

### Schedule Generation
- Schedule is automatically generated when a loan contract is created
- Each payment period is calculated based on the start payment date
- Schedule cannot be modified once generated (for data integrity)

---

## Implementation Details

### Code Location
The loan calculation logic is implemented in:
- **`services/LoanCalculationService.cs`**

### Key Methods

1. **`CalculateMonthlyPayment()`**
   - Calculates the fixed monthly payment amount
   - Uses the amortization formula

2. **`GenerateRepaymentSchedule()`**
   - Creates the complete repayment schedule
   - Calculates principal, interest, and balance for each period

3. **`UpdateOverdueStatus()`**
   - Updates payment status to "Late" for overdue payments
   - Called when viewing schedules

---

## Testing the Calculations

### Test Case 1: Standard Loan
- **Loan Amount:** $10,000
- **Annual Rate:** 12%
- **Term:** 12 months
- **Expected Monthly Payment:** ~$888.49
- **Total Interest:** ~$661.88

### Test Case 2: Long Term Loan
- **Loan Amount:** $50,000
- **Annual Rate:** 10%
- **Term:** 60 months
- **Expected Monthly Payment:** ~$1,062.35
- **Total Interest:** ~$13,741.00

### Verification
You can verify calculations using online loan calculators or Excel's PMT function:
```
=PMT(AnnualRate/12, TermMonths, LoanAmount)
```

---

## Financial Accuracy

This system follows **real-world banking practices**:
- ✅ Uses standard amortization formula
- ✅ Calculates interest on declining balance
- ✅ Ensures balance reaches zero
- ✅ Handles service fees correctly
- ✅ Tracks payment status accurately

The calculations are suitable for use in actual microfinance or banking operations.

---

## Notes

- All monetary values are rounded to 2 decimal places
- Interest rates are stored as percentages (e.g., 12.50 for 12.5%)
- Monthly rates are calculated from annual rates
- The system prevents floating-point precision errors through proper rounding
