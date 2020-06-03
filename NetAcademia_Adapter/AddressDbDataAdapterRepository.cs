using NetAcademia_Adapter.Resource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Adapter
{
    public class AddressDbDataAdapterRepository : IAddressRepository
    {
        private IDbDataAdapter adapter;

        public AddressDbDataAdapterRepository(IDbDataAdapter adapter)
        {
            if (adapter == null)
                throw new ArgumentNullException(nameof(adapter));

            this.adapter = adapter;
        }

        public IList<Address> GetAddresses()
        {
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            var list = new List<Address>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new Address { Email = row.Field<string>(GlobalStrings.TableColumnEmail) });
            }

            return list;
        }
    }
}
