using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task<int> Main(string[] args)
    {
        await CreateHost(args).RunConsoleAsync();
        return 0;
    }

    static IHostBuilder CreateHost(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(AddServices);

    static void AddServices(HostBuilderContext context, IServiceCollection services) {
        services
            .AddHostedService<App>()
            .AddTransient<PizzaDataService>()
            .AddTransient<PizzaDisplayService>()
            .AddHttpClient<BrightWayService>(client => {
                client.BaseAddress = new Uri(context.Configuration.GetValue<string>("brightwayApiBaseAddress"));
            });
    }
}
