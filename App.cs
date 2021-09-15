using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

public class App : IHostedService {

    private readonly ILogger logger;
    private readonly IHostApplicationLifetime appLifetime;
    private readonly IConfiguration config;
    private readonly PizzaDataService dataService;
    private readonly PizzaDisplayService displayService;

    public App(
        IHostApplicationLifetime appLifetime,
        ILogger<App> logger,
        IConfiguration config,
        PizzaDataService dataService,
        PizzaDisplayService displayService
    ) {
        this.appLifetime = appLifetime;
        this.logger = logger;
        this.config = config;
        this.dataService = dataService;
        this.displayService = displayService;
    }

    public async Task StartAsync(CancellationToken token) {

        try {

            // gathering of args could be more elaborate, but its easy enough
            var request = config.GetValue<string>("q");
            var limit = config.GetValue<int?>("top");

            switch(request) {
                case "ListToppings": {
                    var result = await dataService.GetToppings();
                    displayService.PrintToppings(result, limit);
                    break;
                }
                case "ListCombinations": {
                    var result = await dataService.GetCombinations();
                    displayService.PrintCombinations(result, limit);
                    break;
                }
                default: {
                    Console.WriteLine("Please re-read program usage in README.md");
                    break;
                }
            }
        }
        catch (Exception ex) {
            logger.LogError(ex, "Application error");
        }

        appLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken token) {
        return Task.CompletedTask;
    }
}