using System.Collections.Generic;
using System.Text;
using PizzaBox.Housing.Components;

namespace PizzaBox.Housing.Models
{
  public class Pizza
  {
    public string Name { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }
    public decimal Price
    {
      get
      {
        return Crust.Price + Size.Price;
      }
    }
  }
}