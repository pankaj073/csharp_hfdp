using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_hfdp.Factory
{
    public class Pizza
    {
        protected string name;
        protected string dough;
        protected string sauce;

        protected List<string> toppings = new List<string>();
        
        public virtual void Prepare()
        {
            Console.WriteLine("Preparing " + name);
            Console.WriteLine("Tossing dough...");
            Console.WriteLine("Adding sauce...");
            Console.WriteLine("Adding toppings...");
            foreach(var topping in toppings)
            {
                Console.WriteLine("   " + topping);
            }
        }
        public virtual void Bake() => Console.WriteLine("Bake for 25 minutes at 350");
        public virtual void Cut() => Console.WriteLine("Cutting the pizza into diagonal slices");
        public virtual void Box() => Console.WriteLine("Place pizza in official PizzaStore box");
        public string GetName() => name;
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            name = "NY Style Sauce and Cheese Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";

            toppings.Add("Grated Reggiano Cheese");
        }
    }
    public class NYStylePepperoniPizza : Pizza
    {
    }
    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            name = "Chicago Style Deep Dish Cheese Pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";

            toppings.Add("Shredded Mozaarella Cheese");
        }

        public override void Cut() => Console.WriteLine("Cutting the pizza into square slices");
    }
    public class ChicagoStylePepperoniPizza : Pizza
    {
    }
    
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza;
            pizza = createPizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        protected abstract Pizza createPizza(string type);
    }

    public class NYStylePizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            switch(type)
            {
                case "cheese":
                    pizza = new NYStyleCheesePizza();
                    break;
                case "pepperoni":
                    pizza = new NYStylePepperoniPizza();
                    break;
                default:
                    throw new ApplicationException("Invalid Pizza Type");
            }

            return pizza;
        }
    }

    public class ChicagoStylePizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            switch (type)
            {
                case "cheese":
                    pizza = new ChicagoStyleCheesePizza();
                    break;
                case "pepperoni":
                    pizza = new ChicagoStylePepperoniPizza();
                    break;
                default:
                    throw new ApplicationException("Invalid Pizza Type");
            }

            return pizza;
        }
    }
}
