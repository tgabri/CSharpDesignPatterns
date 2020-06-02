using System;

namespace Facade
{
    class Program
    {
        /// <summary>

        /// Definition
        /// Provide a unified interface to a set of interfaces in a subsystem.
        /// Façade defines a higher-level interface that makes the subsystem easier to use.

        /// </summary>

        public static void Main()
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            // Wait for user

            Console.ReadKey();
        }
    }
}
