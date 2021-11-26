using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using HIN_ventures.Client.Service;
using HIN_ventures.Client.Service.IService;
using Microsoft.Extensions.Configuration;

namespace HIN_ventures.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = 
                new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IAssignmentService, AssignmentService>();
                await builder.Build().RunAsync();
        }
    }
}
