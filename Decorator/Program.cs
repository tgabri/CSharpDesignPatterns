using System;

namespace Decorator
{
    class Program
    {
        /// <summary>

        /// Definition
        /// Attach additional responsibilities to an object dynamically.
        /// Decorators provide a flexible alternative to subclassing for extending functionality.
        /// </summary>

        static void Main()
        {
            // Create ConcreteComponent and two Decorators

            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user

            Console.ReadKey();
        }
    }
}
