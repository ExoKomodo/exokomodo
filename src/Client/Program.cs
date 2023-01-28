using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Client.Http;
using Client.Services;
using Client.Services.Jorson;
using Client.Services.Torson;
using Client.Models;

namespace Client
{
  public static class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient<LocalClient>(
                client => {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                }
            );

            builder.Services.AddSingleton<WebringService>();

            ConfigureDabbyServices(builder);
            ConfigureJorsonServices(builder);
            ConfigureTorsonServices(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureDabbyServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Client.Services.Dabby.RamenBlogService>();
        }

        private static void ConfigureJorsonServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Client.Services.Jorson.LifeBlogService>();
            builder.Services.AddSingleton<Client.Services.Jorson.FoodBlogService>();
        }

        private static void ConfigureTorsonServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Client.Services.Torson.LifeBlogService>();
            builder.Services.AddSingleton<Client.Services.Torson.BabyCarrierBlogService>();
            builder.Services.AddSingleton<Client.Services.Torson.BookBlogService>();
        }
    }
}
