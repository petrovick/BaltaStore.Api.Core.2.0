using System.Collections.Concurrent;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Enums;
using System;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
      private Product _mouse;
      private Product _keyboard;
      private Product _chair;
      private Product _monitor;
      private Customer _customer;
      private Order _order;
        public OrderTests() {


          var name = new Name("Gabriel", "Petrovick");
          var document = new Document("10180179683");
          var email = new Email("petrovickg@hotmail.com");
          _customer = new Customer(name, document, email, "34998389076");
          _order = new Order(_customer);
          _mouse = new Product("Mouse", "Mouse Gamer", "mouse.jpg", 100M, 10);
          _keyboard = new Product("Keyboard", "Keyboard Gamer", "keyboard.jpg", 100M, 10);
          _chair = new Product("Chair", "Chair Gamer", "chair.jpg", 100M, 10);
          _monitor = new Product("Monitor", "Monitor Gamer", "monitor.jpg", 100M, 10);
          
        }
        
        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid() {
          
          Assert.AreEqual(true, _order.Valid);
        }
        // Ao criar um novo pedido, o status dele deve ser Created
        [TestMethod]
        public void StatusShouldBeCreateWhenOrderCreated() {
          Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }


        // Ao adicionar um novo item, a quantidade deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems() {
          _order.AddItem(_monitor, 5);
          _order.AddItem(_mouse, 5);
          Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade de produto
        [TestMethod]
        public void ShouldReturnFiveWhenPurchasedFiveItem() {
          _order.AddItem(_mouse, 5);
          Assert.AreEqual(_mouse.QualityOnHand, 5);
        }

        // Ao confirmar o pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced() {
          _order.Place();
          Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid() {
          _order.Pay();
          Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados 10 produtos deve haver 2 entregas
        [TestMethod]
        public void ShouldReturnTwoWhenPurchasedTenProducts() {
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.Ship();
          Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled() {
          _order.Cancel();
          Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled() {
          
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.AddItem(_mouse, 1);
          _order.Cancel();
          foreach(var x in _order.Deliveries) {
            Assert.AreEqual(x.Status, EDeliveryStatus.Canceled);
          }
          
        }

        

    }
}
