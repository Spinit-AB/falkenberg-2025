using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using Xunit;

namespace AspireApp.ApiService.Tests;

public class ApiEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public ApiEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task WeatherForecast_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/weatherforecast");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WeatherForecast_ReturnsJsonContent()
    {
        // Act
        var response = await _client.GetAsync("/weatherforecast");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        Assert.False(string.IsNullOrEmpty(content));
    }

    [Fact]
    public async Task WeatherForecast_ReturnsFiveDayForecast()
    {
        // Act
        var response = await _client.GetAsync("/weatherforecast");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.Equal(5, forecasts.Length);
    }

    [Fact]
    public async Task WeatherForecast_ReturnsValidTemperatureRange()
    {
        // Act
        var response = await _client.GetAsync("/weatherforecast");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            Assert.InRange(forecast.TemperatureC, -20, 55);
        });
    }

    [Fact]
    public async Task WeatherForecast_ReturnsValidDates()
    {
        // Act
        var response = await _client.GetAsync("/weatherforecast");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            Assert.True(forecast.Date > DateOnly.FromDateTime(DateTime.Now));
        });
    }

    [Fact]
    public async Task WeatherForecast_ReturnsValidSummary()
    {
        // Act
        var response = await _client.GetAsync("/weatherforecast");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            Assert.False(string.IsNullOrWhiteSpace(forecast.Summary));
        });
    }

    [Fact]
    public async Task AntarticaWeather_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/antarticaweather");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task AntarticaWeather_ReturnsJsonContent()
    {
        // Act
        var response = await _client.GetAsync("/antarticaweather");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        Assert.False(string.IsNullOrEmpty(content));
    }

    [Fact]
    public async Task AntarticaWeather_ReturnsFiveDayForecast()
    {
        // Act
        var response = await _client.GetAsync("/antarticaweather");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.Equal(5, forecasts.Length);
    }

    [Fact]
    public async Task AntarticaWeather_ReturnsValidTemperatureRange()
    {
        // Act
        var response = await _client.GetAsync("/antarticaweather");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            Assert.InRange(forecast.TemperatureC, -70, 10);
        });
    }

    [Fact]
    public async Task AntarticaWeather_ReturnsValidDates()
    {
        // Act
        var response = await _client.GetAsync("/antarticaweather");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            Assert.True(forecast.Date > DateOnly.FromDateTime(DateTime.Now));
        });
    }

    [Fact]
    public async Task AntarticaWeather_ReturnsValidSummary()
    {
        // Act
        var response = await _client.GetAsync("/antarticaweather");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            Assert.False(string.IsNullOrWhiteSpace(forecast.Summary));
        });
    }

    [Fact]
    public async Task HealthCheck_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/health");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task LivenessCheck_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/alive");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WeatherForecast_ReturnsValidTemperatureF()
    {
        // Act
        var response = await _client.GetAsync("/weatherforecast");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            var expectedF = 32 + (int)(forecast.TemperatureC / 0.5556);
            Assert.Equal(expectedF, forecast.TemperatureF);
        });
    }

    [Fact]
    public async Task AntarticaWeather_ReturnsValidTemperatureF()
    {
        // Act
        var response = await _client.GetAsync("/antarticaweather");
        var content = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecasts);
        Assert.All(forecasts, forecast =>
        {
            var expectedF = 32 + (int)(forecast.TemperatureC / 0.5556);
            Assert.Equal(expectedF, forecast.TemperatureF);
        });
    }

    [Fact]
    public async Task InvalidEndpoint_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/nonexistent");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}

// Test model matching the API model
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}