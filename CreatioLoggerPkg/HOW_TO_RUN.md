# How to Run the CreatioLoggerPkg

This guide explains how to use the CreatioLoggerPkg in your Creatio environment.

## 1. Prerequisites
- The CommunicationLoggerApi (your .NET API) must be hosted and accessible from your Creatio instance. See HOW_TO_HOST.md for details.

## 2. Import the Package into Creatio
1. In Creatio, go to **System Designer → Installed Applications**.
2. Click **Add Application → Import from file**.
3. Select the `CreatioLoggerPkg` folder (zipped) or its contents as a package.
4. Complete the import process.

## 3. Configure the Web Service
- After import, go to **System Designer → Web Services**.
- Find `Usr_CommunicationLoggerService`.
- Edit the service and update the base URL to match your API host (e.g., `http://yourserver:5006/`).

## 4. Use in Business Processes
- In the process designer, add a **Call Web Service** element.
- Select `Usr_CommunicationLoggerService` and choose the `Log` or `GetLogs` method.
- Map the parameters as needed.

## 5. Test
- Run your business process or use the web service from a script to log and view communication events.

---

For more details, see the README in this package or your main project.
