# C# Web API Dokumentation

## 📖 Oversigt
Dette er dokumentation for vores H2 projekt's Web API bygget med C# og .NET 9.

## 🏗️ Arkitektur
- **Framework:** .NET 9
- **Pattern:** RESTful API
- **Hosting:** Docker container
- **Port:** Se [[../compose.yaml]] for konfiguration

## 📡 Endpoints

### Status Endpoints
- `GET /api/status` - [[API Health Check]]
- `GET /api/status/health` - Detaljeret health check
- `GET /api/status/database` - Database forbindelse status

### Weather Endpoints  
- `GET /api/weatherforecast` - [[Weather Forecast API]]

## 🔧 Konfiguration
Se [[API Configuration]] for detaljerede indstillinger.

## 🧪 Testing
Brug [[Bruno/H2/Status/]] for API testing.

## 🔗 Relaterede Noter
- [[../Frontend-Blazor/Blazor WASM]]
- [[API Configuration]]
- [[Database Setup]]

---
**Tags:** #api #csharp #dotnet #h2-projekt
**Sidst opdateret:** {{date}}