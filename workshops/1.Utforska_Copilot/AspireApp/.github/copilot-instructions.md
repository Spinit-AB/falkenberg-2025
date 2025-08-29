# Copilot Instructions for AI Agents

## Project Overview
This repository is a .NET Aspire application composed of multiple services:
- **AspireApp.ApiService**: Backend API service
- **AspireApp.Web**: Blazor Web frontend
- **AspireApp.AppHost**: Orchestrates service startup and configuration
- **AspireApp.ServiceDefaults**: Shared service configuration and extensions

### Architecture & Data Flow
- The AppHost coordinates startup for both the API and Web services.
- The Web frontend communicates with the API via HTTP (see `WeatherApiClient.cs` for example usage).
- Shared configuration and service defaults are centralized in `AspireApp.ServiceDefaults`.
- Each service has its own `appsettings.json` and `appsettings.Development.json` for environment-specific configuration.

## Developer Workflows
- **Build Solution**: Use `dotnet build AspireApp.sln` from the repo root.
- **Run Locally**: Launch via AppHost (`dotnet run --project AspireApp.AppHost/AspireApp.AppHost.csproj`). This starts all services for local development.
- **Debugging**: Use launch profiles in `Properties/launchSettings.json` for each service. AppHost is the entry point for multi-service debugging.
- **Configuration**: Environment variables and settings are managed per service. Update `appsettings.*.json` as needed.

## Patterns & Conventions
- **Service Boundaries**: Each service is isolated in its own directory and project file.
- **Dependency Injection**: Services and clients are registered via DI in `Program.cs` of each service.
- **HTTP Communication**: The Web frontend uses typed HTTP clients (see `WeatherApiClient.cs`) to call the API.
- **Shared Extensions**: Common service configuration is factored into `AspireApp.ServiceDefaults/Extensions.cs`.
- **Environment-Specific Settings**: Use the appropriate `appsettings.Development.json` for local overrides.

## Integration Points
- **External Dependencies**: NuGet packages are managed per project via `.csproj` files.
- **Cross-Service Communication**: Web → API via HTTP; no direct references between service projects except through AppHost orchestration.

## Key Files & Directories
- `AspireApp.sln`: Solution file for building all projects
- `AspireApp.AppHost/`: Orchestration and startup logic
- `AspireApp.ApiService/`: Backend API logic
- `AspireApp.Web/`: Blazor Web frontend and components
- `AspireApp.ServiceDefaults/`: Shared configuration and extensions
- `WeatherApiClient.cs`: Example of HTTP client usage in frontend
- `Extensions.cs`: Shared service configuration patterns

## Example: Adding a New Service
1. Create a new project in its own directory.
2. Register the service in AppHost for orchestration.
3. Use DI and configuration patterns as in existing services.

---
For questions or unclear conventions, ask for clarification or review the structure of existing services for guidance.
