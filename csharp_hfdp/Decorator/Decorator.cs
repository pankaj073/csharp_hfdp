using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_hfdp.Decorator
{
    public abstract class Beverage
    {
        protected string description = "Unknown Beverage";

        public virtual string GetDescription()
        {
            return description;
        }

        public abstract double Cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        public abstract override string GetDescription();
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }
        public override double Cost()
        {
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "House Blend Coffee";
        }
        public override double Cost()
        {
            return .89;
        }
    }

    public class Mocha : CondimentDecorator
    {
        readonly Beverage beverage;
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double Cost()
        {
            return .20 + beverage.Cost();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Mocha";
        }
    }

    public class Soy : CondimentDecorator
    {
        readonly Beverage beverage;
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double Cost()
        {
            return .15 + beverage.Cost();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soy";
        }
    }

    public class Whip : CondimentDecorator
    {
        readonly Beverage beverage;
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double Cost()
        {
            return .27 + beverage.Cost();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whip";
        }
    }
}
