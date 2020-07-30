// using System;
// using System.Collections.Generic;
// using System.Linq;
// using comp = PizzaBox.Housing.Components;
// using model = PizzaBox.Housing.Models;

// namespace PizzaBox.Storing.Repositories
// {
//   public class PizzaRepo
//   {
//     private PizzaStoreDbContext _db = new PizzaStoreDbContext();

//     public Pizza Create(model.Pizza pizza)
//     {
//       var newPizza = new Pizza();
//       var orderDate = DateTime.UtcNow;

//       newPizza.Name = pizza.Name;
//       newPizza.Crust = new Crust() { Name = pizza.Crust.Name };
//       newPizza.Size = new Size() { Name = pizza.Size.Name };
//       newPizza.Price = pizza.Price();
//       newPizza.DateModified = orderDate;

//       foreach (var topping in pizza.Toppings)
//       {
//           newPizza.Pizza.Add(new PizzaTopping()
//           {
//               Topping = _db.Topping.FirstOrDefault(t => t.Name == topping.Name)
//           });
//       }

//       return newPizza;
//     }
    
//     public void CreateOrder(model.Order order, model.User user, model.Store store)
//         {
//             var newOrder = new Orders();

//             newOrder.Price = order.PurchaseTotal();
//             newOrder.User = _db.Users.FirstOrDefault(u => u.Name == user.name);
//             newOrder.Store = _db.Store.FirstOrDefault(s => s.Name == store.Name);

//             foreach (var pizza in order.Pizzas)
//             {
//                 newOrder.Pizza.Add(Create(pizza));
//             }

//             _db.Orders.Add(newOrder);
//             _db.SaveChanges();
//         }

//     public List<comp.Crust> CrustOptions()
//     {
//       var compCrustList = new List<comp.Crust>();
//       // var newPizza = new domain.Pizza();

//       foreach(var crust in _db.Crust.ToList())
//       {
//         compCrustList.Add(new comp.Crust(crust.Name, crust.Price));
//       };

//       return compCrustList;
//     }

//     public List<comp.Topping> ToppingOptions()
//     {
//       var compToppingList = new List<comp.Topping>();
//       // var newPizza = new domain.Pizza();

//       foreach(var topping in _db.Topping.ToList())
//       {
//         compToppingList.Add(new comp.Topping(topping.Name, topping.Price));
//       };

//       return compToppingList;
//     }

//     public List<comp.Size> SizeOptions()
//     {
//       var compSizeOptions = new List<comp.Size>();
//       // var newPizza = new domain.Pizza();

//       foreach(var sizeOption in _db.Size.ToList())
//       {
//         compSizeOptions.Add(new comp.Size(sizeOption.Name, sizeOption.Price));
//       };

//       return compSizeOptions;
//     }

//     public void Update() {}

//     public void Delete() {}
//   }
// }