# How to Host CommunicationLoggerApi

This guide explains how to host your CommunicationLoggerApi (ASP.NET Core Web API) so it can be accessed by Creatio or other systems.

## 1. Build the Project

Open a terminal in your project root and run:

```
dotnet publish CommunicationLoggerApi/CommunicationLoggerApi.csproj -c Release -o ./publish
```

This will create a `publish` folder with all necessary files.

## 2. Hosting Options

### A. Run Locally (for testing)
```
dotnet ./publish/CommunicationLoggerApi.dll
```
- The API will be available at `http://localhost:5006` (or as shown in the console output).

### B. Host on IIS (Windows Server)
1. Install the [ASP.NET Core Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-7.0.10-windows-hosting-bundle) on your server.
2. Copy the `publish` folder to your server.
3. In IIS Manager, create a new site or application pointing to the `publish` folder.
4. Set the application pool to "No Managed Code".
5. Bind to a port (e.g., 5006) and ensure firewall rules allow access.

### C. Host on Linux (Kestrel)
1. Copy the `publish` folder to your Linux server.
2. Run:
```
dotnet CommunicationLoggerApi.dll
```
3. (Optional) Use a reverse proxy (Nginx/Apache) to expose the API on a public port.

### D. Host in the Cloud
- Deploy to Azure App Service, AWS Elastic Beanstalk, or any cloud provider that supports .NET Core.

## 3. Make the API Accessible
- Ensure the API is reachable from your Creatio instance (public IP or VPN).
- Test by opening `http://yourserver:5006/logs?url=test&format=html` in a browser.

## 4. Register in Creatio
- Follow the README instructions to register the API as a web service in Creatio.

---

For more details, see the official Microsoft docs: https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/
