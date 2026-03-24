# Laptop Management Server

A Web API built with **ASP.NET Core** designed to manage laptop inventories and store branches efficiently.

## Architecture
This project follows **Clean Architecture** principles to ensure high maintainability and testability:
- **Domain:** Contains entities, interfaces for repositories.
- **Application:** Implements Use Cases and Interfaces.
- **Infrastructure:** Data persistence with **Entity Framework Core** and SQL Server.
- **API:** Handles HTTP requests and Dependency Injection.

## Features
- **CRUD Operations:** Comprehensive management for Laptops and Stores, with additional add and remove laptops for stores.
- **Data Validation:** FluentValidation for strict business rule enforcement.
- **Database Management:** Migrations and efficient query handling via EF Core.
- **Testing (In progress):** Unit tests for Domain logic using xUnit.

## Technology
- **Language:** C# 12/ .NET 8
- **ORM:** Entity Framework Core
- **Database:** PostgreSql
- **Tools:** Visual Studio, Swagger UI
