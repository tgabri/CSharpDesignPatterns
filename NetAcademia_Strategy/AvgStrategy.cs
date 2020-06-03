using NetAcademia_Adapter;
using System.Collections.Generic;
using System.Linq;

namespace NetAcademia_Strategy
{
    public class AvgStrategy : IStrategy
    {
        public int Operation(IList<Address> list)
        {
            return (int)list.Average(x => x.EmailCount);
        }
    }
}