using System;
using System.Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetAcademia_Adapter.Resource;

namespace Netacademia_Adapter.Tests
{
    [TestClass]
    public class MockDbDataAdapterTests
    {

        [TestMethod]
        public void MockDbDataAdapterShouldThrowArgumentNullExceptionIfArgumentsNull()
        {
            MockDbDataAdapter sut;

            //Delegate - Rogzitem a muveletet<
            Action act = () => sut = new MockDbDataAdapter(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void MockDbDataAdapterShouldThrowArgumentNullExceptionIfFillMethodsArgumentsNull()
        {
            var sut = new MockDbDataAdapter(MockDataTableFactory.CreateDataTable());

            //Delegate - Rogzitem a muveletet<
            Action act = () => sut.Fill(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void MockDbDataAdapterShouldReturnTable()
        {
            var sut = new MockDbDataAdapter(MockDataTableFactory.CreateDataTable());
            var dataSet = new DataSet();

            //Delegate - Rogzitem a muveletet<
            sut.Fill(dataSet);

            dataSet.Tables.Should().HaveCount(1);
        }

        [TestMethod]
        public void MockDbDataAdapterShouldReturnData()
        {
            var sut = new MockDbDataAdapter(MockDataTableFactory.CreateDataTable());
            var dataSet = new DataSet();

            //Delegate - Rogzitem a muveletet<
            sut.Fill(dataSet);

            dataSet.Tables.Should().HaveCount(1);

            var table = dataSet.Tables[0];

            MockDataTableFactory.CheckDataTable(table);
        }


    }
}
