
# How to Run the CreatioLoggerPkg

This guide explains how to use the CreatioLoggerPkg in your Creatio environment.

## 1. Prerequisites
- **You must host the CommunicationLoggerApi (your .NET API) and make it accessible from your Creatio instance.**
  - See HOW_TO_HOST.md for hosting instructions.
  - The Creatio package only registers the web service; it does not host the API itself.

## 2. Import the Package into Creatio
1. Zip the contents of the `CreatioLoggerPkg` folder (not the folder itself, but its contents).
2. In Creatio, go to **System Designer → Installed Applications**.
3. Click **Add Application → Import from file**.
4. Select your zipped package and upload it.
5. Complete the import process.

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

**Summary:**
- You must host the CommunicationLoggerApi separately (IIS, cloud, etc.).
- The Creatio package only registers the web service for plug-and-play use in Creatio.

For more details, see the README in this package or your main project.
