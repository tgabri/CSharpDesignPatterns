using NetAcademia_Adapter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetAcademia_Strategy
{
    public class SumStrategy : IStrategy
    {
        public int Operation(IList<Address> list)
        {
            return list.Sum(x => x.EmailCount);
        }
    }
}