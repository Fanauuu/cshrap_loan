-- =============================================
-- Database Creation Script for User Management System
-- =============================================

-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'cshrap')
BEGIN
    CREATE DATABASE cshrap;
END
GO

USE cshrap;
GO

-- Drop existing Users table if exists
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Users;
END
GO

-- Create Users Table with proper structure
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NULL,
    FirstName NVARCHAR(50) NULL,
    LastName NVARCHAR(50) NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT 'user',
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    LastModifiedDate DATETIME NULL,
    
    CONSTRAINT CK_Role CHECK (Role IN ('admin', 'user')),
    CONSTRAINT CK_Email CHECK (Email IS NULL OR Email LIKE '%@%.%')
);
GO

-- Create Indexes for better performance
CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_Role ON Users(Role);
CREATE INDEX IX_Users_IsActive ON Users(IsActive);
GO

-- Insert Default Admin User
-- Password: admin123 (in production, this should be hashed)
INSERT INTO Users (Username, Password, Email, FirstName, LastName, Role, IsActive, CreatedDate)
VALUES ('admin', 'admin123', 'admin@example.com', 'System', 'Administrator', 'Admin', 1, GETDATE());
GO

-- Insert Sample Users
INSERT INTO Users (Username, Password, Email, FirstName, LastName, Role, IsActive, CreatedDate)
VALUES 
    ('john.doe', 'password123', 'john.doe@example.com', 'John', 'Doe', 'User', 1, GETDATE()),
    ('jane.smith', 'password123', 'jane.smith@example.com', 'Jane', 'Smith', 'User', 1, GETDATE()),
    ('manager1', 'password123', 'manager1@example.com', 'Manager', 'One', 'Manager', 1, GETDATE());
GO

-- Create Stored Procedure for User Validation (Optional)
CREATE PROCEDURE sp_ValidateUser
    @Username NVARCHAR(50),
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT UserId, Username, Password, Email, FirstName, LastName, Role, IsActive, CreatedDate, LastModifiedDate
    FROM Users
    WHERE Username = @Username 
        AND Password = @Password 
        AND IsActive = 1;
END
GO

PRINT 'Database and Users table created successfully!';
PRINT 'Default admin user created:';
PRINT 'Username: admin';
PRINT 'Password: admin123';
GO
