using System.Reflection;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }
        });

        // CORS: samme origin via nginx i prod; lokale origins + CORS_ORIGINS (kommasepareret)
        var corsOrigins = (builder.Configuration["CORS_ORIGINS"]
                ?? Environment.GetEnvironmentVariable("CORS_ORIGINS")
                ?? "https://h2.mercantec.tech")
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Concat(new[] { "http://localhost:5085", "http://localhost:8052" })
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowSpecificOrigins",
                policy =>
                {
                    policy
                        .WithOrigins(corsOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition");
                }
            );
        });

        // Tilføj basic health checks
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy(), ["live"]);

        var app = builder.Build();

        // Brug CORS - skal være før anden middleware
        app.UseCors("AllowSpecificOrigins");

        // Map health checks
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/alive", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains("live")
        });

        app.MapOpenApi();

        // Scalar Middleware for OpenAPI
        app.MapScalarApiReference(options =>
        {
            options
                .WithTitle("MAGSLearn")
                .WithTheme(ScalarTheme.Mars)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });

        // Map the Swagger UI
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        });

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
