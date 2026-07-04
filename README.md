<div align="center">
  <img src="ANH/icons/movie.png" width="96" alt="Cinema Ticket System Logo">

  # Cinema Ticket Booking & Management System
  *A Windows Forms desktop application for managing cinema operations and ticket sales*

  [![Platform](https://img.shields.io/badge/Platform-.NET%20Framework-blue?style=flat-square)](#)
  [![Database](https://img.shields.io/badge/Database-SQL%20Server-red?style=flat-square)](#)
  [![Language](https://img.shields.io/badge/Language-C%23-green?style=flat-square)](#)

  [Overview](#overview) • [Key Features](#key-features) • [Tech Stack](#tech-stack) • [Database Setup](#database-setup) • [Getting Started](#getting-started)
</div>

---

This is a comprehensive desktop management system designed for cinemas. It provides dual-role access control for **Administrators** (who manage movies, staff accounts, system maintenance, and track revenue statistics) and **Staff Members** (who handle live ticket sales, seat selection, and submit maintenance reports).

> [!IMPORTANT]
> A pre-configured SQL Server database backup is included in the project. Follow the [Database Setup](#database-setup) instructions to restore the database before running the application.

## Key Features

### 🔐 Role-Based Authentication
* **Admin Dashboard:** Access to management settings, staff list, movie inventory, maintenance requests, and financial statistics.
* **Staff Interface:** Streamlined portal for selling tickets, processing customer orders, and reporting equipment issues.

### 🎬 Movie Management (Admin)
* Add, update, and soft-delete movies.
* Configure details including movie title, price, hall seating capacity, genre, status (`Available` / `Unavailable`), and poster image.

### 🎫 Live Ticketing System (Staff)
* Interactive seat selection based on theater capacity.
* Automated total price calculations, cash collection input, and change calculations.
* Print-friendly receipt generation.

### 🛠️ System Maintenance Logs
* Staff can log maintenance issues (e.g., projector or seat damage) from their workspace.
* Admins can monitor, track, and update the status of each request (`Wait`, `In Progress`, `Resolved`).

### 📊 Real-time Analytics
* Live stats counters for Active Staff, Total Tickets Sold, and Total Revenue directly on the Admin Dashboard.

## Tech Stack

* **Frontend/UI:** C# Windows Forms (WinForms)
* **Backend:** .NET Framework (C# Class Libraries)
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET (Connection Pooling, Parameterized Commands to prevent SQL Injection)

## Database Setup

1. **Restore Backup File:**
   Restore the database using SQL Server Management Studio (SSMS) from the backup file located at:
   `database/MyDatabase.bak` or `MyDatabase.bak` in the root folder.
   
2. **Alternative Setup (SQL Scripts):**
   If you prefer manual table creation, execute the SQL scripts in order:
   * [SQLQuery1.sql](file:///d:/bt/banve/SQLQuery1.sql) (Creates `movies`, `customers`, `buy_tickets` tables and contains queries).
   * [SQLQuery3.sql](file:///d:/bt/banve/SQLQuery3.sql) (Creates `maintenance` table).

3. **Configure Connection String:**
   Update the database connection string in [DatabaseConfig.cs](file:///d:/bt/banve/data/DatabaseConfig.cs):
   ```csharp
   public static string ConnectionString 
       => @"Data Source=YOUR_SERVER_NAME;Initial Catalog=QuanLyVeXemPhim;Integrated Security=True;";
   ```

## Getting Started

### Prerequisites
* Visual Studio (2019 or newer recommended) with **.NET Desktop Development** workload installed.
* MS SQL Server LocalDB or Express edition.

### Running the Project
1. Clone the repository to your local machine.
2. Open the solution file `movie.sln` in Visual Studio.
3. Configure the database connection string as detailed in [Database Setup](#database-setup).
4. Build the solution (`Ctrl + Shift + B`).
5. Run the application (`F5`).
