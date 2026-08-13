# ejmabunda-web-api

A .NET 10 Web API backing a personal portfolio site — profile, experience, qualifications, skills, projects, and certifications.

## Tech stack

- ASP.NET Core 10 (Web API, controllers)
- Entity Framework Core (In-Memory provider)
- NSwag / OpenAPI (Swagger UI in development)

## Getting started

```bash
dotnet restore
dotnet run
```

In development, the OpenAPI document is served at `/openapi/v1.json` with Swagger UI available for exploring the API.

## Project structure

```
Controllers/   API endpoints
Models/        Domain entities (Profile, Experience, Qualification, Skill, Project, Certification, ...)
docs/erd/      Entity relationship diagram (dbml source + generated svg)
```

## Data model

See [`docs/erd/portfolio-erd.dbml`](docs/erd/portfolio-erd.dbml) for the source of truth, or view the rendered diagram at [`docs/erd/portfolio-erd.svg`](docs/erd/portfolio-erd.svg).
