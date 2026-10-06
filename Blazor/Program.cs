using System;
using System.Net.Http;
using Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // Relative /api/ bag nginx (Docker/Dokploy), ellers env / fallback
        var envApiEndpoint = Environment.GetEnvironmentVariable("API_ENDPOINT");
        var apiEndpoint = string.IsNullOrWhiteSpace(envApiEndpoint)
            ? new Uri(new Uri(builder.HostEnvironment.BaseAddress), "api/").AbsoluteUri
            : envApiEndpoint;
        Console.WriteLine($"API Endpoint: {apiEndpoint}");

        // Registrer HttpClient til API service med konfigurerbar endpoint
        builder.Services.AddHttpClient<APIService>(client =>
        {
            client.BaseAddress = new Uri(apiEndpoint);
            Console.WriteLine($"APIService BaseAddress: {client.BaseAddress}");
        });

        await builder.Build().RunAsync();
    }
}
