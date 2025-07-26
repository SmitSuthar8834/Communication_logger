{
  "uId": "b1a1e1c0-0000-0000-0000-000000000002",
  "name": "Usr_CommunicationLoggerService",
  "packageUId": "b1a1e1c0-0000-0000-0000-000000000001",
  "parentSchemaUId": null,
  "createdInPackageId": "b1a1e1c0-0000-0000-0000-000000000001",
  "entitySchemaUId": null,
  "type": "WebService",
  "caption": "Communication Logger API",
  "url": "http://yourserver:5006/",
  "methods": [
    {
      "name": "Log",
      "requestType": "POST",
      "path": "log",
      "parameters": [
        { "name": "Url", "type": "string" },
        { "name": "Direction", "type": "string" },
        { "name": "Message", "type": "string" },
        { "name": "Payload", "type": "object" }
      ]
    },
    {
      "name": "GetLogs",
      "requestType": "GET",
      "path": "logs",
      "parameters": [
        { "name": "url", "type": "string" },
        { "name": "format", "type": "string" }
      ]
    }
  ]
}
