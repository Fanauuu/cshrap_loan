-- Update Role Constraint to only allow 'admin' and 'user' (lowercase)
-- Run this script in your database to fix the CHECK constraint

USE cshrap;
GO

-- Drop the existing constraint
IF EXISTS (SELECT * FROM sys.check_constraints WHERE name = 'CK_Role')
BEGIN
    ALTER TABLE Users DROP CONSTRAINT CK_Role;
END
GO

-- Add the new constraint with only 'admin' and 'user'
ALTER TABLE Users 
ADD CONSTRAINT CK_Role 
    CHECK (Role IN ('admin', 'user'));
GO

-- Verify the constraint
SELECT 
    CONSTRAINT_NAME,
    CHECK_CLAUSE
FROM INFORMATION_SCHEMA.CHECK_CONSTRAINTS
WHERE CONSTRAINT_NAME = 'CK_Role';
GO
