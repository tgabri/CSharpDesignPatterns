using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        /// <summary>

        /// Definition
        /// Provide a surrogate or placeholder for another object to control access to it.

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            // Create proxy and request a service

            Proxy proxy = new Proxy();
            proxy.Request();

            // Wait for user

            Console.ReadKey();
        }
    }
}
