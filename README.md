# Vehicle Rental Management System (Verleihprojekt) 🚗💨

A comprehensive, role-based ASP.NET Web Forms application designed to handle the entire lifecycle of vehicle and equipment rentals. Built with C# and the .NET Framework, this system features secure user authentication, dynamic real-time availability filtering, and robust reservation management powered by a Microsoft SQL Server backend.

> **🎓 Academic Context:** > This project was developed as part of a 4th-semester university assignment for the course *"Algorithmen, Datenstrukturen und Programmiersprachen"* (Algorithms, Data Structures, and Programming Languages).  
> **Date of Submission:** August 14, 2024  
> **Achieved Grade:** 1.3 (Excellent)

---

## 🌟 Core Features

* **Role-Based Access Control (RBAC):** Integrated master-page routing (`Site.Master.cs`) that dynamically tracks user sessions (`Session["Admin"]`). It automatically restricts or grants visibility to specific navigation links depending on whether the logged-in user is an Administrator or a standard Customer.
* **Dynamic Booking Engine (`Default.aspx`):** * Customers can filter available vehicles step-by-step by checking specific dates, times, categories (e.g., *Kompaktwagen, Limousine, SUV, Cabriolet*), models, and colors.
  * Uses jQuery UI Datepicker components with customized theme styles for an optimized calendar interface.
  * Real-time availability checks prevent double-booking by cross-referencing requested timeframes against active database entries using complex subqueries.
  * Dynamically calculates total rental costs directly on the client side based on the ceiling of total rental days.
* **Multi-Step Registration Workflow (`Register.aspx`):** A secure, multi-stage wizard interface that captures personal details, contact information, and banking connections (IBAN/BIC) sequentially, ensuring complete and valid customer profiles before account creation.
* **Administrative Operations Panel:** Secure dashboards (`Kunden.aspx`, `Leihmaterial.aspx`, `Reservierungen.aspx`) restricted strictly to administrators. Features data-bound grid views (`<asp:GridView>`) with built-in pagination, custom row data formatting (e.g., automated local currency conversion), and explicit error handling for seamless inventory and client management.
* **Robust Session State Management:** Secure retention of temporary booking state data and authentication flags across multi-page redirects, ensuring data persistence from vehicle selection to final rental confirmation.

## 🛠️ Tech Stack & Technical Architecture

* **Backend & Logic:** C# (.NET Framework) utilizing the Code-Behind architectural pattern to strictly separate business logic from presentation views.
* **Database & Data Access Layer:** Microsoft SQL Server integrated via **ADO.NET** (`System.Data.SqlClient`). 
  * Utilizes heavily parameterized queries across all components to completely eliminate SQL Injection vulnerabilities.
  * Implements strict **SQL Transactions (`SqlTransaction`)** within the core database manager (`SDB.cs`) to maintain absolute transactional data integrity during multi-table writes (such as saving a customer alongside their security credentials and financial connections simultaneously).
* **Frontend Design:** HTML5, CSS3, ASP.NET Server Controls, Bootstrap components for structural alignment, and jQuery UI.

## 🗂️ Project Architecture & Component Mapping

### 1. Data Access Layer (DAL)
* **`SDB.cs` / `SDB_2.cs`:** The central database connectivity engines handling standard open/close connection pooling, data readers (`SqlDataReader`), command executions, and failure exceptions.

### 2. Domain Model (Entities)
* **`Kunde.cs`:** Encapsulates complete personal records, address data, and financial credentials.
* **`Konto.cs`:** Handles authentication parameters, usernames, passwords, and administrative role flags.
* **`Leihmaterial.cs`:** Maps rental inventory attributes, prices per day, and contains the strongly-typed `Kategorien` enumeration.
* **`Reservierung.cs`:** Represents the transactional bridge connecting a specific `Kunde` to a piece of `Leihmaterial` within an explicit time delta.

### 3. Presentation Layer (Web Forms Layouts)
* **`Site.Master`:** Defines global page framing, navigational layouts, and conditional navbar item rendering based on authentication state.
* **`Default.aspx`:** The step-by-step customer-facing portal handling search filters and price checking.
* **`Login.aspx` / `Register.aspx`:** Onboarding endpoints managing security compliance and account mapping.
* **`LeihBestaetigung.aspx`:** Renders final successful reservation summaries and aggregates pricing criteria.
* **`MyReservation.aspx`:** Empowers authenticated customers to access and audit their own personalized booking history via stored procedures (`ReserviertTabelleZeigen`).

