using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetAcademia_Adapter;

namespace Netacademia_Adapter.Tests
{
    [TestClass]
    public class AdapterExampleTests
    {
        [TestMethod]
        public void ShouldAdapterExampleThrowArgumentNullExceptionIfAllArgumentsNull()
        {
            AdapterExample sut;

            //Delegate - Rogzitem a muveletet<
            Action act = () => sut = new AdapterExample(null, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void ShouldAdapterExampleThrowArgumentNullExceptionIfFirstArgumentsNull()
        {
            AdapterExample sut;

            //Delegate - Rogzitem a muveletet<
            Action act = () => sut = new AdapterExample(null, new MessageTestService());

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void ShouldAdapterExampleThrowArgumentNullExceptionIfSecondArgumentsNull()
        {
            AdapterExample sut;

            //Delegate - Rogzitem a muveletet<
            Action act = () => sut = new AdapterExample(new AddressTestRepository(), null);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
