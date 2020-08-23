using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ExoKomodo.Pages.Users.Jorson.Helpers;

namespace ExoKomodo
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            ConfigureJorsonServices(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureJorsonServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddTransient<JsonDb<int, Models.Jorson.Blog>, Pages.Users.Jorson.Blogs.BlogDb>();
        }
    }
}
