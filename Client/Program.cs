using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Client.Pages.Users.Jorson.Helpers;
using System.Reflection;
using Client.Http;

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
            builder.Services.AddHttpClient<ApiClient>(
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

            ConfigureJorsonServices(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureJorsonServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddTransient<JsonDb<int, Models.Jorson.Blog>, Pages.Users.Jorson.Blogs.BlogDb>();
            builder.Services.AddTransient<JsonDb<int, Models.Dabby.Blog>, Pages.Users.Dabby.RamenBlog.RamenBlogDb>();
        }
    }
}
