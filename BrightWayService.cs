using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class BrightWayService {
    private readonly HttpClient http;
    private readonly ILogger logger;

    public BrightWayService(HttpClient http, ILogger<BrightWayService> logger) {
        this.http = http;
        this.logger = logger;
    }

    public async Task<List<PizzaResponse>> GetPizzaToppings() {
        logger.LogInformation($"Calling Pizza api");

        var response = await http.GetAsync("pizzas.json");
        if(response.IsSuccessStatusCode) {

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var content = await JsonSerializer.DeserializeAsync<List<PizzaResponse>>(responseStream);
            return content;
        }

        logger.LogError($"Api Pizza response was invalid: Response Code: {response.StatusCode}");
        return new List<PizzaResponse>();
    }
}