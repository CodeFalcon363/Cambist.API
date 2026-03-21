# Cambist API

A RESTful Web API built with ASP.NET Core 9 that provides live currency conversion, conversion history, and watchlist management by integrating with the [ExchangeRate API](https://www.exchangerate-api.com/) via RestSharp.

---

## Architecture

The solution follows a **Clean Architecture** pattern split across three projects:

| Project | Responsibility |
|---------|---------------|
| `Cambist.Core` | Domain entities, DTOs (request/response models), generic response wrappers, constants, EF Core DbContext and migrations |
| `Cambist.Infrastructure` | Repository and service interfaces, concrete implementations, AutoMapper profiles, RestSharp HTTP client integration |
| `Cambist.API` | Controllers, dependency injection registration, middleware pipeline |

Dependency flow: `API → Infrastructure → Core`. Core has zero outward dependencies.

---

## Key Patterns & Technologies

- **Repository Pattern** — data access abstracted behind interfaces; controllers never touch the DbContext
- **Service Layer** — business logic (currency validation, rate calculation) lives in services, not controllers
- **Thin Controllers** — each action delegates entirely to the service layer and returns a wrapped response
- **Generic Response Wrapper** — all endpoints return `ApiResponse<T>` or `PagedResponse<T>` for consistent structure
- **Paged Responses** — all collection endpoints support `pageNumber` and `pageSize` query parameters
- **AutoMapper** — entity-to-DTO mapping configured in a single `MappingProfile`
- **RestSharp** — HTTP client used to fetch live exchange rates from the external API
- **Entity Framework Core** — SQL Server provider with code-first migrations and seeded reference data
- **Dependency Injection** — all services and repositories registered via an `AddInfrastructure` extension method
- **Structured Logging** — `ILogger<T>` injected into all services with exception logging on every operation

---

## Endpoints

### Currency
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/currency` | Returns paginated list of supported currencies |
| GET | `/api/currency/{code}` | Returns a single currency by code (e.g. `USD`) |

### Conversion
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/conversionrecords` | Returns paginated conversion history |
| GET | `/api/conversionrecords/{id}` | Returns a single conversion record |
| POST | `/api/conversionrecords` | Performs a live conversion and saves the record |

### Watchlist
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/watchlistitems` | Returns paginated watchlist items |
| POST | `/api/watchlistitems` | Adds a currency pair to the watchlist |
| DELETE | `/api/watchlistitems/{id}` | Removes a watchlist item |

---

## Getting Started

### Prerequisites
- .NET 9 SDK
- SQL Server or SQL Server LocalDB

### Configuration

Update `appsettings.json` with your database connection string and exchange rate API base URL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CambistDb;Trusted_Connection=True;"
  },
  "ExchangeRateApi": {
    "BaseUrl": "https://open.er-api.com/v6/"
  }
}
```

### Database Setup

```bash
dotnet ef database update --project Cambist.Core --startup-project Cambist.API
```

This applies all migrations and seeds the database with NGN, USD, EUR, and GBP.

### Run

```bash
dotnet run --project Cambist.API
```

Navigate to `/scalar/v1` for the interactive API documentation.

---

## Project Structure

```
Cambist.Core/
  Data/               # DbContext, migrations
  Entities/           # Domain models
  Models/
    Requests/         # Input DTOs
    Responses/        # Output DTOs
  Constants/          # API messages

Cambist.Infrastructure/
  Interfaces/         # Repository and service contracts
  Repositories/       # EF Core data access implementations
  Services/           # Business logic implementations
  ExternalServices/   # RestSharp HTTP client (ExchangeRateService)
  Mappings/           # AutoMapper profile

Cambist.API/
  Controllers/        # Thin API controllers
  Extensions/         # DI registration extension methods
```
