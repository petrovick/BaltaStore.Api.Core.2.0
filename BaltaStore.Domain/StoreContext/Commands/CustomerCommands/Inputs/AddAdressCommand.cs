using System;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
  public class AddAddressCommand : Notifiable, ICommand
  {
    public Guid Id {get;set;}
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public EAddressType Type {get; private set;} 
    
    public override string ToString() {
      return $"{Street},{Number} - {City}/{State}";
    }

        bool ICommand.Valid()
        {
            return Valid;
        }
    }
}