# E-Commerce Platform

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies](#technologies)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Database Setup](#database-setup)

## Introduction
This is a simple e-commerce platform built using .NET for the backend and SQL Server for the database. It provides a range of functionalities to manage products, orders, and users.

## Features
- User authentication and authorization
- Product management (CRUD operations)
- Shopping cart functionality
- Order processing
- Admin panel for managing products and orders

## Technologies
- **Backend:** ASP.NET Core
- **Frontend:** Razor Pages 
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Core MVC, Razor Pages (for Identity)

## Requirements
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (local or remote)
- [Visual Studio](https://visualstudio.microsoft.com/) (optional but recommended)

## Configuration

### appsettings.json
Before running the application, add the `deml/appsettings.json` file with your specific settings. Below is an example configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

## Installation

1. **Clone the Repository:**
    ```bash
    git clone https://github.com/yourusername/ecommerce-platform.git
    cd ecommerce-platform
    ```

2. **Set Up the Database:**
   - Update the `appsettings.json` file with your SQL Server connection string.
   
   - Run the following commands to create and seed the database:
     ```bash
     dotnet ef database update
     dotnet run seed
     ```

3. **Run the Application:**
    ```bash
    dotnet run
    ```

4. **Open in Browser:**
    - Navigate to `https://localhost:5001` (or `http://localhost:5000` for HTTP) in your web browser.

## Usage

1. **Register a New User:**
   - Go to the registration page and create a new account.

2. **Login:**
   - Log in with your new account.

3. **Browse Products:**
   - Browse the available products and add them to your shopping cart.

4. **Place Orders:**
   - Proceed to checkout and place your orders.

5. **Admin Panel:**
   - If you are an admin, navigate to the admin panel to manage products and orders.

## Database Setup

1. **Migrations:**
   - Add new migrations using the following command:
     ```bash
     dotnet ef migrations add MigrationName
     ```

2. **Update Database:**
   - Apply migrations to the database:
     ```bash
     dotnet ef database update
     ```
