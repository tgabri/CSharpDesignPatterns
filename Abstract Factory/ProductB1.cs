using System;

namespace Abstract_Factory
{
    /// <summary>

    /// The 'ProductB1' class

    /// </summary>

    class ProductB1 : AbstractProductB

    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }
}
