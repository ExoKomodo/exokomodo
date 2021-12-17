using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Client.Http;
using Client.Services;

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
            builder.Services.AddHttpClient<ServerApiClient>(
                client => {
                    client.BaseAddress = new Uri(
                        #if DEBUG
                        "https://localhost:5001/api/"
                        #else
                        "https://services.exokomodo.com/api/"
                        #endif
                    );
                }
            );
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<UserService>();

            ConfigureJorsonServices(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureJorsonServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Services.Jorson.BlogService>();
        }
    }
}
