using NetAcademia_Adapter;
using System.Collections.Generic;

namespace NetAcademia_Strategy
{
    public interface IStrategy
    {
        int Operation(IList<Address> list);
    }
}