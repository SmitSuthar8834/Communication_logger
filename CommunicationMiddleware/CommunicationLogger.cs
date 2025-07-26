using System;

namespace CommunicationMiddleware
{
    /// <summary>
    /// Interface for logging communication between Creatio and external systems.
    /// </summary>

    /// <summary>
    /// Structured log entry for communication events.
    /// </summary>
    public class CommunicationLogEntry
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Direction { get; set; } = string.Empty; // "CreatioToExternal" or "ExternalToCreatio"
        public string Message { get; set; } = string.Empty;
        public object? Payload { get; set; }
    }

    public interface ICommunicationLogger
    {
        void Log(CommunicationLogEntry entry);
    }

    /// <summary>
    /// Default implementation of ICommunicationLogger.
    /// </summary>

    /// <summary>
    /// Default logger: logs to console and file.
    /// </summary>
    public class CommunicationLogger : ICommunicationLogger
    {
        private readonly string _logFilePath;

        public CommunicationLogger(string logFilePath = "communication_log.txt")
        {
            _logFilePath = logFilePath;
        }

        public void Log(CommunicationLogEntry entry)
        {
            string logLine = $"[{entry.Direction}] {entry.Timestamp:u}: {entry.Message} | Payload: {entry.Payload}";
            Console.WriteLine(logLine);
            try
            {
                System.IO.File.AppendAllText(_logFilePath, logLine + System.Environment.NewLine);
            }
            catch { /* Handle file I/O errors as needed */ }
        }
    }

    /// <summary>
    /// Example: custom logger for database or external log service.
    /// </summary>
    public class CustomCommunicationLogger : ICommunicationLogger
    {
        public void Log(CommunicationLogEntry entry)
        {
            // Implement custom storage logic (e.g., database, API call)
        }
    }

    /// <summary>
    /// Middleware service for handling communication logs.
    /// </summary>
    public class CommunicationMiddlewareService
    {
        private readonly ICommunicationLogger _logger;

        public CommunicationMiddlewareService(ICommunicationLogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Log a request from Creatio to an external system.
        /// </summary>
        public void HandleCreatioToExternal(string message, object payload)
        {
            var entry = new CommunicationLogEntry
            {
                Direction = "CreatioToExternal",
                Message = message,
                Payload = payload
            };
            _logger.Log(entry);
            // Add additional middleware logic here if needed
        }

        /// <summary>
        /// Log a request from an external system to Creatio.
        /// </summary>
        public void HandleExternalToCreatio(string message, object payload)
        {
            var entry = new CommunicationLogEntry
            {
                Direction = "ExternalToCreatio",
                Message = message,
                Payload = payload
            };
            _logger.Log(entry);
            // Add additional middleware logic here if needed
        }
    }
}
