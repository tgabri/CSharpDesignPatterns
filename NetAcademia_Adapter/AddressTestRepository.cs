using NetAcademia_Adapter.Resource;
using System;
using System.Collections.Generic;

namespace NetAcademia_Adapter
{
    public class AddressTestRepository : IAddressRepository
    {
        public AddressTestRepository()
        {
        }

        public IList<Address> GetAddresses()
        {
            return new List<Address> { new Address { Email = GlobalStrings.TestEmailAddress } };
        }
    }
}