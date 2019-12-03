using System.Collections.Concurrent;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;
using System;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document inValidDocument;
        public DocumentTests() {
            validDocument = new Document("10180179683");
            inValidDocument = new Document("10180179684 ");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            var document = new Document("10180179684");
            
            Assert.IsTrue(inValidDocument.Invalid);
            Assert.AreEqual(1, inValidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            var document = new Document("10180179683");
            Assert.AreEqual(false, validDocument.Invalid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
