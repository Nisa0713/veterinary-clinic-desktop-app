IF DB_ID('VetClinicDB') IS NULL
BEGIN
    CREATE DATABASE VetClinicDB;
END
GO

USE VetClinicDB;
GO

IF OBJECT_ID('dbo.Owners','U') IS NULL
CREATE TABLE dbo.Owners (
    OwnerID INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(200)
);
GO

IF OBJECT_ID('dbo.Pets','U') IS NULL
CREATE TABLE dbo.Pets (
    PetID INT IDENTITY PRIMARY KEY,
    OwnerID INT NOT NULL,
    PetName NVARCHAR(50) NOT NULL,
    Species NVARCHAR(50) NOT NULL,
    Breed NVARCHAR(50),
    BirthDate DATE,
    FOREIGN KEY (OwnerID) REFERENCES dbo.Owners(OwnerID)
);
GO

IF OBJECT_ID('dbo.Veterinarians','U') IS NULL
CREATE TABLE dbo.Veterinarians (
    VetID INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Specialization NVARCHAR(100),
    Phone NVARCHAR(20)
);
GO

IF OBJECT_ID('dbo.Appointments','U') IS NULL
CREATE TABLE dbo.Appointments (
    AppointmentID INT IDENTITY PRIMARY KEY,
    PetID INT NOT NULL,
    VetID INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Status NVARCHAR(20),
    FOREIGN KEY (PetID) REFERENCES dbo.Pets(PetID),
    FOREIGN KEY (VetID) REFERENCES dbo.Veterinarians(VetID)
);
GO

IF OBJECT_ID('dbo.Vaccinations','U') IS NULL
CREATE TABLE dbo.Vaccinations (
    VaccinationID INT IDENTITY PRIMARY KEY,
    PetID INT NOT NULL,
    VaccineType NVARCHAR(100) NOT NULL,
    DateGiven DATE NOT NULL,
    NextDueDate DATE,
    FOREIGN KEY (PetID) REFERENCES dbo.Pets(PetID)
);
GO

IF OBJECT_ID('dbo.Medicines','U') IS NULL
CREATE TABLE dbo.Medicines (
    MedicineID INT IDENTITY PRIMARY KEY,
    MedicineName NVARCHAR(100) NOT NULL,
    Stock INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);
GO

IF OBJECT_ID('dbo.Invoices','U') IS NULL
CREATE TABLE dbo.Invoices (
    InvoiceID INT IDENTITY PRIMARY KEY,
    AppointmentID INT NOT NULL,
    TotalAmount DECIMAL(10,2),
    PaymentStatus NVARCHAR(50),
    PaymentDate DATE,
    FOREIGN KEY (AppointmentID) REFERENCES dbo.Appointments(AppointmentID)
);
GO

-- Test verisi (boþsa ekle)
IF NOT EXISTS (SELECT 1 FROM dbo.Owners)
BEGIN
    INSERT INTO dbo.Owners (FullName, Phone, Email, Address) VALUES
    (N'Nisa Askar', '5551112233', 'nisaaskar@gmail.com', N'Istanbul'),
    (N'Hesna Sude Ulufer', '5552223344', 'hesnasudeulufer@gmail.com', N'Ankara'),
    (N'Beyza Albayrak', '5553334455', 'beyzaalbayrak@gmail.com', N'Izmir');

    INSERT INTO dbo.Pets (OwnerID, PetName, Species, Breed, BirthDate) VALUES
    (1, N'Pamuk',   N'Cat',     N'Tekir',       '2021-05-10'),
    (2, N'Karabas', N'Dog',     N'Golden',      '2020-03-15'),
    (3, N'Boncuk',  N'Rabbit',  N'Holland Lop', '2022-04-12'),
    (3, N'Duman',  N'Hamster', N'Syrian',      '2023-09-01');

    INSERT INTO dbo.Veterinarians (FullName, Specialization, Phone) VALUES
    (N'Dr. Elif Demir', N'Genel', '5559998877');

    INSERT INTO dbo.Appointments (PetID, VetID, AppointmentDate, Status) VALUES
    (1, 1, '2026-01-05 10:00', 'Scheduled');

    INSERT INTO dbo.Vaccinations (PetID, VaccineType, DateGiven, NextDueDate) VALUES
    (1, N'Kuduz', '2025-01-01', '2026-01-01');

    INSERT INTO dbo.Medicines (MedicineName, Stock, Price) VALUES
    (N'Amoxicillin', 50, 120.00);

    INSERT INTO dbo.Invoices (AppointmentID, TotalAmount, PaymentStatus, PaymentDate) VALUES
    (1, 250.00, 'Paid', '2026-01-05');
END
GO
