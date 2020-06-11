using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00Data.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AddressDbContext();
            while (!Console.KeyAvailable)
            {
                foreach (var address in db.MyAddresses.ToList())
                {
                    Console.WriteLine(address.Address);
                }
            }


            Console.ReadLine();
        }
    }
}
