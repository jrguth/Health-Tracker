using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Health.Web.Api.Client;

namespace Guth.Health.Web
{
    public class Program
    {
        private const string WEB_APP_ORIGIN = "Guth.Health.Web_Origin";
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient(
                "HoopApiClient",
                c => c.BaseAddress = new Uri("http://localhost:5000/graphql")
            );
            builder.Services.AddHoopApiClient();
            builder.Services.AddHttpClient<ApiProxyClient>(
                "HoopApiProxy",
                configureClient => configureClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            await builder.Build().RunAsync();
        }
    }
}
