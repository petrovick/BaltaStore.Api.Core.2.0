using System.Collections.Concurrent;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using System;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
          var command = new CreateCustomerCommand();
          command.FirstName = "Gabriel";
          command.LastName = "Petrovick";
          command.Document = "10180179683";
          command.Email = "petrovickg@hotmail.com";
          command.Phone = "34998387096";

          Assert.AreEqual(true, command.Valid());
        }
    }
}
