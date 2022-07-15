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
            builder.Services.AddSingleton<WebringService>();

            ConfigureJorsonServices(builder);
            ConfigureTorsonServices(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureJorsonServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Client.Services.Jorson.BlogService<Client.Models.Jorson.Blogs.Blog<int>>>();
            builder.Services.AddSingleton<Client.Services.Jorson.BlogService<Client.Models.Jorson.Blogs.GeneralBlog>>();
            builder.Services.AddSingleton<Client.Services.Jorson.BlogService<Client.Models.Dabby.Blogs.RamenBlog>>();
            builder.Services.AddSingleton<Client.Services.Jorson.FoodBlogService>();
        }

        private static void ConfigureTorsonServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Client.Services.Torson.BlogService<Client.Models.Torson.Blogs.Blog<int>>>();
            builder.Services.AddSingleton<Client.Services.Torson.BlogService<Client.Models.Torson.Blogs.GeneralBlog>>();
        }
    }
}
