using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace csharp_hfdp.tests
{
    [TestClass]
    public class Welcome
    {
        readonly string nL = Environment.NewLine;

        [TestMethod]
        public void Strategy_Mallard_Duck_Is_Right()
        {
            var expected = $"Quack{nL}I'm flying!!{nL}";
            var duck = new Strategy.MallardDuck();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                duck.PerformQuack();
                duck.PerformFly();

                var actual = sw.ToString();
                Assert.AreEqual<string>(expected, actual);
            }    
        }

        [TestMethod]
        public void Strategy_Duck_Can_Change_Behavior_At_Runtime()
        {
            var expected = $"I can't fly{nL}I'm flying with a rocket!{nL}";

            var model = new Strategy.ModelDuck();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                model.PerformFly();
                model.SetFlyBehavior(new Strategy.FlyRocketPowerred());
                model.PerformFly();

                var actual = sw.ToString();
                Assert.AreEqual<string>(expected, actual);
            }
        }

        [TestMethod]
        public void Observer_Is_Working_Fine()
        {
            var expected = $"Current conditions: 80F degrees and 65% humidity{nL}"
                + $"Current conditions: 82F degrees and 70% humidity{nL}"
                + $"Current conditions: 78F degrees and 90% humidity{nL}";

            var weatherData = new Observer.WeatherData();
            var currentDisplay = new Observer.CurrentConditionsDisplay(weatherData);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                weatherData.SetMeasurements(80, 65, 30.4f);
                weatherData.SetMeasurements(82, 70, 29.2f);
                weatherData.SetMeasurements(78, 90, 29.2f);

                var actual = sw.ToString();
                Assert.AreEqual<string>(expected, actual);
            }
        }

        [TestMethod]
        public void Decorator_Espresso_Description()
        {
            var espresso = new Decorator.Espresso();
            var expected = 1.99;
            var actual = espresso.Cost();
            Assert.AreEqual<double>(expected, actual);
        }

        [TestMethod]
        public void Decorator_Espresso_Cost()
        {
            var espresso = new Decorator.Espresso();
            var expected = "Espresso";
            var actual = espresso.GetDescription();
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void Decorator_HouseBlendDoubleMochaSoyWhip_Cost()
        {
            var expected = 1.71;

            Decorator.Beverage beverage = new Decorator.HouseBlend();
            beverage = new Decorator.Mocha(beverage);
            beverage = new Decorator.Mocha(beverage);
            beverage = new Decorator.Soy(beverage);
            beverage = new Decorator.Whip(beverage);
            var actual = beverage.Cost();

            Assert.AreEqual<double>(expected, actual);
        }

        [TestMethod]
        public void Factory_NYStyleCheesePizza_Done_Right()
        {
            var expected = "Preparing NY Style Sauce and Cheese Pizza" + nL
                + "Tossing dough..." + nL
                + "Adding sauce..." + nL
                + "Adding toppings..." + nL
                + "   Grated Reggiano Cheese" + nL
                + "Bake for 25 minutes at 350" + nL
                + "Cutting the pizza into diagonal slices" + nL
                + "Place pizza in official PizzaStore box" + nL;

            Factory.PizzaStore store = new Factory.NYStylePizzaStore();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                store.OrderPizza("cheese");
                var actual = sw.ToString();

                Assert.AreEqual<string>(expected, actual);
            }
        }

        /***
         * Will implement later
         * 
        [TestMethod]
        public void AbstractFactory_Done_Right()
        {
            throw new NotImplementedException();
        }
         *
         ***/
    }
}
