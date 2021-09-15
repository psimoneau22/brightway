To build:

dotnet publish

To run:  (see /q switch to request a different output)

dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListToppings            (List all toppings and the count each one was ordered)
dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListToppings /top 20    (List top 20 toppings and the count each one was ordered)
dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListPizzas              (List of all topping combinations and the count each one was ordered)
dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListPizzas /top         (List top 20 topping combinations and the count each one was ordered)
