# ProductApi

ASP.NET Core (.NET 9) Web API implementing full CRUD for a `Product` entity using
EF Core + Npgsql (PostgreSQL).

## 1. Recreate the project from scratch (optional)

If you want to regenerate this scaffold yourself instead of using the provided files:

```bash
dotnet new webapi -n ProductApi --use-controllers -o ProductApi
cd ProductApi
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore
```

## 2. Configure the database connection

Edit `appsettings.json` and set your real PostgreSQL credentials:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=productdb;Username=postgres;Password=your_password"
}
```

Make sure the `productdb` database exists (or let EF Core create it via migrations below).

## 3. Install the EF Core CLI tool (one-time, if not already installed)

```bash
dotnet tool install --global dotnet-ef
```

## 4. Create and apply the migration

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This creates the `Products` table in PostgreSQL matching the `Product` model.

## 5. Run the API

```bash
dotnet run
```

Then open the Swagger UI at `http://localhost:5080/swagger` (or the HTTPS port shown
in the console) to try the endpoints interactively.

## Endpoints

| Verb   | Route               | Description              | Success | Error |
|--------|----------------------|--------------------------|---------|-------|
| POST   | /api/products        | Create a product         | 201     | 400   |
| GET    | /api/products         | Get all products          | 200     | -     |
| GET    | /api/products/{id}    | Get a single product      | 200     | 404   |
| PUT    | /api/products/{id}    | Update a product          | 204     | 404/400 |
| DELETE | /api/products/{id}    | Delete a product          | 204     | 404   |

### Example: create a product

```bash
curl -X POST http://localhost:5080/api/products \
  -H "Content-Type: application/json" \
  -d '{"name": "Wireless Mouse", "price": 29.99}'
```
