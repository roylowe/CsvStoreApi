# 📘 CsvStoreApi (.NET 10)
A hands‑on educational Web API demonstrating how to read data from a CSV file using modern ASP.NET Core 10, clean engineering practices, dependency injection, and configuration via `appsettings.json`.

This project is intentionally simple but structured like a real production API, making it ideal for learning, teaching, or onboarding new developers.

---

## 🚀 Features

- ✔ **.NET 10 Web API**
- ✔ **Reads product data from a CSV file**
- ✔ **Strongly typed configuration (`CsvSettings`)**
- ✔ **Dependency injection with interfaces**
- ✔ **Async file I/O**
- ✔ **Structured logging**
- ✔ **Swagger UI for testing**
- ✔ **Clean folder structure**
- ✔ **Easy to extend (add endpoints, services, models)**

---

## 📁 Project Structure

CsvStoreApi/
│── Controllers/
│   └── ProductsController.cs
│── Configuration/
│   └── CsvSettings.cs
│── Models/
│   └── Product.cs
│── Services/
│   ├── IProductService.cs
│   └── CsvProductService.cs
│── Data/
│   └── products.csv
│── appsettings.json
│── Program.cs
│── README.md

Below is a detailed explanation of every file and folder.

---

## 📂 Controllers/

### **ProductsController.cs**
The API layer.  
Exposes the endpoint:

GET /api/products

Responsibilities:

- Accept HTTP requests  
- Call `IProductService`  
- Return JSON responses  
- Log incoming requests  

The controller contains **no business logic**, following best practices.

---

## 📂 Configuration/

### **CsvSettings.cs**
A strongly typed configuration class bound to the `CsvSettings` section of `appsettings.json`.

Example:

```json
"CsvSettings": {
  "ProductCsvPath": "Data/products.csv"
}

This allows changing the CSV path without modifying code.
Models/
Product.cs
A simple POCO representing a product:

Id (int)

Name (string)

Price (decimal)

Used throughout the service and controller layers.

Services/
IProductService.cs
Defines the contract for reading product data:
Task<IReadOnlyList<Product>> GetAllAsync();

Using an interface allows:

Mocking in unit tests

Swapping CSV for a database later

Clean architecture separation

CsvProductService.cs
Implements IProductService using a CSV file.

Responsibilities:

Read the CSV file asynchronously

Skip the header row

Parse each line safely

Validate numeric fields

Log warnings for malformed lines

Return a list of Product objects

Engineering practices demonstrated:

IOptions<CsvSettings> for configuration

ILogger<T> for structured logging

InvariantCulture for decimal parsing

Graceful error handling

Async file I/O

📂 Data/
products.csv
The CSV file containing product data.

Example:
Id,Name,Price
1,Laptop,999.99
2,Mouse,29.99
3,Keyboard,49.99
4,Monitor,199.99

Modify this file to change the API output.

appsettings.json
Holds configuration for:

CSV file path

Logging

Allowed hosts

Example:
"CsvSettings": {
  "ProductCsvPath": "Data/products.csv"
}

Program.cs
The application startup file using the minimal hosting model in .NET 10.

Responsibilities:

Bind CsvSettings

Register IProductService and CsvProductService

Enable controllers

Enable Swagger in development

Configure routing

Start the web application

This file wires the entire application together.

How to Update the Project
1. Update the CSV File
Modify Data/products.csv to add or change products.

Example:
5,Webcam,49.99
6,Desk Lamp,19.99

The API will automatically return the new data.
Change the CSV Path
Edit appsettings.json:
"CsvSettings": {
  "ProductCsvPath": "Data/new-products.csv"
}

No code changes required.

Add New Endpoints
Extend ProductsController.cs:

GET /api/products/{id}

POST /api/products

PUT /api/products/{id}

DELETE /api/products/{id}

Each endpoint should call a service method, not contain business logic.

Add New Services
Create new interfaces and implementations under /Services.

Example:

ICsvWriterService

CsvWriterService

Add New Models
Add new POCO classes under /Models.

Example:

Category.cs

Order.cs

Add Environment-Specific Settings
Create:

appsettings.Development.json

appsettings.Production.json

Each can override the CSV path or logging settings.

Testing the API
Run the project:
dotnet run

Open Swagger:

https://localhost:<port>/swagger

Test:
GET /api/products

You should see JSON output based on your CSV file.

Recommended Git Workflow
Create a feature branch

git checkout -b feature/add-readme-and-git-setup

Commit Changes
git add .
git commit -m "Add README.md and initial project documentation"


Merge into main
git checkout main
git merge feature/add-readme-and-git-setup -m "Merge feature branch: added documentation and project setup"

Push to Github
git push origin main

Conclusion
CsvStoreApi is a clean, modern, and fully explainable .NET 10 Web API designed for teaching and learning.
It demonstrates real engineering practices while staying simple enough for beginners to understand.

---

If you want, Roy, I can also generate:

- A GitHub Actions CI pipeline  
- A POST endpoint that writes back to the CSV  
- A Clean Architecture version  
- A full architecture diagram  
- A unit test suite  

