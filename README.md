\# Field Event Management System



A real-time Field Event Management System built with ASP.NET Core, Angular, SQL Server, SignalR and Clean Architecture.



\---



\## Architecture



```

Agent

&#x20;  │

&#x20;  ▼

ASP.NET Core API

&#x20;  │

&#x20;  ▼

Application Layer

&#x20;  │

&#x20;  ▼

Repository

&#x20;  │

&#x20;  ▼

SQL Server

&#x20;  │

&#x20;  ▼

SignalR

&#x20;  │

&#x20;  ▼

Angular Dispatcher

```



\---



\## Technologies



\### Backend



\- ASP.NET Core (.NET 10)

\- Entity Framework Core

\- SQL Server

\- SignalR

\- Swagger

\- Clean Architecture



\### Frontend



\- Angular

\- TypeScript

\- HttpClient

\- SignalR Client



\### Database



\- SQL Server

\- EF Core Migrations



\---



\## Features



\- Create Event

\- View Events

\- Assign Technician

\- Real-time updates with SignalR

\- Agent Simulation

\- Swagger API

\- SQL Server persistence



\---



\## API



\### Create Event



POST



```

/api/events

```



\### Get Events



GET



```

/api/events

```



\### Assign Technician



PUT



```

/api/events/assign

```



\---



\## Run



\### Backend



```

dotnet run --project backend/FieldEvents.Api

```



\### Angular



```

cd frontend/field-events-client



npm install



ng serve

```



\### Agent



```

dotnet run --project agent/FieldEvents.Agent

```



\---



\## Author



Yuli

