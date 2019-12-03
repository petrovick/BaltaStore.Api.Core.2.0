using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Gabriel";
            command.LastName = "Petrovick";
            command.Document = "10180179683";
            command.Email = "petrovickg@hotmail.com";
            command.Phone = "34998387096";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}
