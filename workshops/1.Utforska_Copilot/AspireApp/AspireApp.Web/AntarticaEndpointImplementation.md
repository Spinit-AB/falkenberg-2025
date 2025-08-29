# Steps to Implement Usage of the Antartica Endpoint in AspireApp.Web

This guide describes how to consume the `antartica` endpoint from the API service in the Blazor Web project.

## 1. Add Typed HTTP Client for Antartica Endpoint
- Create a new client class (e.g., `AntarticaApiClient.cs`) in `AspireApp.Web`.
- Implement methods to call the `antartica` endpoint using `HttpClient`.
- Register the client in `Program.cs` using DI:
  ```csharp
  builder.Services.AddHttpClient<AntarticaApiClient>(client =>
  {
      client.BaseAddress = new Uri("<API_BASE_URL>");
  });
  ```
  Replace `<API_BASE_URL>` with the actual API service URL.

## 2. Consume the Endpoint in a Blazor Component
- Inject `AntarticaApiClient` into the desired component (e.g., `@inject AntarticaApiClient AntarticaClient`).
- Call the method to fetch data from the endpoint (e.g., `await AntarticaClient.GetAntarticaDataAsync()`).
- Handle loading, error, and display states in the component.

## 3. Update the UI
- Display the data returned from the `antartica` endpoint in the Blazor page/component.
- Add appropriate markup and styling for the new data.

## 4. Test the Integration
- Run the application via AppHost.
- Navigate to the updated page/component and verify data from the `antartica` endpoint is displayed correctly.

---
Refer to `WeatherApiClient.cs` for an example of HTTP client usage and DI registration.
