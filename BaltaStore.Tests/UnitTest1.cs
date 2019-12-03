using System.Collections.Concurrent;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;
using System;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Gabriel", "Petrovick");
            var documento = new Document("10180179683");
            var email = new Email("petrovickg@hotmail.com");
            
            var customer = new Customer(
                name, documento,email,
                "34998389076");
            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressora = new Product("impressora", "Impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("mouse", "Rato", "image.png", 559.90M, 10);
            
            var order = new Order(customer);
            //order.addItem(new OrderItem(mouse, 5));
            //order.addItem(new OrderItem(teclado, 5));
            //order.addItem(new OrderItem(impressora, 5));
            //order.addItem(new OrderItem(cadeira, 5));

            var oi = new OrderItem(cadeira, 5);


            //Realizei pedido
            order.Place();

            //Verificae se o pedido eh valido
            if(order.Valid)
            {

            }

            //Simular pagamento
            order.Pay();

            //Simular o envio
            order.Ship();

            //Simular cancelamento
            order.Cancel();
            Assert.AreEqual(true, true);
            
        }
    }
}
