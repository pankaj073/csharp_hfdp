using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_hfdp.Welcome
{
    public interface IFlyBehavior
    {
        void Fly();
    }

    public class FlyWithWings : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I'm Flying!!");
    }

    public class FlyNoWay : IFlyBehavior
    {
        public void Fly() => Console.WriteLine("I can't fly");
    }

    public interface IQuackBehavior
    {
        void Quack();
    }

    public class LoudQuack : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("Quack");
    }

    public class MuteQuack : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("<< Silence >>");
    }

    public class Squeak : IQuackBehavior
    {
        public void Quack() => Console.WriteLine("Squeak");
    }

    public abstract class Duck
    {
        protected IFlyBehavior flyBehavior;
        protected IQuackBehavior quackBehavior;

        public Duck()
        {

        }

        public abstract void Display();

        public void PerformFly()
        {
            flyBehavior.Fly();
        }
        public void PerformQuack()
        {
            quackBehavior.Quack();
        }

        public void Swim() {
            Console.WriteLine("All ducks float, even decoys!");
        }
    }


    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            flyBehavior = new FlyWithWings();
            quackBehavior = new LoudQuack();
        }
        public override void Display() => Console.WriteLine("I'm a real Mallard duck");
    }
}
