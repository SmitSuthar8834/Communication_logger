# CreatioLoggerPkg

This Creatio package registers your CommunicationLoggerApi as an external web service for plug-and-play logging integration.

## How to Use
1. Update the `url` in `Schemas/Usr_CommunicationLoggerService.ws` to your actual API host (e.g., `http://yourserver:5006/`).
2. Import this package into Creatio (System Designer → Installed Applications → Add Application → Import from file).
3. The web service will be available for use in business processes and scripts as `Usr_CommunicationLoggerService`.
4. Use the `Log` and `GetLogs` methods in your business processes to log and view communication events.

## Endpoints
- **Log** (POST `/log`): Log a communication event.
- **GetLogs** (GET `/logs`): Search logs by URL and format.

---

You can further customize this package by adding business processes or UI elements as needed.
