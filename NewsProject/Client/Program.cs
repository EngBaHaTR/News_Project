using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewsProject.Client;
using NewsProject.Client.Components;
using NewsProject.Client.Pages;
using NewsProject.Client.Repo;
using NewsProject.Shared.Models;

namespace NewsProject.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<MainInterface<Category>, MainServices<Category>>();
            builder.Services.AddScoped<MainInterface<CatehoryNew>, MainServices<CatehoryNew>>();
            await builder.Build().RunAsync();
        }
    }
}
