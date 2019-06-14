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
            var duck = new csharp_hfdp.Strategy.MallardDuck();

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

            var model = new csharp_hfdp.Strategy.ModelDuck();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                model.PerformFly();
                model.SetFlyBehavior(new csharp_hfdp.Strategy.FlyRocketPowerred());
                model.PerformFly();

                var actual = sw.ToString();
                Assert.AreEqual<string>(expected, actual);
            }
        }
    }
}
