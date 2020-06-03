using System;
using System.Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetAcademia_Adapter.Resource;

namespace Netacademia_Adapter.Tests
{
    [TestClass]
    public class MockDataTableFactoryTests
    {
        [TestMethod]
        public void MockDataTableFactoryShouldReturnData()
        {
            var sut = MockDataTableFactory.CreateDataTable();


            MockDataTableFactory.CheckDataTable(sut);
        }
    }
}
