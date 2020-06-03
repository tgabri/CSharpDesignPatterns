using FluentAssertions;
using NetAcademia_Adapter.Resource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netacademia_Adapter.Tests
{
    public class MockDataTableFactory
    {
        public static DataTable CreateDataTable()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add(GlobalStrings.TableColumnEmail, typeof(string));
            var row = dataTable.NewRow();
            row[GlobalStrings.TableColumnEmail] = GlobalStrings.TestEmailAddress;
            dataTable.Rows.Add(row);

            return dataTable;
        }

        public static void CheckDataTable(DataTable table)
        {
            table.Rows.Should().HaveCount(1);
            table.Columns[GlobalStrings.TableColumnEmail].Should().NotBeNull();
            table.Rows[0][GlobalStrings.TableColumnEmail].Should().Be(GlobalStrings.TestEmailAddress);
        }
    }
}
