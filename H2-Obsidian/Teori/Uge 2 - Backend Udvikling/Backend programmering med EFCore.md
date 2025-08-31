---
aliases:
cssclasses:
tags:
  - api
---
# Backend programmering med C# og Entity Framework

## Introduktion

Når vi skal bygge en API, er det database og forretningslogik som er hoved fokus. Vi skal dog, ligesom på H1, have en måde at snakke med databasen. Vi bruger som standart, her på H2 [Entity Framework](https://www.notion.so/Entity-Framework-75287e0b054f4499a30360bc3f43fda1?pvs=21) som data acces lag og [Postgres](https://www.notion.so/Postgres-8cc8c43f8f994ef4a50af8986a9a1e4c?pvs=21) som datastore.




![[Hvad er EFCore]]
## Læringsmål

- Forstå hvad EF Core er, og hvordan det bruges i .NET-projekter.
- Oprette og konfigurere en database med EF Core.
- Oprette datamodeller og DbContext-klasser.
- Udføre migrationer og opdatere databasen.
- Bygge et Web API med CRUD-endpoints (Create, Read, Update, Delete).
- Teste API’et med fx Postman.
- Forstå sammenhængen mellem API, EF Core og database.

## API - Applikation Programming Interface

I har allerede lært at bruge en REST API i mindre grad, men nu skal vi kigge på bygge en selv. På jeres første hoved forløb, lavede vi en databaseservices fil som håndterede alt logikken til at kontakte vores relations database. Her er det

### Hvorfor bruge en 3-lags arkitektur?

På H1 brugte vi en 2-lags med [Blazor](https://www.notion.so/Blazor-db3407ecc592435984c8868c23d7152a?pvs=21) på vores præsentationslag og applikationslag som havde direkte adgang til vores [Database](https://www.notion.so/Database-1ba72e49d14c4ff6be8e1eabdc94d316?pvs=21) igennem [ADO.NET](https://www.notion.so/ADO-NET-3b3c18cd2eba409f824ae82c6e9d933c?pvs=21). Der virkede ret fint og var forholdsvis nemt at holde styr på, men hvorfor skal vi så bruge en 3-lags struktur som ses nedenfor? ⬇

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/972707fa-097a-406b-bac7-9d8136919b3a/Untitled.png)

Med en 3-lags struktur har opdeler vi præsentationslaget og applikationslaget, som ellers var samlet før.

## Opsætning af EFCore med Postgres

Vi skal opsætte EFCore for første gang, herunder er der en guide til hvordan vi kommer i gang med det! *Projektet er allerede opretter i jeres GitHub Repo så første del er bare dokumentation på hvordan det er gjort!

# Opsætning og filgennemgang

## Opsætning af standart API Projekt

![ASP.NET Core Web API er standarten indenfor API-teknologi med C# og .NET. Der kommer en del med, når vi laver projektet, men langt det meste skal vi selv opbygge efter behov!](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/d3c57c11-f326-4b22-91e0-d7ea12a2c464/Untitled.png)

[ASP.NET](http://ASP.NET) Core Web API er standarten indenfor API-teknologi med C# og .NET. Der kommer en del med, når vi laver projektet, men langt det meste skal vi selv opbygge efter behov!

![Vi bruger .NET 8.0 og tilføjer alt udover Authentication, fordi vi selv skal bygge det og Aspire, da det kan skabe lidt forvirring! Dog vil vi gerne have container support, så vi kan bruge Docker!](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/62155e1d-83af-41a6-89aa-b43dcfa8a2f0/Untitled.png)

Vi bruger .NET 8.0 og tilføjer alt udover Authentication, fordi vi selv skal bygge det og Aspire, da det kan skabe lidt forvirring! Dog vil vi gerne have container support, så vi kan bruge [Docker](https://www.notion.so/Docker-1635859d6bd54a658e0aef704851e34d?pvs=21)!

Vi skal starte med at installere følgende pakker til vores [ASP.NET](http://ASP.NET) Core Web API

[Microsoft.EntityFrameworkCore 9.0.8](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)

[Microsoft.EntityFrameworkCore.Tools 9.0.8](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/)

[Npgsql.EntityFrameworkCore.PostgreSQL 9.0.4](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL)

Gælder kun hvis I bruger [Postgres](https://www.notion.so/Postgres-8cc8c43f8f994ef4a50af8986a9a1e4c?pvs=21), som vi gøre på følgende guide!

[Microsoft.EntityFrameworkCore.SqlServer 9.0.8](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)

Følgende skal bruges, hvis man udvikler på [MSSQL](https://www.notion.so/MSSQL-284593e031de4825889b51a594afc4db?pvs=21) også kaldet SQL Server

## Filgennemgang

Efter vi har hentet pakkerne, kan vi starte på at opsætte projektet. På nuværende tidspunkt burde i gerne have følgende filer I jeres løsning! Lad os lige gå igennem dem alle og se på hvad de gør

`Connected Services` bruger vi ikke for den her løsning, så den går vi ikke over

`Dependencies` kommer vi til at bruge i løbet af projektet, jeres Nuget Packages burde gerne matche den her →

`Properties` er som for alle andre [ASP.NET](http://ASP.NET) projekter. Her styre vi om det skal startes som HTTP, HTTPS, IIS eller Docker.

`Controllers` er vigtig for vores projekt, det er her vi specificere hvad der skal være tilgængelig på vores API og hvilke end-points der skal være tilgængelige. Vi gennemgår den herunder!

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/bec93fe2-fa65-4f6b-bb3a-07835e03f5a8/Untitled.png)

`appsettings.json` er som vi kender den, her kan vi holde vigtig information som vores database streng.

`Dockerfile` er filen som gør at vi kan starte applikationen i en container fx på [Render](https://www.notion.so/Render-52dc063276e8436ca4aff7ca274c645b?pvs=21)!

`Program.cs` indeholder vores builder, her starter vi vores program. Den gennemgår vi også senere

`WeatherForecast.cs` indeholder vores klasse, fordi som meget andet C# bygges projektet med [OOP](https://www.notion.so/OOP-8f3215b1a8db4ce4a23a55769c00253c?pvs=21) i fokus!

`WebAPI.http` kan vi bruge til at teste vores API, vi kommer dog til at fokusere på [Swagger](https://www.notion.so/Swagger-ce1f7978b3214798a30b3466988bac47?pvs=21) og [Postman](https://www.notion.so/Postman-9f30d7b5dec64facb34cc2eff24c4092?pvs=21) til debugging og generelle test!

### `Controllers` & `Program.cs`

Man kan se `WeatherForecastController.cs` controlleren neden under. Vi tager lige nogle vigtig linjer ud!

`[ApiController]` & `[Route("[controller]")]` fortæller [ASP.NET](http://ASP.NET) at det efterfølgende er en API-Controller samt at ruten til at tilgå det specificeres ud fra hver enkel klasse. Så i det her eksempel er **`https://localhost:7213/WeatherForecast`** ruten for at tilgå vores kontroller.

`[HttpGet(Name = "GetWeatherForecast")]` her specifiere vi hvilken [HTTPS](https://www.notion.so/HTTPS-039d6ac212334b8b94b09b38b3f2f23a?pvs=21) protokol vi skal bruge. Den er kun konfigureret til `GET` som svare til et read på Database lag, senere ser vi hvordan vi konfigurere resten af CRUD operationerne, altså `POST`, `PUT` og `DELETE`

```csharp
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
```

`Program.cs` er noget kortere og noget vi har set i mange andre [ASP.NET](http://ASP.NET) projekter!

Mange af dem handler om at tilføje vores kontrollers til API’en. Det er hoveddelen af vores projekt. Et par andre der er værd at nævne er `AddEndpointsApiExplorer();` & `AddSwaggerGen();` de tilføjer [Swagger](https://www.notion.so/Swagger-ce1f7978b3214798a30b3466988bac47?pvs=21) som er et OpenAPI produkt, det gør det dejlig nemt at teste vores applikation!

<aside> 🚨 Hvis man vil teste det på en hosting løsning, er det vigtigt at fjerne vores if-statement. Ellers bliver Swagger-ui ikke tilføjet, så det kan være mere besværligt at teste. Dog skal det fjernes, hvis det er et reelt produkt.

</aside>

```csharp
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            ~~if (app.Environment.IsDevelopment())~~
            ~~{~~
                app.UseSwagger();
                app.UseSwaggerUI();
            ~~}~~

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
```

## Udskift Swagger med Scalar - Optional

Swagger bliver fjernet som en standart fra .NET 9.0 og frem. Man kan stadig tilføje den, hvis man er glad for deres UI og måden man bruger det på! Hvis man hellere vil prøve en ny platform kan man installere Scalar som har nogle fordele fremfor [Swagger](https://www.notion.so/Swagger-ce1f7978b3214798a30b3466988bac47?pvs=21)!

Vi skal starte med at hente NuGet pakken her - [https://www.nuget.org/packages/AspNetCore.Scalar/](https://www.nuget.org/packages/AspNetCore.Scalar/)

Bagefter kan vi tilføje den til vores program.cs her er for .NET 8.0

```csharp
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.MapScalarApiReference(options =>
{
    options.OpenApiRoutePattern = "/swagger/v1/swagger.json";
});
```

Nu har vi mulighed for at åbne siden `scalar/v1` som har vores nye UI. Som standart åbner .NET 8.0 stadig swagger ved opstart, det kan vi ændre i `launchSettings.json` med følgende

```json
 "https": {
   "commandName": "Project",
   "launchBrowser": true,
   "launchUrl": "scalar/v1",
   "environmentVariables": {
     "ASPNETCORE_ENVIRONMENT": "Development"
   },
   "dotnetRunMessages": true,
   "applicationUrl": "<https://localhost:7087>;<http://localhost:5145>"
 },
```

## Opsætning af database

### Database på Neon.tech

I guiden her bruger vi [neon.tech](http://neon.tech) til at opsætte en [Postgres](https://www.notion.so/Postgres-8cc8c43f8f994ef4a50af8986a9a1e4c?pvs=21) database som vi kan bruge til vores projekt.

Når I har oprettet jer, kan man fra ens dashboard få adgang til den connection string vi skal bruge.

Den skal formateres om til at passe til .NET og det kan vi gøre på følgende måde!

**Original**

postgresql://Elev:********@ep-shrill-king-02053617.eu-central-1.aws.neon.tech/Mercantec?sslmode=require

Version som virker i .NET

Host=ep-shrill-king-02053617.eu-central-1.aws.neon.tech;Username=Elev;Password=***;Database=Mercantec;sslmode=require;

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/aae4c40a-c6b3-4b4a-b176-e64b95b62a09/Untitled.png)

I kan eventuelt bruge følgende converter, for nemhed: [Blazor.Mercantec.Tech/DBConverter](https://blazor.mercantec.tech/DBConverter)

Den placere vi i appsettings.json til senere brug i hele applikationen.

```json
"ConnectionStrings": {
  "DefaultConnection": 
  "Host=ep-shrill-king-02053617.eu-central-1.aws.neon.tech;
  Username=Elev;
  Password=**********;
  Database=Mercantec;
  sslmode=require;"
}
```

Husk at lave en .gitignore fil for jeres appsettings.json, så I ikke komme til at offentliggøre jeres database streng på GitHub!

## Opsætning af Entity Framework :efcore-logo-ppl:

EF Core er vores valgte **ORM** (Object Relational Mapping). Det er Microsofts officielle løsning, som gør det muligt at arbejde med databaser gennem C#-objekter i stedet for at skrive al SQL manuelt.

Dokumentationen findes her: [EF Core på Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/)

En ORM fungerer som et **bindeled mellem din kode og databasen**:

- Du skriver klasser i C# (f.eks. `User`, `Booking`, `Room`)
- EF Core oversætter automatisk disse klasser til tabeller i databasen
- Når du ændrer objekter i koden, genererer EF Core SQL-forespørgsler i baggrunden

![image.png](attachment:883785db-45b5-4e08-a2a2-b4bb35d3f39d:97a717ff-b6cd-43ed-979c-20eabb2108cc.png)

Fordelene ved at bruge en ORM som EF Core er:

- Mindre manuel SQL – fokus på logik fremfor syntaks
- Stærk typesikkerhed (compile-time fejl i stedet for runtime fejl)
- Bedre vedligeholdelse, da model og database holdes synkroniseret
- Mulighed for **migrations**, som automatisk opdaterer databasen, når modellen ændres

---

Vi har hentet alle de pakker vi skal bruge og er nu klar til at opsætte EFCore i vores projekt. Vi starter med at tilføje følgende til `Program.cs` -filen. Husk at gøre det inden linjen med - `var app = builder.Build();`

```csharp
IConfiguration Configuration = builder.Configuration;

string connectionString = Configuration.GetConnectionString("DefaultConnection") 
?? Environment.GetEnvironmentVariable("DefaultConnection");

builder.Services.AddDbContext<AppDBContext>(options =>
		options.UseNpgsql(connectionString));
```

Som vi kan se bruger vi `AppDBContext`, som er en fil vi selv har lavet. Den ser vi lidt på her!

```csharp
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }
}
```

Da vi har konfigureret vores connection-streng i `Program.cs` filen, behøver vi ikke yderligere information indtil nu med vores `AppDBContext.cs`.

Nu er EFCore teknisk set blevet sat op, men vi mangler at tilføje nogle modeller som skal mappes til tabeller i vores SQL-database.

```csharp
public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Common &&
                            (e.State == EntityState.Added 
                            || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (Common)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (string.IsNullOrEmpty(entity.Id))
                    {
                        entity.Id = Guid.NewGuid().ToString();
                    }
                    entity.CreatedAt = DateTime.UtcNow;
                }

                entity.UpdatedAt = DateTime.UtcNow;
            }
        }   
```

## Design af User tabel

Den første tabel i vores system, er næsten altid en User tabel.

### Opsætning af User modellen til JWT og BCrypt

Vi opretter 2 modeller (klasser) til at starte med, en `Common.cs` og en `User.cs`. Begge bliver enten placeret i en “Models” mappe i vores API projekt eller i et Class Library

Vi starter med at se på `Common.cs`

```csharp
public class Common
{
    [Key]
    public string Id { get; set; } // Kan erstattes med "int Id"
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```

Formålet med `Common.cs` er at alle klasser som har relation til databasen skal arve fra den. Id, CreatedAt og UpdatedAt er alle gode at have i vores database som standart.

```csharp
public class User : Common
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string HashedPassword { get; set; }
    public required string Salt {  get; set; }
    public DateTime LastLogin { get; set; }
    
    public string PasswordBackdoor {  get; set; } 
    // Only for educational purposes, not in the final product!
}
```

Vi laver en ret standart `User.cs` klasse som arver fra vores Common. Der kan være langt flere felter, som vi tilføjer senere, men det her er en god basis for en User klasse.

Der er tilføjet en backdoor til password, som selvfølgelig ikke skal med i produktion eller i et rigtig projekt. Her bruger vi bare til at se hvordan hashing med salt fungere.

### Tilføje klasser til databasen - DbSet<T>

For at mappe vores klasser til tabeller i databasen skal vi bruge den indbyggede DbSet fra EFCore. [https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1?view=efcore-8.0](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1?view=efcore-8.0)

Her redigere vi vores `AppDBContext.cs` klasse, til også at inkludere vores User model.

```csharp
public DbSet<User> Users { get; set; }
```

Nu er vi klar til at sende vores ændringer ned til en database, inden det skal vi lave en migration

### Migrationer - add-migraiton

Migrationer er vores måde at oprette og vedligeholde tabeller i vores database. Med EFCore kan vi automatisk genere migrationer ud fra vores `AppDBContext` og ud fra hvordan vores klasser er struktureret. Her bruger vi pakken [Microsoft.EntityFrameworkCore.Tools 8.0.3](https://www.notion.so/7b95713ed6eb47a8a4e815770f98a1fe?pvs=21) - som giver os adgang til kommandoer i Package Manager Console (PM). Den første kommando vi skal lære at bruge er `add-migration` - vores `AppDBContext` er faktisk klar til den første migration. Vi åbner PM og skriver følgende `add-migration init-user` , herefter bliver der oprettet mappen “Migrations” og en fil der slutter med `init-user.cs` . I den fil er der beskrevet hvordan migrationen adaptere databasen til at passe med vores klasser.

```csharp
public partial class inituser : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<string>(type: "text", nullable: false),
                Email = table.Column<string>(type: "text", nullable: false),
                Username = table.Column<string>(type: "text", nullable: false),
                HashedPassword = table.Column<string>(type: "text", nullable: false),
                Salt = table.Column<string>(type: "text", nullable: false),
                LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                passwordBackdoor = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Users");
    }
}
```

### Visualisere databasen - EFCore Powertools

Vi kan bruge en Visual Studio Extension kaldet [**EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools).**

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/5d8c5e1d-3cc6-4164-8d47-35c1bfa69c7b/Untitled.png)

Der er mange funktioner, men det vi bruger her hedder **Add DbContext Diagram.** Den laver et diagram over vores database ud fra migrations-mappen, det betyder også at vi ikke behøver at opdatere vores database for at få diagrammet og vi derfor kan tjekke inden, hvad vi faktisk har konfigureret.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/dd8b0959-2bbb-450a-b71a-f9e097589492/Untitled.png)

### Opdatere databasen - Update-database

Efter at vi har tjekket vores migrationsfil og eventuelt DbContext Diagrammet, er vi nu klar til at skubbe det til vores database. Det gør vi også fra vores PM med kommandoen `Update-database` som selv holder øje med hvor mange migrationer som mangler at bliver lagt ud på databasen.

Hvis den ikke melder fejl, burde alt være i orden på databasesiden. Det kan vi tjekke med et værktøj såsom [TablePlus](https://www.notion.so/TablePlus-2a0a31812a334378b66298b509dcdcd3?pvs=21).

Vi forbinder med de samme informationer som er i vores appsettings.json

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/78111fd7-5d55-4196-af1c-1918b8dd24a0/eb11b3ee-62fb-4369-96c7-3a9747301d03/Untitled.png)

Herfra kan vi verificere at vores SQL struktur matcher vores ønsker fra EFCore. Udover det ser vi også en _EFMigrationsHistory tabel, som indeholder et ID på vores migration og matcher med vores migrationsmappe fra projektet.

![[DatabaseStruckture.png]]