using System.Linq;
using System.Collections.Generic;
using System;
using BaltaStore.Domain.StoreContext.ValueObjects;
using System.Linq;
using FluentValidator;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities {
  public class Customer : Entity
    {
    // S : 
    // O
    // L
    // I
    // D
    private readonly IList<Address> _addresses;
    public Customer(
      Name name, 
      Document document, 
      Email email, 
      string phone)
    {
        this.Name = name;
        this.Document = document;
        this.Email = email;
        this.Phone = phone;
        _addresses = new List<Address>();
    }
    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public string Phone { get; private set; }
    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

    public void AddAddress(Address address) {
      // Validar o endereco
      // Adicionar o Endereço
      _addresses.Add(address);
    }

    public override string ToString() {;
      return $"{Name}";
    }
  }
}