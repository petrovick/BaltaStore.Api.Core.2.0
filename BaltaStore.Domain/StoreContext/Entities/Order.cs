using System.Collections;
using System.Collections.Generic;
using System;
using BaltaStore.Domain.StoreContext.Enums;
using System.Linq;
using FluentValidator;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities {
  public class Order : Entity
    {
    private readonly IList<OrderItem> _items;
    private readonly IList<Delivery> _deliveries;
    public Order (Customer customer) {
        this.Customer = customer;
        //this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        this.CreateDate = DateTime.Now;
        this.Status = EOrderStatus.Created;
        _items = new List<OrderItem>();
        _deliveries = new List<Delivery>();
    }
    public Customer Customer { get; private set; }
    public string Number { get; private set; }
    public DateTime CreateDate { get; private set; }
    public EOrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
    public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

    public void AddItem(Product product, decimal quantity)
    {
            if(quantity > product.QualityOnHand)
            {
                AddNotification("OrderItem", $"Produto {product.Title} nao tem {quantity} em estoque.");
            }
            var item = new OrderItem(product, quantity);
            _items.Add(item);
    }

    // To Place an Order
        public void Place() {
      //Gerar o numero do pedido
      this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            // Validar
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido nao possui itens");
    }

    // Pagar o pedido
    public void Pay() {
      Status = EOrderStatus.Paid;
    }


    // Enviar um pedido
    public void Ship() {
      // A cada 5 produtos eh uma entrega
      var deliveries = new List<Delivery>();
      var count = 1;
      //A cda 5 produtos quebra as entregar
      foreach(var item in _items) {
        if(count == 5)
        {
          count = 1;
          _deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
        }
        count ++;
      }
      //Envia todas as entregas
      deliveries.ForEach(x => x.Ship());

      /// Adiciona as entregar ao pedido
      deliveries.ForEach(x => _deliveries.Add(x));


    }

    // Cancelar um pedido
    public void Cancel() {
      Status = EOrderStatus.Canceled;
      _deliveries.ToList().ForEach(x => x.Cancel());
    }
  }
}