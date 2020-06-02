using System;
using System.Collections.Generic;

namespace NetAcademia_Adapter
{
    public class AddressRepository
    {
        public AddressRepository()
        {
        }

        public IList<Address> GetAddresses()
        {
            return new List<Address> { new Address { Email = "test@gmail.com" } };
        }
    }
}