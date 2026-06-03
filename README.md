LeetTracker
A REST API for tracking LeetCode-style problems — title, difficulty, category, and status — backed by PostgreSQL.

Tech Stack
.NET 10 (ASP.NET Core Web API)
Entity Framework Core + PostgreSQL
Docker (optional, for local database)
Prerequisites
.NET 10 SDK

Docker Desktop (recommended for Postgres)

EF Core CLI (for migrations):

dotnet tool install --global dotnet-ef
Getting Started
1. Clone the repo
git clone <your-repo-url>
cd LeetTracker
2. Start PostgreSQL
From the repo root:

docker compose up -d
This starts Postgres on port 5432 with:

Setting	Value
Database
leettracker
User
postgres
Password
password
3. Configure the connection string
appsettings.json ships with an empty connection string on purpose. You must set your database URL before running the app.

Create LeetTracker/appsettings.Development.json (this file is gitignored):

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=leettracker;Username=postgres;Password=password"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
Adjust Host, Port, Database, Username, and Password to match your Postgres setup.

For non-Development environments, set ConnectionStrings:DefaultConnection in appsettings.json, environment variables, or your deployment config instead.

4. Apply database migrations
cd LeetTracker
dotnet ef database update
Run this once (and again whenever new migrations are added).

5. Run the API
dotnet run
Default URL: http://localhost:5058

HTTPS profile (optional):

dotnet run --launch-profile https
OpenAPI document (Development only): http://localhost:5058/openapi/v1.json

API Endpoints
Base path: /api/problems

Method	Endpoint	Description
GET
/api/problems
List all problems
GET
/api/problems/{id}
Get problem by ID
POST
/api/problems
Create a problem
PUT
/api/problems/{id}
Update a problem
DELETE
/api/problems/{id}
Delete a problem
Request / response shape
Create (POST) — CreateProblemDto

{
  "title": "Two Sum",
  "difficulty": "Easy",
  "category": "Array",
  "status": "Todo"
}
Update (PUT) — UpdateProblemDto

{
  "title": "Two Sum",
  "difficulty": "Medium",
  "category": "Hash Table",
  "status": "Done"
}
Response — ProblemResponse

{
  "id": 1,
  "title": "Two Sum",
  "difficulty": "Easy",
  "category": "Array",
  "status": "Todo"
}
Project Structure

LeetTracker/
├── Controllers/     # API endpoints
├── Data/            # EF Core DbContext
├── DTOs/            # Request/response models
├── Models/          # Database entities
├── Migrations/      # EF Core migrations
├── Services/        # Business logic
├── Program.cs       # App setup & DI
└── appsettings.json
