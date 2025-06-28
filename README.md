
# Task Management API (.NET 8)

This is a simple RESTful API built with ASP.NET Core (.NET 8) that allows users to manage tasks (Create, Read, Update, Delete). It follows SOLID principles, includes proper error handling, and uses Entity Framework Core with MS SQL Server.

## 🚀 Features
- CRUD operations for tasks
- Repository and Service patterns
- Global error handling middleware
- Logging with ILogger
- Swagger UI

## 📁 Structure
```
TaskApi/
├── Controllers/
├── Data/
├── Exceptions/
├── Middlewares/
├── Models/
├── Repositories/
├── Services/
├── Program.cs
├── appsettings.json
```

## 🛠️ Tech Stack
- ASP.NET Core (.NET 8)
- EF Core & SQL Server
- Swagger (Swashbuckle)

## 🔧 Setup
1. Clone: `git clone https://github.com/Seema2211/TaskManagement.git`
2. Update `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=TaskDb;Trusted_Connection=True;Encrypt=False;"
}
```
3. Create DB:
```sql
CREATE DATABASE TaskManagement;
USE TaskManagement;
CREATE TABLE Tasks (
  Id INT PRIMARY KEY IDENTITY(1,1),
  Title NVARCHAR(255),
  Description NVARCHAR(MAX),
  DueDate DATETIME,
  IsCompleted BIT
);
```
4. Run:
```bash
dotnet build
dotnet run
```
5. Swagger: `https://localhost:<port>/swagger`
6. Test: `dotnet test`

## 📬 API Endpoints
| Method | Endpoint             | Description       |
|--------|----------------------|-------------------|
| GET    | /api/tasks           | List all tasks    |
| GET    | /api/tasks/{id}      | Get task by ID    |
| POST   | /api/tasks           | Create a task     |
| PUT    | /api/tasks/{id}      | Update a task     |
| DELETE | /api/tasks/{id}      | Delete a task     |

## 📝 License
MIT

## 🙋‍♂️ Author
Developed by Seema


 ⚠️ IMPORTANT:
 Here currently hard delete is performed.
 ❌ This is not preferred for live/production projects.
 ✅ Always use soft delete instead by adding an `IsDeleted` column in the entity
  and filtering out logically deleted records from queries.
...
