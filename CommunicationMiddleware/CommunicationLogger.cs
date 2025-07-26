using System;

namespace CommunicationMiddleware
{
    /// <summary>
    /// Interface for logging communication between Creatio and external systems.
    /// </summary>
    public interface ICommunicationLogger
    {
        void LogCreatioToExternal(string message, object payload);
        void LogExternalToCreatio(string message, object payload);
    }

    /// <summary>
    /// Default implementation of ICommunicationLogger.
    /// </summary>
    public class CommunicationLogger : ICommunicationLogger
    {
        public void LogCreatioToExternal(string message, object payload)
        {
            // Implement logging logic here (e.g., write to file, database, etc.)
            Console.WriteLine($"[Creatio->External] {DateTime.UtcNow}: {message} | Payload: {payload}");
        }

        public void LogExternalToCreatio(string message, object payload)
        {
            // Implement logging logic here (e.g., write to file, database, etc.)
            Console.WriteLine($"[External->Creatio] {DateTime.UtcNow}: {message} | Payload: {payload}");
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

        public void HandleCreatioToExternal(string message, object payload)
        {
            _logger.LogCreatioToExternal(message, payload);
            // Add additional middleware logic here if needed
        }

        public void HandleExternalToCreatio(string message, object payload)
        {
            _logger.LogExternalToCreatio(message, payload);
            // Add additional middleware logic here if needed
        }
    }
}
