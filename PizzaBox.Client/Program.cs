using System;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var pr = new PizzaRepository();
      var pizza = new Pizza()
      {
        Crust = new Crust() { Name = "Stuffed" },
        Size = new Size() { Name = "Medium" },
      };
      
      pr.Create(pizza);
      Console.ReadLine();

      foreach (var item in pr.ReadAll())
      {
        System.Console.WriteLine(item); 
      }
    }
  }
}