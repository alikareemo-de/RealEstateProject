# 🏠 RealEstateProject

**Mini Real Estate Website** for buying and renting properties — built with [ABP Framework](https://abp.io/) on **ASP.NET Core 9** using **DDD (Domain-Driven Design)** principles.

---

## 📌 Project Overview

This project is part of a technical assessment for a **Backend Developer** role at **SawaTech**.  
It implements backend functionality for a real estate platform, allowing:

- 👤 **Agents** to register, manage profiles, and add properties.
- 🔍 **Visitors** to browse, search, and view detailed property listings.

---

## 📦 Features

- ✅ JWT Authentication with OpenIddict + ASP.NET Core Identity
- ✅ Clean DDD architecture using ABP modules
- ✅ RESTful APIs for:
  - CRUD operations on properties
  - Filtered search
  - Similar properties
  - Property details
- ✅ Distributed Caching (fallback to In-Memory)
- ✅ Serilog Logging Middleware (to file)
- ✅ Swagger API documentation with OAuth2
- ✅ Rate limiting + API versioning
- ✅ Stored Procedures for complex filtering
- ✅ EF Core Relationships (One-to-Many & Many-to-Many)

---

## 🗃️ Technologies

| Layer             | Tech Stack                                           |
|------------------|------------------------------------------------------|
| Backend           | ASP.NET Core 9, ABP Framework                       |
| Auth              | OpenIddict + ASP.NET Core Identity                  |
| ORM               | Entity Framework Core + SQL Server                  |
| Caching           | Redis (Distributed) / In-Memory (Fallback)          |
| Logging           | Serilog                                             |
| API Documentation | Swagger (Swashbuckle + OAuth2)                      |
| Rate Limiting     | AspNetCoreRateLimit (via ABP)                       |

---

## 🏗️ Solution Structure

RealEstateProject/
├── src/
│ ├── RealEstateProject.Application # Application services
│ ├── RealEstateProject.Application.Contracts # DTOs + Interfaces
│ ├── RealEstateProject.Domain # Domain entities & logic
│ ├── RealEstateProject.Domain.Shared # Shared enums/constants
│ ├── RealEstateProject.EntityFrameworkCore # EF Core implementation
│ ├── RealEstateProject.HttpApi # HTTP API layer
│ ├── RealEstateProject.HttpApi.Host # Startup configuration
│ ├── RealEstateProject.HttpApi.Client # Swagger/HttpClient support
│ └── RealEstateProject.DbMigrator # CLI tool to run DB migrations
├── test/ # Unit tests
├── postman/ # Postman collection (JSON)
└── README.md

yaml
Copy
Edit

---

## ⚙️ Setup Instructions

1. **Clone the repository:**

   ```bash
   git clone https://github.com/alikareemo-de/RealEstateProject.git
Database Configuration:

Update the appsettings.json:

json
Copy
Edit
"ConnectionStrings": {
  "Default": "Your SQL Server connection string"
}
Run Migrations:

From the DbMigrator project:

bash
Copy
Edit
dotnet run --project src/RealEstateProject.DbMigrator
Run the App:

bash
Copy
Edit
dotnet run --project src/RealEstateProject.HttpApi.Host
Access Swagger:

https://localhost:44368/swagger

🔐 Authentication
OAuth2 Authorization Code flow with PKCE

Use the Authorize button on Swagger to obtain tokens.

Default test user is created automatically via seed logic.

📎 Postman Collection
You can test all endpoints via Postman:

📁 RealEstateProject_Postman_Collection.json

🚀 Deployment Notes
Hosting on SmarterASP.net failed due to lack of .NET 9 support.

Free alternatives like Azure App Service are not available in current region.

Solution is tested and production-ready for any .NET 9-compatible host.

📌 Git Repositories
🔗 GitHub: https://github.com/alikareemo-de/RealEstateProject

🔗 GitLab: https://gitlab.com/ali-project6350221/realestateproject

✅ Evaluation Criteria Check
Criteria	Status
ABP + DDD usage	✅ Complete
Code Quality (SOLID)	✅ Complete
Swagger Docs	✅ Complete
API Performance	✅ Cached + SP
Security (JWT + [Authorize])	✅ Complete

👨‍💻 Developer
Ali Kareem
Email: alikareemo.dev@gmail.com
GitHub: @alikareemo-de

