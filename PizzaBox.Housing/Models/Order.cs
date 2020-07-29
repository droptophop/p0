using System.Collections.Generic;
using comp = PizzaBox.Housing.Components;

namespace PizzaBox.Housing.Models
{
  public class Order
  {
    public List<Pizza> Pizzas { get; }

    public Pizza CreatePizza(string name, List<comp.Topping> toppings)
    {
      var pizza = new Pizza(name, toppings);

      Pizzas.Add(pizza);

      return pizza;
    }
  }
}