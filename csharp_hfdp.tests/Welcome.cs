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
        public void Mallard_Duck_Is_Right()
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
        public void Model_Duck_Can_Change_Behavior_At_Runtime()
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
    }
}
