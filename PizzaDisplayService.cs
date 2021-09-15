using System.Collections.Generic;
using System.Linq;
using System;

public class PizzaDisplayService {

    public void PrintToppings(List<PizzaTopping> toppings, int? limit){
        var toPrint = toppings;
        if(limit != null && limit > 0) {
            toPrint = toppings.Take(limit.Value).ToList();
        }

        toPrint.ForEach(topping => {
            Console.WriteLine($"Count: {topping.OrderCount,5}  Topping: {topping.Topping}");
        });
    }

    public void PrintCombinations(List<PizzaConfiguration> combinations, int? limit) {
        var toPrint = combinations;
        if(limit != null && limit > 0) {
            toPrint = combinations.Take(limit.Value).ToList();
        }

        toPrint.ForEach(combo => {
            Console.WriteLine($"Count: {combo.OrderCount,5}  Topping: {string.Join(", ", combo.Toppings)}");
        });
    }
}