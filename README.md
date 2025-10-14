# 🏥 Hospital San Vicente - Medical Management System

## 📘 Project Overview

**Hospital San Vicente** is a console-based hospital management system developed in **C# (.NET)**.  
It allows the administration of **Doctors**, **Patients**, and **Appointments**, including validation, CRUD operations, and automatic email notifications when appointments are scheduled.

The system is designed following **OOP principles**, using a layered architecture with **Services**, **Interfaces**, and **Helper classes** for validations and utilities.

---

## 👨‍💻 Coder Information

| Field | Information |
|-------|--------------|
| 👤 **Name:** | Wilson Esteban Delgado Molano |
| 🏘️ **Clan:** | Caiman |
| 📧 **Email:** | wilsondelgado890@gmail.com |
| 🪪 **Document ID:** | 1129543765 |

---

## ⚙️ Project Structure

HospitalSanVicente/
├── Models/
│   ├── Person.cs
│   ├── Medic.cs
│   ├── Patient.cs
│   └── Appointment.cs
├── Services/
│   ├── MedicService.cs
│   ├── PatientService.cs
│   ├── AppointmentService.cs
├── Interfaces/
│   ├── IMedicService.cs
│   ├── IPatientService.cs
│   └── IAppointmentService.cs
├── Utils/
│   ├──EmailHelper.cs     
│   ├──Helper.cs
│   ├──MenuService.cs
│   └──PersonService
├── Program.cs
└── README.md

---

## 🚀 How to Run the Project

Follow these steps to run the solution locally.

### 🧩 Prerequisites
- [.NET SDK 8.0 or later](https://dotnet.microsoft.com/en-us/download)
- A **Mailtrap** account (for email testing)
- Visual Studio or Visual Studio Code

### 🪜 Step-by-step Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/HospitalSanVicente.git
   cd HospitalSanVicente
Restore dependencies

dotnet restore
Build the project

dotnet build
Run the application

dotnet run
💡 Main Functionalities
Feature	Description
👨‍⚕️ Doctor Management	Add, update, search, list, or delete doctors.
👤 Patient Management	Add, update, search, list, or delete patients.
📅 Appointment Scheduling	Schedule, view, update, and delete appointments.
✅ Validation	Validates emails, phone numbers, and duplicate documents.
📧 Email Notifications	Sends confirmation emails via Mailtrap.

✉️ Email Configuration (Mailtrap)
In EmailHelper.cs, replace with your own Mailtrap credentials:

var smtp = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
{
    Credentials = new NetworkCredential("YOUR_MAILTRAP_USER", "YOUR_MAILTRAP_PASSWORD"),
    EnableSsl = true
};
Mailtrap acts as a safe sandbox for email testing — you can see the sent emails in your Mailtrap Inbox.

🧠 UML Diagrams
📘 Class Diagram

🎭 Use Case Diagram

🧩 Architecture Summary
The system uses a modular architecture, separating logic and data:

Models: Define data structures (Person, Medic, Patient, Appointment).

Interfaces: Define contracts for CRUD operations.

Services: Implement business logic for doctors, patients, and appointments.

Helpers: Provide validation and email utilities.

MenuService: Central console menu that orchestrates all actions.

🧪 Example Execution
🏥 Welcome to Hospital San Vicente Management System

===== MAIN MENU =====
1. Manage Doctors
2. Manage Patients
3. Manage Appointments
4. Exit

Select an option: 1

--- Doctor Menu ---
1. Register Doctor
2. List Doctors
3. Search Doctor
...
⚙️ Technologies Used
C# / .NET 8.0

Object-Oriented Programming (OOP)

Mailtrap SMTP

PlantUML for diagrams

🧾 License
This project is open-source and free to use for educational purposes.