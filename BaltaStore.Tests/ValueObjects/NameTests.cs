using System.Collections.Concurrent;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;
using System;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private Document validDocument;
        private Document inValidDocument;
        public NameTests() {
            validDocument = new Document("10180179683");
            inValidDocument = new Document("10180179684 ");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Petrovick");
            
            Assert.IsTrue(name.Invalid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}
