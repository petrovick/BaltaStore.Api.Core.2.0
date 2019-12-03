using System;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities {
  public class Address : Entity
    {
    // S : 
    // O
    // L
    // I
    // D
    public Address(
      string number,
      string complement,
      string district, 
      string city, 
      string state, 
      string country,
      string zipCode, 
      EAddressType type)
    {
      this.Number = number;
      this.Complement = complement;;
      this.District = district;
      this.City = city;
      this.State = state;
      this.Country = country;
      this.ZipCode = zipCode;
      this.Type = type;
    }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public EAddressType Type {get; private set;} 
    
    public override string ToString() {;
      return $"{Street},{Number} - {City}/{State}";
    }
  }
}