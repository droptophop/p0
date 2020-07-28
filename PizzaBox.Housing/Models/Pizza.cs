using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    public string Crust { get; }
    public string Size { get; } // size
    public List<string> Toppings { get; set; }
  }
}