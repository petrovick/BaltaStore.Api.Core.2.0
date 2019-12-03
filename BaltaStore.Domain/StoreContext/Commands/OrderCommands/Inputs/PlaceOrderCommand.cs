using System.Collections.Generic;
using System;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs {
  public class PlaceOrderCommand : Notifiable, ICommand
  {
    public PlaceOrderCommand() {
      OrderItems = new List<OrderItemCommand>();
    }
    public Guid Customer {get;set;}
    public IList<OrderItemCommand> OrderItems {get;set;}

    public bool Valid()
    {
      AddNotifications(new ValidationContract().Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente invalido.")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nnehum item do pedido foi encontrado.")
            );
        return base.Valid;
    }
  }

  public class OrderItemCommand {
    public Guid Product { get; set; }
    public decimal Quantity{get;set;}
  }
  
}