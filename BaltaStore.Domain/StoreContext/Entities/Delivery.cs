using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities{
  public class Delivery : Entity
    {
    public Delivery(DateTime estimateDeliveryDate) {
      this.CreateDate = DateTime.Now;

    }
    public DateTime CreateDate { get; private set; }
    public DateTime ExtimateDeliveryDate { get; private set; }
    public EDeliveryStatus Status { get; private set; }

    public void Ship() {
      //Se Data estimada de entrega for no passado, nao entregar.
      Status = EDeliveryStatus.Shipped; 
    }
    public void Cancel() {
      //Se Status ja estiver entregue, nao pode cancelar
      Status = EDeliveryStatus.Canceled;
    }
  }
}