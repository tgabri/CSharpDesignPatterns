using System.Collections.Generic;

namespace NetAcademia_Adapter
{
    public interface IAddressRepository
    {
        IList<Address> GetAddresses();
    }
}