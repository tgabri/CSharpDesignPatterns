using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetAcademia_Adapter;
using FluentAssertions;
using System.Data;
using NetAcademia_Adapter.Resource;
using System.Data.OleDb;

namespace Netacademia_Adapter.Tests
{
    /// <summary>
    /// Summary description for AddressDbDataAdapterRepository
    /// </summary>
    [TestClass]
    public class AddressDbDataAdapterRepositoryTests
    {
        [TestMethod]
        public void AddressDbDataAdapterRepositoryShouldThrowArgumentNullExceptionIfArgumentsNull()
        {
            AddressDbDataAdapterRepository sut;

            //Delegate - Rogzitem a muveletet<
            Action act = () => sut = new AddressDbDataAdapterRepository(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void AddressDbDataAdapterRepositoryShouldReturnMockData()
        {
            var adapter = new MockDbDataAdapter(MockDataTableFactory.CreateDataTable());
            var sut = new AddressDbDataAdapterRepository(adapter);

            var list = sut.GetAddresses();

            list.Should().HaveCount(1, "Egy elemunk van a repoban")
                .And.Should().Equals(new Address { Email = GlobalStrings.TestEmailAddress });
        }

        [TestMethod]
        public void AddressDbDataAdapterRepositoryShouldReturnSQLData()
        {
            var adapter = new OleDbDataAdapter();

            adapter.SelectCommand = new OleDbCommand($"SELECT * FROM {GlobalStrings.TableName}");
            adapter.SelectCommand.Connection = new OleDbConnection("Provider=MSOLEDBSQL;Server=(localdb)\\MSSQLLocalDB;Database=_00Data.AddressDbContext;Trusted_Connection=yes;");

            var sut = new AddressDbDataAdapterRepository(adapter);

            var list = sut.GetAddresses();

            list.Should().HaveCount(1, "Egy elemunk van a repoban")
                .And.Should().Equals(new Address { Email = GlobalStrings.TestEmailAddress });
        }
    }
}
