# 06Aug_2026

ASP.NET Core 8 Web API for Product and Order management, using
Entity Framework Core (Code First) with SQL Server and migrations,
plus a Repository-interface / Service-implementation pattern.

Rebuilt to match:
https://github.com/divyansh653/dot-net-practical/tree/main/Assignments/6_Augest

## Entities

**Product**: PId, PName (required, 2–20 chars), Price (required, 15–100000), Quantity (required, 1–100), Availability (required, max 3 chars)

**Order**: OrderId, CustomerName (required, 2–100 chars), ProductName (required, 2–100 chars), Quantity (required, 1–100), TotalAmount (required, 1–100000)

*(As in the original repo, `Order.ProductName` is a plain string rather
than a foreign key to `Product` — there's no relationship modeled
between the two entities.)*

## Fix applied vs. the original repo

The original repo's `Migrations` folder only contains a migration for
the `products` table (`InitialCreate`) even though `Order` is fully
wired up in the model, `DbContext`, service, and controller. Running
`dotnet ef database update` from the original code would leave the
`orders` table missing, so any Order API call would throw at runtime.

This copy adds a second migration, `AddOrderTable`, so the database
actually has both tables. It also adds `ModelState.IsValid` checks and
"not found" handling to `OrdersController`, matching the validation
already present in `ProductsController`.

## Setup & Run

```bash
dotnet restore

# Update the connection string in appsettings.json first if needed
dotnet ef database update

dotnet run
```

Swagger UI opens automatically at `/swagger`.

## Endpoints

| Entity  | GET (all)      | GET (by id)         | POST           | PUT            | DELETE              |
|---------|-----------------|-----------------------|-----------------|-----------------|-----------------------|
| Product | `/api/Products`| `/api/Products/{id}` | `/api/Products`| `/api/Products`| `/api/Products/{id}` |
| Order   | `/api/Orders`  | `/api/Orders/{id}`   | `/api/Orders`  | `/api/Orders`  | `/api/Orders/{id}`   |

Note: PUT is not routed with `{id}` in the URL (matching the original
repo's design) — the entity's own Id/PId field in the request body is
used to identify the record to update.
