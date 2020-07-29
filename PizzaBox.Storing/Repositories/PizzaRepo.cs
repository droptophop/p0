using System;
using System.Collections.Generic;
using System.Linq;
using comp = PizzaBox.Housing.Components;
using model = PizzaBox.Housing.Models;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepo
  {
    private PizzaStoreDbContext _db = new PizzaStoreDbContext();

    public void Create(model.Pizza pizza)
    {
      var newPizza = new Pizza();
      var orderDate = DateTime.UtcNow;

      newPizza.Name = pizza.Name;
      newPizza.Crust = new Crust() { Name = pizza.Crust.Name };
      newPizza.Size = new Size() { Name = pizza.Size.Name };
      newPizza.DateModified = orderDate;

      _db.Pizza.Add(newPizza);
      _db.SaveChanges();
    }

    public List<model.Pizza> ReadAll()
    {
      var domainPizzaList = new List<model.Pizza>();
      // var newPizza = new domain.Pizza();

      foreach(var p in _db.Pizza.ToList())
      {
        domainPizzaList.Add(new model.Pizza()
        {
          Crust = new comp.Crust() { Name = p.Crust.Name },
          Size = new comp.Size() { Name = p.Size.Name },
          Toppings = new List<comp.Topping>()
        });
      };

      return domainPizzaList;
    }

    public void Update() {}

    public void Delete() {}
  }
}