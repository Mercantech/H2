# Blazor WebAssembly Frontend

## 📖 Oversigt
Frontend applikation bygget med Blazor WebAssembly til H2 projektet.

## 🏗️ Arkitektur
- **Framework:** Blazor WebAssembly (.NET 9)
- **UI Framework:** Bootstrap 5
- **State Management:** Built-in Blazor state
- **API Communication:** HttpClient via [[../Services/APIService]]

## 📁 Struktur
```
Blazor/
├── Components/          # Genbrugelige komponenter
│   ├── Counter.razor
│   ├── StatusCard.razor
│   └── WeatherTable.razor
├── Pages/              # Sider/Routes
│   └── Home.razor
├── Services/           # API kommunikation
│   └── APIService.cs
└── Layout/            # Layout komponenter
    ├── MainLayout.razor
    └── NavMenu.razor
```

## 🧩 Komponenter

### StatusCard
Viser API status information
- **Props:** Status type, message
- **Styling:** Bootstrap cards
- **Usage:** `<StatusCard Status="@apiStatus" />`

### WeatherTable
Viser vejrdata i tabel format
- **Data source:** [[../Backend-API/C-Sharp Web API#Weather Endpoints]]
- **Features:** Responsive design, sortable columns

## 🌐 Services
- [[APIService]] - HTTP kommunikation med backend
- [[APIService.Status]] - Status endpoints
- [[APIService.Weather]] - Weather endpoints

## 🎨 Styling
- **Framework:** Bootstrap 5
- **Custom CSS:** `wwwroot/css/app.css`
- **Icons:** Bootstrap Icons
- **Responsive:** Mobile-first design

## 🔗 Relaterede Noter
- [[../Backend-API/C-Sharp Web API]]
- [[Component Architecture]]
- [[Blazor Best Practices]]

---
**Tags:** #blazor #frontend #wasm #h2-projekt
**Sidst opdateret:** {{date}}
