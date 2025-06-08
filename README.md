# Employee Task Management System

This project is a full-stack **Employee Task Management System** built using **.NET Core** and **React**. It enables task assignment, progress tracking, and real-time notifications using **SignalR**. The system is cloud-ready, supporting over 500 users, and leverages **Azure SQL** for persistent data storage.

---

## Features

- Admin and employee dashboards
- Task assignment and status updates
- Real-time notifications using SignalR
- Role-based access control
- Scalable deployment on Azure App Services

---

## Table of Contents

- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [SignalR Integration](#signalr-integration)
- [License](#license)

---

## Tech Stack

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SignalR
- Azure SQL

### Frontend
- React.js
- Axios
- React Router
- SignalR Client

### DevOps / Cloud
- Azure App Services
- GitHub Actions (for CI/CD)

---

## Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/employee-task-management-system.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd employee-task-management-system
    ```

3. **Setup the backend API:**

    ```bash
    cd EmployeeTaskMgmtSystem.API
    dotnet restore
    dotnet ef database update
    dotnet run
    ```

4. **Setup the frontend:**

    ```bash
    cd ../client
    npm install
    npm start
    ```

---

## Usage

- **Admin Login** to assign tasks, monitor progress, and manage users.
- **Employee Login** to view, update, and complete assigned tasks.
- Receive **real-time notifications** on task updates or assignments.

Refer to the [docs/usage.md](docs/usage.md) *(to be created)* for a detailed walkthrough.

---

## Project Structure

```plaintext
employee-task-management-system/
│
├── EmployeeTaskMgmtSystem.API/      # .NET Core backend
│   ├── Controllers/
│   ├── Models/
│   ├── DTOs/
│   ├── Hubs/
│   ├── Services/
│   └── Data/
│
└── client/                          # React frontend
    ├── src/
    │   ├── components/
    │   ├── pages/
    │   ├── services/
    │   └── signalRService.js
