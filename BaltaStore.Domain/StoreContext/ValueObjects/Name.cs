using System.Collections;
using System.Collections.Generic;
using System;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects {
  public class Name : Notifiable{
        public Name(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;

            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve no maximo 40 caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(LastName, 40, "LastName", "O nome deve no maximo 40 caracteres.")
            );
        }
  
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public override string ToString() {
        return $"{FirstName} {LastName}";
    }
  }
}
