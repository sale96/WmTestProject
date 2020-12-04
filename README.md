# Wireless Media Test Project

### Description
This project is created to be extensible and in it, I was doing my best to follow SOLID as well as DRY principle.
There are two types of data (from the database and from JSON) both implement the same interfaces so the swapping of implementation won't break the application.

### Setup
- Run ```dotnet restore```
- Run ```dotnet build```
- Go to WmTestProject.DataAccess and run ```dotnet ef --startup-project ../WmTestProject.Web database update``` to run migrations

### Packages
- Newtonsoft.Json
- EntityFramework Core
- FluentValidation
- AutoMapper

### Architecture
- Domain driven desing

### Patterns
- CQRS