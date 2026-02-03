-- =============================================
-- Loan Management System Database Schema
-- =============================================
-- This script extends the existing database with loan management tables
-- Run this after the main DatabaseScript.sql

USE cshrap;
GO

-- =============================================
-- 1. CUSTOMERS TABLE
-- =============================================
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Customers;
END
GO

CREATE TABLE Customers (
    CID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    PlaceOfBirth NVARCHAR(100) NULL,
    DateOfBirth DATE NOT NULL,
    CurrentAddress NVARCHAR(500) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    LastModifiedDate DATETIME NULL,
    
    CONSTRAINT CK_Gender CHECK (Gender IN ('Male', 'Female', 'Other')),
    CONSTRAINT CK_CustomerStatus CHECK (Status IN ('Active', 'Inactive'))
);
GO

CREATE INDEX IX_Customers_Status ON Customers(Status);
CREATE INDEX IX_Customers_Name ON Customers(LastName, FirstName);
GO

-- =============================================
-- 2. LOAN TERMS TABLE
-- =============================================
IF OBJECT_ID('dbo.LoanTerms', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.LoanTerms;
END
GO

CREATE TABLE LoanTerms (
    TID INT IDENTITY(1,1) PRIMARY KEY,
    Term INT NOT NULL, -- Number of months
    AnnualInterestRate DECIMAL(5,2) NOT NULL, -- Percentage (e.g., 12.50 for 12.5%)
    Description NVARCHAR(200) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    
    CONSTRAINT CK_Term CHECK (Term > 0),
    CONSTRAINT CK_InterestRate CHECK (AnnualInterestRate >= 0 AND AnnualInterestRate <= 100)
);
GO

CREATE INDEX IX_LoanTerms_IsActive ON LoanTerms(IsActive);
GO

-- Insert default loan terms
INSERT INTO LoanTerms (Term, AnnualInterestRate, Description, IsActive)
VALUES 
    (6, 12.00, '6 Months - Standard Rate', 1),
    (12, 11.50, '12 Months - Standard Rate', 1),
    (24, 11.00, '24 Months - Standard Rate', 1),
    (36, 10.50, '36 Months - Standard Rate', 1),
    (48, 10.00, '48 Months - Standard Rate', 1),
    (60, 9.50, '60 Months - Standard Rate', 1);
GO

-- =============================================
-- 3. LOAN CONTRACTS TABLE
-- =============================================
IF OBJECT_ID('dbo.LoanContracts', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.LoanContracts;
END
GO

CREATE TABLE LoanContracts (
    LC INT IDENTITY(1,1) PRIMARY KEY,
    CID INT NOT NULL,
    LoanAmount DECIMAL(18,2) NOT NULL,
    TermID INT NOT NULL,
    MonthlyInterest DECIMAL(5,2) NOT NULL, -- Calculated monthly interest rate
    LoanDate DATE NOT NULL DEFAULT GETDATE(),
    StartPaymentDate DATE NOT NULL,
    ServicePayment DECIMAL(18,2) NOT NULL DEFAULT 0, -- Service fee
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    ScheduleStatus NVARCHAR(20) NOT NULL DEFAULT 'Pending', -- Pending, Generated, Completed
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    LastModifiedDate DATETIME NULL,
    
    CONSTRAINT FK_LoanContract_Customer FOREIGN KEY (CID) REFERENCES Customers(CID),
    CONSTRAINT FK_LoanContract_Term FOREIGN KEY (TermID) REFERENCES LoanTerms(TID),
    CONSTRAINT CK_LoanAmount CHECK (LoanAmount > 0),
    CONSTRAINT CK_ServicePayment CHECK (ServicePayment >= 0),
    CONSTRAINT CK_LoanStatus CHECK (Status IN ('Active', 'Closed', 'Default')),
    CONSTRAINT CK_ScheduleStatus CHECK (ScheduleStatus IN ('Pending', 'Generated', 'Completed'))
);
GO

CREATE INDEX IX_LoanContracts_CID ON LoanContracts(CID);
CREATE INDEX IX_LoanContracts_TermID ON LoanContracts(TermID);
CREATE INDEX IX_LoanContracts_Status ON LoanContracts(Status);
CREATE INDEX IX_LoanContracts_LoanDate ON LoanContracts(LoanDate);
GO

-- =============================================
-- 4. LOAN REPAYMENT SCHEDULES TABLE
-- =============================================
IF OBJECT_ID('dbo.LoanRepaymentSchedules', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.LoanRepaymentSchedules;
END
GO

CREATE TABLE LoanRepaymentSchedules (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    LC INT NOT NULL,
    CID INT NOT NULL,
    PaymentDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    MonthlyPayment DECIMAL(18,2) NOT NULL,
    Principal DECIMAL(18,2) NOT NULL,
    Interest DECIMAL(18,2) NOT NULL,
    RemainingBalance DECIMAL(18,2) NOT NULL,
    Action NVARCHAR(20) NOT NULL DEFAULT 'Unpaid', -- Paid, Unpaid, Late
    PaymentDateActual DATE NULL, -- Actual payment date if paid
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    
    CONSTRAINT FK_Schedule_LoanContract FOREIGN KEY (LC) REFERENCES LoanContracts(LC) ON DELETE CASCADE,
    CONSTRAINT FK_Schedule_Customer FOREIGN KEY (CID) REFERENCES Customers(CID),
    CONSTRAINT CK_MonthlyPayment CHECK (MonthlyPayment > 0),
    CONSTRAINT CK_Principal CHECK (Principal >= 0),
    CONSTRAINT CK_Interest CHECK (Interest >= 0),
    CONSTRAINT CK_RemainingBalance CHECK (RemainingBalance >= 0),
    CONSTRAINT CK_ScheduleAction CHECK (Action IN ('Paid', 'Unpaid', 'Late'))
);
GO

CREATE INDEX IX_Schedules_LC ON LoanRepaymentSchedules(LC);
CREATE INDEX IX_Schedules_CID ON LoanRepaymentSchedules(CID);
CREATE INDEX IX_Schedules_DueDate ON LoanRepaymentSchedules(DueDate);
CREATE INDEX IX_Schedules_Action ON LoanRepaymentSchedules(Action);
GO

-- =============================================
-- STORED PROCEDURES
-- =============================================

-- Get active loans for a customer
CREATE PROCEDURE sp_GetActiveLoansByCustomer
    @CID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT LC, CID, LoanAmount, TermID, MonthlyInterest, LoanDate, 
           StartPaymentDate, ServicePayment, Status, ScheduleStatus
    FROM LoanContracts
    WHERE CID = @CID AND Status = 'Active'
    ORDER BY LoanDate DESC;
END
GO

-- Get repayment schedule for a loan contract
CREATE PROCEDURE sp_GetRepaymentSchedule
    @LC INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT ScheduleID, LC, CID, PaymentDate, DueDate, MonthlyPayment,
           Principal, Interest, RemainingBalance, Action, PaymentDateActual
    FROM LoanRepaymentSchedules
    WHERE LC = @LC
    ORDER BY DueDate ASC;
END
GO

-- Get overdue payments
CREATE PROCEDURE sp_GetOverduePayments
    @LC INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT ScheduleID, LC, CID, PaymentDate, DueDate, MonthlyPayment,
           Principal, Interest, RemainingBalance, Action
    FROM LoanRepaymentSchedules
    WHERE Action IN ('Unpaid', 'Late')
        AND DueDate < CAST(GETDATE() AS DATE)
        AND (@LC IS NULL OR LC = @LC)
    ORDER BY DueDate ASC;
END
GO

PRINT 'Loan Management System tables created successfully!';
GO
