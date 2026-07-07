using System.Net.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var app = builder.Build();
app.MapGet("/", () => "Agent is running");

app.MapGet("/external-events/simulate", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();

    var newEvent = new
    {
        title = "Agent Sensor Alert",
        description = "Event received from Agent",
        source = "Agent",
        location = "Tel Aviv"
    };

    var response = await client.PostAsJsonAsync(
        "http://localhost:5129/api/events",
        newEvent);

    var body = await response.Content.ReadAsStringAsync();

    return Results.Ok(new
    {
        Success = response.IsSuccessStatusCode,
        StatusCode = (int)response.StatusCode,
        Response = body
    });
});

app.Run();