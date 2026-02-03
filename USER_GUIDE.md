# Loan Management System - User Guide

## 📋 Table of Contents
1. [Initial Setup](#initial-setup)
2. [Login](#login)
3. [Customer Management](#customer-management)
4. [Loan Term Management](#loan-term-management)
5. [Loan Contract Management](#loan-contract-management)
6. [Repayment Schedule](#repayment-schedule)
7. [Complete Workflow Example](#complete-workflow-example)

---

## 🚀 Initial Setup

### Step 1: Create the Database
1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server instance
3. Open and execute **`DatabaseScript.sql`** first (creates Users table)
4. Then execute **`LoanManagementSchema.sql`** (creates Loan Management tables)
5. Verify the database `cshrap` is created with all tables

### Step 2: Build and Run the Application
1. Open the project in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

---

## 🔐 Login

### Default Credentials
- **Username:** `admin`
- **Password:** `admin123`

### Login Steps
1. Enter username: `admin`
2. Enter password: `admin123`
3. Click **Login** or press Enter
4. You'll see the Main Dashboard

---

## 👤 Customer Management

### Adding a New Customer
1. From Main Dashboard, click **"👤 Customer Management"**
2. Click **"➕ Add"** button
3. Fill in the form:
   - **First Name:** (Required)
   - **Last Name:** (Required)
   - **Gender:** Select from dropdown (Male/Female/Other)
   - **Place of Birth:** (Optional)
   - **Date of Birth:** Select date (must be at least 18 years old)
   - **Current Address:** (Required)
   - **Status:** Active/Inactive (default: Active)
4. Click **"Save"**
5. Customer will appear in the list

### Editing a Customer
1. Double-click a customer row OR select and click **"✏️ Edit"**
2. Modify the fields
3. Click **"Save"**

### Deleting a Customer
1. Select a customer from the list
2. Click **"🗑️ Delete"**
3. Confirm deletion

**Note:** Only Active customers can be selected when creating loan contracts.

---

## 📅 Loan Term Management

### Adding a Loan Term
1. From Main Dashboard, click **"📅 Loan Terms"**
2. Click **"➕ Add"** button
3. Fill in:
   - **Term (Months):** e.g., 12, 24, 36
   - **Annual Rate (%):** e.g., 12.00 for 12%
   - **Description:** Optional description
   - **Is Active:** Checkbox (default: checked)
4. The **Monthly Rate** will be calculated automatically
5. Click **"Save"**

### Default Loan Terms
The system comes with pre-loaded terms:
- 6 months @ 12.00% APR
- 12 months @ 11.50% APR
- 24 months @ 11.00% APR
- 36 months @ 10.50% APR
- 48 months @ 10.00% APR
- 60 months @ 9.50% APR

### Editing/Deleting Loan Terms
- Select a term and click **"✏️ Edit"** or **"🗑️ Delete"**

---

## 📋 Loan Contract Management

### Creating a New Loan Contract

**This is the main workflow for issuing loans:**

1. From Main Dashboard, click **"📋 Loan Contracts"**
2. Click **"➕ New Contract"** button
3. Fill in the loan contract form:

   **Customer Selection:**
   - Select a customer from the dropdown (only Active customers shown)
   
   **Loan Details:**
   - **Loan Amount:** Enter the principal amount (e.g., 10000)
   - **Loan Term:** Select from available terms
   - **Monthly Rate:** Automatically calculated (read-only)
   - **Monthly Payment:** Automatically calculated and displayed
   
   **Dates:**
   - **Loan Date:** Date the loan is issued (default: today)
   - **Start Payment Date:** First payment due date (default: next month)
   
   **Additional:**
   - **Service Payment:** Optional service fee (default: 0)
   - **Status:** Active/Closed/Default (default: Active)

4. Click **"Save"**
5. The system will:
   - Create the loan contract
   - **Automatically generate the repayment schedule**
   - Set status to "Active"
   - Set schedule status to "Generated"

### Viewing Loan Contracts
- All contracts are displayed in a table
- Shows: Contract ID, Customer Name, Loan Amount, Term, Status, etc.
- Click **"🔄 Refresh"** to update the list

### Viewing Repayment Schedule
1. Select a loan contract from the list
2. Click **"💰 View Schedule"**
3. See the complete repayment schedule with all payment details

---

## 💰 Repayment Schedule

### Viewing Schedule
1. From Loan Contract Management, select a contract and click **"💰 View Schedule"**
   OR
2. From Main Dashboard, click **"💰 Repayment Schedule"** (shows all schedules)

### Understanding the Schedule
The schedule shows:
- **Due Date:** When payment is due
- **Monthly Payment:** Total payment amount
- **Principal:** Amount going toward loan balance
- **Interest:** Interest portion
- **Remaining Balance:** Balance after this payment
- **Status:** Paid/Unpaid/Late

### Marking Payments as Paid
1. Select a payment row (must be Unpaid)
2. Click **"✅ Mark as Paid"**
3. Confirm the action
4. The payment status changes to "Paid"
5. The actual payment date is recorded

**Important Rules:**
- Only Active loans can receive payments
- Cannot mark payments as paid for Closed or Default loans
- Overdue payments are automatically marked as "Late"

### Payment Status Colors
- **Green (Paid):** Payment received
- **Red (Late):** Payment overdue
- **Black (Unpaid):** Payment pending

---

## 📊 Complete Workflow Example

### Example: Issuing a $10,000 Loan

**Step 1: Add Customer (if not exists)**
1. Customer Management → Add
2. Name: John Doe
3. Gender: Male
4. DOB: 01/01/1990
5. Address: 123 Main St
6. Save

**Step 2: Create Loan Contract**
1. Loan Contracts → New Contract
2. Customer: Select "John Doe"
3. Loan Amount: 10000
4. Loan Term: Select "12 Months - 11.50% APR"
5. Notice: Monthly Payment shows automatically (e.g., $884.88)
6. Loan Date: Today
7. Start Payment Date: Next month
8. Service Payment: 0 (or add fee if needed)
9. Save

**Step 3: View Generated Schedule**
1. Select the contract
2. Click "View Schedule"
3. See 12 monthly payments:
   - Payment 1: $884.88 (Principal: $789.21, Interest: $95.67)
   - Payment 2: $884.88 (Principal: $796.77, Interest: $88.11)
   - ... and so on
   - Payment 12: Final payment (adjusted to pay off exactly)

**Step 4: Record Payments**
1. When customer makes payment, select the payment row
2. Click "Mark as Paid"
3. Status changes to "Paid"
4. Continue for each payment

**Step 5: Monitor Overdue Payments**
- Payments past due date automatically show as "Late" (red)
- System tracks days overdue

---

## 🎯 Key Features

### ✅ Automatic Calculations
- Monthly payment calculated automatically
- Principal and interest split calculated
- Remaining balance tracked
- Last payment adjusted to zero balance

### ✅ Business Rules Enforced
- Only Active customers can get loans
- Only Active loans can receive payments
- Cannot delete customers with active loans
- Overdue payments automatically marked

### ✅ Data Integrity
- Foreign key relationships enforced
- Parameterized queries (SQL injection protected)
- Transaction support for schedule generation

### ✅ User-Friendly Interface
- Clean, professional UI
- Color-coded status indicators
- Real-time calculations
- Validation messages

---

## 🔍 Tips & Best Practices

1. **Always verify calculations** before saving loan contracts
2. **Check customer status** before issuing loans (must be Active)
3. **Review repayment schedule** after contract creation
4. **Mark payments promptly** to keep records accurate
5. **Use Refresh button** to see latest data
6. **Service fees** are added to the initial balance

---

## ❓ Troubleshooting

### "No customers available" error
- Make sure you have Active customers in the system
- Check Customer Management → ensure Status is "Active"

### "Cannot mark payment as paid"
- Verify loan status is "Active"
- Check if payment is already marked as "Paid"

### Schedule not generating
- Ensure loan contract was saved successfully
- Check database connection
- Verify loan term is Active

### Monthly payment shows $0
- Select a loan term from dropdown
- Enter a loan amount > 0
- Calculation updates automatically

---

## 📞 Support

For issues or questions:
1. Check the error messages (they're descriptive)
2. Verify database connection in App.config
3. Ensure all SQL scripts were executed successfully
4. Check that all required fields are filled

---

## 🎓 Learning the System

**Recommended Learning Path:**
1. Start with Customer Management (simplest)
2. Then Loan Term Management (pre-configured)
3. Create a test loan contract
4. View and understand the repayment schedule
5. Practice marking payments
6. Explore all features

**Test with Sample Data:**
- Create test customers
- Issue small test loans ($1000)
- Mark payments to see balance reduction
- Close loans to see status changes

---

**Happy Loan Managing! 🎉**
