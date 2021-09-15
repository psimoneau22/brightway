using System.Collections.Generic;
using System.Text.Json.Serialization;

public class PizzaResponse {

    [JsonPropertyName("toppings")]
    public List<string> Toppings {get;set;}
}