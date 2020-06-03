using NetAcademia_Adapter;
using NetAcademia_Adapter.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Strategy
{
    public class AddressStrategyTestRepo : IAddressRepository
    {
        public IList<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address { Email = GlobalStrings.TestEmailAddress, EmailCount=1},
                new Address { Email = GlobalStrings.TestEmailAddress1, EmailCount=2 },
                new Address { Email = GlobalStrings.TestEmailAddress2, EmailCount=5 },
                new Address { Email = GlobalStrings.TestEmailAddress3, EmailCount=2 },
                new Address { Email = GlobalStrings.TestEmailAddress4, EmailCount=3 },
                new Address { Email = GlobalStrings.TestEmailAddress5, EmailCount=4 },
                new Address { Email = GlobalStrings.TestEmailAddress6, EmailCount=6 },
                new Address { Email = GlobalStrings.TestEmailAddress7, EmailCount=7 },
                new Address { Email = GlobalStrings.TestEmailAddress8, EmailCount=8 },
                new Address { Email = GlobalStrings.TestEmailAddress9, EmailCount=1 },
            };
        }
    }
}
