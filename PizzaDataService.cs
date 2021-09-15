using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

// If needed
// public interface IPizzaDataService {
//     Task<List<PizzaTopping>> GetToppings();
//     Task<List<PizzaConfiguration>> GetCombinations();
// }

public class PizzaDataService {

    private readonly BrightWayService brightwayService;
    private readonly ILogger logger;

    public PizzaDataService(BrightWayService brightwayService, ILogger<BrightWayService> logger) {
        this.brightwayService = brightwayService;
        this.logger = logger;
    }

    public async Task<List<PizzaTopping>> GetToppings() {
        var apiResponse = await brightwayService.GetPizzaToppings();

        return apiResponse
            .SelectMany(p => p.Toppings)
            .GroupBy(p => p, (p, g) => new PizzaTopping {
                Topping = p,
                OrderCount = g.Count()
            })
            .OrderByDescending(p => p.OrderCount)
            .ToList();
    }

    public async Task<List<PizzaConfiguration>> GetCombinations() {
        var apiResponse = await brightwayService.GetPizzaToppings();

        return apiResponse
            .Select(p => p.Toppings.OrderBy(p => p))
            .GroupBy(
                p => p.ToList(),
                (p, g) => new PizzaConfiguration {
                    Toppings = p,
                    OrderCount = g.Count()
                },
                new StringListEqualityComparer()
            ).OrderByDescending(p => p.OrderCount)
            .ToList();
    }
}

class StringListEqualityComparer : IEqualityComparer<List<string>> {
    public bool Equals(List<string> list1, List<string> list2) => Enumerable.SequenceEqual(list1, list2);

    public int GetHashCode(List<string> list) =>
        list.Aggregate(0, (hash, curr) => HashCode.Combine(hash, curr.GetHashCode()));
}