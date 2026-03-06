# School Management System

A complete C# Windows Forms Application (.NET Framework 4.7.2) with SQL Server backend.

## Prerequisites

- Visual Studio 2017 or later (with .NET Desktop Development workload), or .NET Framework 4.7.2 SDK
- SQL Server (LocalDB, Express, or full) with a instance (e.g. `.\SQLEXPRESS`)

## Database Setup

1. Open SQL Server Management Studio and connect to your instance.
2. Create the database (if it does not exist):
   ```sql
   CREATE DATABASE School;
   GO
   ```
3. Run the script `Database\CreateDatabase.sql` against the `School` database.
   - In SSMS: open `CreateDatabase.sql`, ensure "School" is the active database, and execute (F5).
4. If you already had the `School` database without the Photo column, run `Database\AddPhotoColumn.sql` to add student photos support.

This creates:

- **Student** – Student_id (IDENTITY), name, father's name, address, phone (unique), voter_id, class, roll_no, sec, library_card, bus, photo (VARBINARY(MAX), optional)
- **Library** – Student_id (FK), card_no, book_name, issue_date, submit_date, total_fine, report
- **Bus** – Student_id (FK), card_no, install_month, installment, paid_date, total_fine, report
- **Installment** – Student_id (FK), installment, gst, electric (default 255.70), paid_date, total_fine, report
- **Login** – Type (admin/student), username (PK), password

A default admin user is inserted: **Username: admin**, **Password: admin**.

## Connection String

Edit `SchoolManagementSystem\App.config` and set the connection string to your SQL Server instance:

```xml
<connectionStrings>
  <add name="SchoolDB" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

- Change `Data Source` if needed (e.g. `localhost`, `(localdb)\MSSQLLocalDB`, or `Server=.;`).
- For SQL authentication, use:  
  `Data Source=.\SQLEXPRESS;Initial Catalog=School;User Id=youruser;Password=yourpassword;`

## Building and Running

- **Visual Studio:** Open `SchoolManagementSystem.sln`, build (F6), then run (F5).
- **Command line:** From the solution folder run:
  ```bat
  msbuild SchoolManagementSystem.sln /p:Configuration=Debug
  ```
  Then run `SchoolManagementSystem\bin\Debug\SchoolManagementSystem.exe`.

## Features

1. **Login** – Validates against the Login table; admin opens Admin Dashboard, student opens Student Dashboard.
2. **Student registration** – Inserts into Student and creates a Login row (type=student, username=phone, password=phone). Shows generated Student_id in a message box. Duplicate phone is blocked.
3. **Admin** – Full access: insert/update/delete/search students, Library/Bus/Installment forms, and reports.
4. **Student** – View/update own profile; add Library/Bus/Installment records only for their own Student_id.
5. **Auto data fetch** – On Library/Bus/Installment forms, when Student_id is entered and the control loses focus (Leave), the app fetches Student_name, Class, Sec, Library_Card (or Bus where relevant) from the Student table using SqlDataReader. If not found, a message is shown.
6. **Fine calculation**
   - **Library:** Late days = Submit_date − Issue_date; Fine = Late days × 10.25
   - **Bus:** Fine = Installment × 10%
   - **Installment:** GST = Installment × 18%; Electric = 255.70; Late fine = Installment × 12.79% × Late days
7. **Reports** – Bus report and Installment report in a DataGridView with a Grand Total (fine) displayed.
8. **Logout** – Admin and Student dashboards have a **Logout** button; it returns to the login screen.
9. **Student picture** – In **Student Registration** and **Student / My Profile**, you can add a student photo via **Add Picture** (and **Remove Picture** in the profile form). Photos are stored in the database (Student.Photo).

## Forms

- **LoginForm** – Username/password; link to registration.
- **RegistrationForm** – New student sign-up; creates Student + Login.
- **AdminDashboard** – Links to Student, Library, Bus, Installment, and Reports.
- **StudentDashboard** – Links to My Profile, Library, Bus, Installment (no Reports).
- **StudentForm** – Admin: full CRUD and search; Student: view/update own profile.
- **LibraryForm** – Library issue/submit and fine (with auto-fetch on Student_id).
- **BusForm** – Bus installment and fine (with auto-fetch on Student_id).
- **InstallmentForm** – Fee installment, GST, electric, late fine (with auto-fetch on Student_id).
- **ReportForms** – Bus report and Installment report with DataGridView and Grand Total.

All database access uses parameterized queries, SqlConnection, SqlCommand, SqlDataReader, and SqlDataAdapter with try-catch and a shared connection string from App.config.
