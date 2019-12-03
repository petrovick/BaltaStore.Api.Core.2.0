using System;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs {
  public class CreateCustomerCommand : Notifiable, ICommand
  {
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Document {get;set;}
    public string Email{get;set;}
    public string Phone {get;set;}

    public bool Valid() {
      AddNotifications(new ValidationContract().Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve no maximo 40 caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(LastName, 40, "LastName", "O nome deve no maximo 40 caracteres.")
                .IsEmail(Email, "Email", "O e-mail eh invalido.")
                .HasLen(Document, 11, "Document", "CPF invalido.")
            );
        return base.Valid;
    }

    //Se o usuario existe no banco (Email)

    //Se o usuario existe no banco (CPF)

  }
}