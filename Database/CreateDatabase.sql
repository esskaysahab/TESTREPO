-- ============================================
-- School Management System - Database Script
-- Database Name: School
-- ============================================

-- Create Database (run separately if needed)
-- CREATE DATABASE School;
-- GO
-- USE School;
-- GO

USE School;
GO

-- ============================================
-- 1) Student Table
-- ============================================
IF OBJECT_ID('dbo.Student', 'U') IS NOT NULL
    DROP TABLE dbo.Student;
GO

CREATE TABLE dbo.Student (
    Student_id    INT PRIMARY KEY IDENTITY(1,1),
    Student_name  VARCHAR(100) NOT NULL,
    Fathers_name  VARCHAR(100),
    Address       VARCHAR(200),
    Phone         VARCHAR(20) UNIQUE NOT NULL,
    Voter_id      VARCHAR(20),
    Class         VARCHAR(20),
    Roll_no       INT,
    Sec           VARCHAR(5),
    Library_Card  VARCHAR(20),
    Bus           VARCHAR(20),
    Photo         VARBINARY(MAX)
);
GO

-- ============================================
-- 2) Library Table
-- ============================================
IF OBJECT_ID('dbo.Library', 'U') IS NOT NULL
    DROP TABLE dbo.Library;
GO

CREATE TABLE dbo.Library (
    Id           INT PRIMARY KEY IDENTITY(1,1),
    Student_id   INT NOT NULL,
    Card_no      VARCHAR(20),
    Book_name    VARCHAR(100),
    Issue_date   DATE,
    Submit_date  DATE,
    Total_fine   DECIMAL(10,2) DEFAULT 0,
    Report       VARCHAR(200),
    CONSTRAINT FK_Library_Student FOREIGN KEY (Student_id) REFERENCES dbo.Student(Student_id)
);
GO

-- ============================================
-- 3) Bus Table
-- ============================================
IF OBJECT_ID('dbo.Bus', 'U') IS NOT NULL
    DROP TABLE dbo.Bus;
GO

CREATE TABLE dbo.Bus (
    Id           INT PRIMARY KEY IDENTITY(1,1),
    Student_id   INT NOT NULL,
    Card_no      VARCHAR(20),
    Install_month VARCHAR(20),
    Installment  DECIMAL(10,2),
    Paid_date    DATE,
    Total_fine   DECIMAL(10,2) DEFAULT 0,
    Report       VARCHAR(200),
    CONSTRAINT FK_Bus_Student FOREIGN KEY (Student_id) REFERENCES dbo.Student(Student_id)
);
GO

-- ============================================
-- 4) Installment Table
-- ============================================
IF OBJECT_ID('dbo.Installment', 'U') IS NOT NULL
    DROP TABLE dbo.Installment;
GO

CREATE TABLE dbo.Installment (
    Id           INT PRIMARY KEY IDENTITY(1,1),
    Student_id   INT NOT NULL,
    Installment  DECIMAL(10,2),
    Gst          DECIMAL(10,2),
    Electric     DECIMAL(10,2) DEFAULT 255.70,
    Paid_date    DATE,
    Total_fine   DECIMAL(10,2) DEFAULT 0,
    Report       VARCHAR(200),
    CONSTRAINT FK_Installment_Student FOREIGN KEY (Student_id) REFERENCES dbo.Student(Student_id)
);
GO

-- ============================================
-- 5) Login Table
-- ============================================
IF OBJECT_ID('dbo.Login', 'U') IS NOT NULL
    DROP TABLE dbo.Login;
GO

CREATE TABLE dbo.Login (
    Type     VARCHAR(20) NOT NULL,
    Username VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50) NOT NULL
);
GO

-- Insert default admin user (Username: admin, Password: admin)
IF NOT EXISTS (SELECT 1 FROM dbo.[Login] WHERE Username = 'admin')
BEGIN
    INSERT INTO dbo.[Login] (Type, Username, Password) VALUES ('admin', 'admin', 'admin');
END
GO
