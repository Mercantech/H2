# H2-Projekt {Indsæt gruppenavn}

Projektet han findes her - [H2 Projekt forløb på Notion](https://mercantec.notion.site/h2f)

Det er delt op i 4 mapper (3 hovedprojekter og Aspire)

## [Blazor](/Blazor/)

Vi anbefaler at I bruger Blazor WebAssembly, da det er det vi underviser i. Den er koblet op på vores API gemmen APIService klassen i Blazor.

## [Domain Models](/DomainModels/)

Her er alle jeres klasser, som I skal bruge til jeres Blazor og API.
Domain Models / Class Libary versionen er nu opdateret til .NET 9.0

## [API](/API/)

Her er jeres API, den bruger vi til at forbinde sikkert til vores database og for at fodre data til vores Blazor Projekt.
ASP.NET Core Web API versionen er nu opdateret til .NET 9.0

## [Aspire](/H2-Projekt.AppHost/)

Aspire er vores hosting platform, den er koblet op til vores API og Blazor. Det er ikke obligatorisk at bruge Aspire, men det anbefales. Vi bruger Aspire med .NET 9.0

### Hosting

Live-skabelon: **https://h2.mercantec.tech** (`web` via Traefik, `/api` → intern API).

```bash
cp .env.example .env
docker compose up -d --build
```

Lokalt: `docker compose -f docker-compose.yml -f docker-compose.local.yml up --build`
