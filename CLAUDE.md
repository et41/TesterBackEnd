# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Run Commands

```bash
# Build
dotnet build TesterBackEnd/TesterBackEnd.csproj

# Run (starts on HTTPS with Swagger UI in development)
dotnet run --project TesterBackEnd/TesterBackEnd.csproj

# EF Core migrations
dotnet ef migrations add <MigrationName> --project TesterBackEnd/TesterBackEnd.csproj
dotnet ef database update --project TesterBackEnd/TesterBackEnd.csproj
```

No test project exists in this solution.

## Architecture

This is an **ASP.NET Core 8.0 Web API** for a transformer testing management system — it tracks electrical test data for power transformers organized by project.

### Layered Structure (inside `TesterBackEnd/TesterBackEnd/`)

- **Controllers/** — REST endpoints. Each controller injects `TesterDBContext` and `IMapper` directly (no service layer).
- **Models/** — EF Core entity classes and `TesterDBContext`.
- **Models/DTOs/** — Data transfer objects used for API request/response. AutoMapper converts between entities and DTOs via `MappingProfile.cs`.
- **Migrations/** — EF Core migration files targeting Azure SQL Server.

### Domain Model Relationships

```
Project (1) ──→ (N) Transformer (1) ──→ (N) ActiveTestReport
                         │
                         └──→ (1) Checklist
```

- **Project**: Defines a transformer order (customer, voltage specs, tap configuration). Creating a project auto-generates N transformers (based on `Pieces`) and a checklist per transformer.
- **Transformer**: Individual unit with serial number (`{projectId:D6} - {index:D2}`). Holds references to test reports.
- **ActiveTestReport**: Contains measurement data — TTR ratios, resistances, imbalances, insulation values stored as `List<double>` collections.
- **Checklist**: Boolean flags tracking test completion stages (incoming inspection through lab tests).

All parent-child relationships use cascading deletes configured in `TesterDBContext.OnModelCreating`.

### Key Patterns

- Controllers handle business logic directly (no service/repository layer).
- `ProjectController.PUT` dynamically adjusts transformer count when `Pieces` changes — adds or removes transformers to match.
- DTOs use `ObservableCollection<T>` (designed for a WPF/XAML client consumer).
- No authentication is enforced on endpoints — `UseAuthorization()` is called but no auth middleware or `[Authorize]` attributes are configured.

## Database

- **Provider**: Azure SQL Server (`testerbackenddbserver.database.windows.net`)
- **Auth**: Azure Active Directory Interactive
- **Connection string**: in `appsettings.json` under `ConnectionStrings:TesterBackEndContext`
- **User Secrets ID**: `05d71a17-86cf-4214-8148-d4e07caafb45` (for local secret overrides)

## Dependencies

- **AutoMapper 13.0.1** — entity ↔ DTO mapping
- **EF Core 9.0.1** (SqlServer provider) — ORM and migrations
- **Swashbuckle 6.6.2** — Swagger/OpenAPI documentation

---

## MAUI Frontend (`../Tester/MauiApp1/`)

The client is a **.NET MAUI app** (net9.0) at `C:\Users\eren_\source\repos\Tester\MauiApp1`.

### Build Commands

```bash
# Build
dotnet build ../Tester/MauiApp1/Tester.csproj

# Run on Windows
dotnet build ../Tester/MauiApp1/Tester.csproj -t:Run -f net9.0-windows10.0.19041.0
```

### MVVM Structure

- **Views/** — ContentPages. Navigation is programmatic (`PushAsync`/`PopAsync`), not Shell-based.
- **ViewModels/** — Inherit `ObservableObject` (CommunityToolkit.Mvvm) with `[ObservableProperty]` and `[RelayCommand]` attributes.
- **Models/** — `TransformerProject`, `Transformer`, `ActiveTestReport`, `TtrData`. Mirror backend entities with added UI-computed properties (`ChecklistProgress`, `IsComplete`, `VoltageDisplay`).
- **DATA/** — `RestServiceCall.cs` (static HTTP client to backend API) and `TesterDatabase.cs` (local SQLite via sqlite-net-pcl).
- **Helper/** — `NullableDoubleConverter` for XAML bindings (handles comma-as-decimal for Turkish/German locales).

### Backend Connection

**Base URL** is hardcoded in `DATA/RestServiceCall.cs`:
```
https://testerbackend20250125091419.azurewebsites.net/
```

**Endpoints consumed:**
- `GET /Project` — list projects
- `POST /Project` — create project
- `PUT /Project/{id}` — update project
- `DELETE /Project/{id}` — delete project
- `GET /activetestreport/{id}` — fetch test report by transformer ID
- `POST /activetestreport` — create test report
- `PUT /activetestreport/{id}` — update test report
- `DELETE /activetestreport/{id}` — delete test report

`RestServiceCall` uses callback-based error handling (`Action<Exception>`). Responses are deserialized to `ObservableCollection<T>`.

### Dual Storage

- **SQLite** (local via `TesterDatabase.cs`) — generic CRUD with lazy table creation. Used for offline project storage.
- **Azure API** (remote via `RestServiceCall.cs`) — centralized data. Projects can be saved locally first, then synced to backend.

### Key Frontend Patterns

- All electrical calculations (HV/LV resistance test values, imbalances, design-vs-test comparisons) are done **client-side in ViewModels** before POSTing.
- `ObservableCollection<double?>` used for measurement arrays (TTR ratios, resistances, insulation values).
- DI services accessed via static `App.Services.GetService<T>()`.
- Multi-tab test report entry uses **Syncfusion TabView** (`TestReportActivePageWithTabs`) with tabs: TTR, Resistance, Insulation, Project Info, Design Comparison.

### Frontend Dependencies

- **CommunityToolkit.Mvvm 8.4.0** — MVVM source generators
- **CommunityToolkit.Maui 11.1.0** — UI extensions
- **Newtonsoft.Json 13.0.3** — JSON serialization
- **sqlite-net-pcl 1.9.172** — local SQLite ORM
- **Syncfusion.Maui.TabView 29.2.7** — tabbed UI component
