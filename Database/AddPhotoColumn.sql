-- Run this script if Student table already exists without Photo column
USE School;
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE object_id = OBJECT_ID('dbo.Student') AND name = 'Photo'
)
BEGIN
    ALTER TABLE dbo.Student ADD Photo VARBINARY(MAX) NULL;
END
GO
