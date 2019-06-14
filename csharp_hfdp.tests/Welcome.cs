using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace csharp_hfdp.tests
{
    [TestClass]
    public class Welcome
    {
        [TestMethod]
        public void Mallard_Duck_Is_Right()
        {
            var currentConsoleOut = Console.Out;

            var expected = $"Quack{Environment.NewLine}I'm Flying!!{Environment.NewLine}";
            var duck = new csharp_hfdp.Welcome.MallardDuck();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                duck.PerformQuack();
                duck.PerformFly();

                var actual = sw.ToString();
                Assert.AreEqual<string>(expected, actual);
            }    
        }
    }
}
