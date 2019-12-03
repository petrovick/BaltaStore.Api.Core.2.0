using System.Collections;
using System.Collections.Generic;
using System;

namespace BaltaStore.Domain.StoreContext.Enums {
  public enum EOrderStatus {
    Created= 1,
    Paid = 2,
    Shipping = 3,
    Canceled= 4
  }
}