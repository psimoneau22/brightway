To build:

`dotnet publish`

To run:  (see /q switch to request a different output)

(List all toppings and the count each one was ordered)

`dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListToppings`

(List top 20 toppings and the count each one was ordered)

`dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListToppings /top 20`

(List of all topping combinations and the count each one was ordered)

`dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListCombinations`

(List top 20 topping combinations and the count each one was ordered)

`dotnet ./bin/Debug/net5.0/publish/pizza.dll /q ListCombinations /top 20`


Notes:
    -- This was written on a mac with VSCode but should be usable on a windows system. (not tested on windows)
    -- This is a framework dependent deployment and relies on the consumer to have .Net5.0 installed to build and run
