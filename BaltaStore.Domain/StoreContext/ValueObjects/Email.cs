using System.Collections;
using System.Collections.Generic;
using System;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects {
  public class Email : Notifiable
    {
    public Email(string address) {
      this.Address = address;

            AddNotifications(new ValidationContract().Requires()
                .IsEmail(Address, "Email", "O email deve ser valido.")
            );
        }
  
    public string Address { get; private set; }

    public override string ToString() {
      return $"{Address}";
    }
  }
}