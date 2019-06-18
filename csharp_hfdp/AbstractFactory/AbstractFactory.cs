using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_hfdp.AbstractFactory
{
    /***
     * We provided a means of creating a family of ingredients for pizzas by
     * introducing a new type of factory called an Abstract Factory.
     * 
     * An abstract factory gives us an interface for creating a family of products.
     * By writing code that uses this interface, we decouple our code from the actual
     * factory that creates the products. That allows us to implement a variety of
     * factories that product products meant for different contexts - such as different
     * regions, different operating systems, or different looks an feels.
     * 
     * Because our code is decoupled from the actual products, we can substitute 
     * different factories to get different behaviors (like getting marinara instead of
     * plum tomatoes)
     ***/


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

    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            Pizza pizza = null;

            var ingredientFactory = new NYPizzaIngredientFactory();

            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(ingredientFactory);
                    break;
                case "clam":
                    pizza = new ClamPizza(ingredientFactory);
                    break;
                default:
                    throw new ApplicationException("Invalid Pizza Type");
            }

            return pizza;
        }
    }

    public interface IPizzaIngredientFactory
    {
        Dough CreateDough();
        Sauce CreateSauce();
        Cheese CreateCheese();
        Veggie[] CreateVeggies();
        Pepperoni CreatePepperoni();
        Clams CreateClams();
    }

    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Cheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public Clams CreateClams()
        {
            return new FreshClams();
        }

        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public Veggie[] CreateVeggies()
        {
            Veggie[] veggies =
            {
                new Garlic(),
                new Onion(),
                new Mushroom(),
                new RedPepper()
            };
            return veggies;
        }
    }

    public abstract class Pizza
    {
        public string Name { get; set; }
        protected Dough dough;
        protected Sauce sauce;
        protected Veggie[] veggies;
        protected Cheese cheese;
        protected Pepperoni pepperoni;
        protected Clams clams;

        public abstract void Prepare();

        public void Bake() => Console.WriteLine("Bake for 25 minutes at 350");
        public void Cut() => Console.WriteLine("Cutting the pizza into diagonal slices");
        public void Box() => Console.WriteLine("Place pizza in official PizzaStore box");
    }

    public class CheesePizza : Pizza
    {
        IPizzaIngredientFactory ingredientFactory;
        public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            dough = ingredientFactory.CreateDough();
            sauce = ingredientFactory.CreateSauce();
            cheese = ingredientFactory.CreateCheese();
        }
    }

    public class ClamPizza : Pizza
    {
        IPizzaIngredientFactory ingredientFactory;
        public ClamPizza(IPizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            dough = ingredientFactory.CreateDough();
            sauce = ingredientFactory.CreateSauce();
            cheese = ingredientFactory.CreateCheese();
            clams = ingredientFactory.CreateClams();
        }
    }

    internal class RedPepper : Veggie
    {
    }

    internal class Mushroom : Veggie
    {
    }

    internal class Onion : Veggie
    {
    }

    internal class Garlic : Veggie
    {
    }

    internal class MarinaraSauce : Sauce
    {
    }

    internal class SlicedPepperoni : Pepperoni
    {
    }

    internal class ThinCrustDough : Dough
    {
    }

    internal class FreshClams : Clams
    {
    }

    internal class ReggianoCheese : Cheese
    {
    }

    public class Clams
    {
    }

    public class Pepperoni
    {
    }

    public class Veggie
    {
    }

    public class Cheese
    {
    }

    public class Sauce
    {
    }

    public class Dough
    {
    }
}
