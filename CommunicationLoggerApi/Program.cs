
using CommunicationMiddleware;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory log storage for demo (replace with persistent storage as needed)
var logEntries = new List<CommunicationLogEntry>();
var logger = new InMemoryLogger(logEntries);
var middleware = new CommunicationMiddlewareService(logger);

// Endpoint: Log a communication event
app.MapPost("/log", (LogRequest req) =>
{
    if (string.IsNullOrWhiteSpace(req.Url) || string.IsNullOrWhiteSpace(req.Direction))
        return Results.BadRequest("Url and Direction are required.");
    var entry = new CommunicationLogEntry
    {
        Direction = req.Direction,
        Message = req.Message ?? string.Empty,
        Payload = new { Url = req.Url, Data = req.Payload }
    };
    middleware.HandleCreatioToExternal(entry.Message, entry.Payload); // Direction handled in logger
    return Results.Ok("Logged");
});

// Endpoint: Search logs by URL, return as HTML table or JSON
app.MapGet("/logs", (string url, string? format) =>
{
    var filtered = logEntries.Where(e => e.Payload is not null && e.Payload.ToString()!.Contains(url, StringComparison.OrdinalIgnoreCase)).ToList();
    if (format?.ToLower() == "html")
    {
        var html = "<table border='1'><tr><th>Timestamp</th><th>Direction</th><th>Message</th><th>Payload</th></tr>" +
            string.Join("", filtered.Select(e => $"<tr><td>{e.Timestamp:u}</td><td>{e.Direction}</td><td>{e.Message}</td><td>{JsonSerializer.Serialize(e.Payload)}</td></tr>")) +
            "</table>";
        return Results.Content(html, "text/html");
    }
    return Results.Json(filtered);
});

app.Run();

// Request model for logging
public record LogRequest(string Url, string Direction, string? Message, object? Payload);

// In-memory logger for demo
public class InMemoryLogger : ICommunicationLogger
{
    private readonly List<CommunicationLogEntry> _entries;
    public InMemoryLogger(List<CommunicationLogEntry> entries) => _entries = entries;
    public void Log(CommunicationLogEntry entry)
    {
        _entries.Add(entry);
    }
}
