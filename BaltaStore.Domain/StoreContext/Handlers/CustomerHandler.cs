using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Output;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF ja existe na base.
            if(_customerRepository.CheckDocument(command.Document))
            {
                AddNotification("Document", "Este CPF ja esta em uso. ");
            }
            //Verificar se o email ja existe na base
            if (_customerRepository.CheckEmail(command.Email))
            {
                AddNotification("Email", "Este E-mail ja esta em uso. ");
            }

            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (!Valid)
                return null;

            //Persistir o cliente
            _customerRepository.Save(customer);

            //Enviar um email de boas vindas
            _emailService.Send(email.Address, "petrovickg@hotmail.com", "Bem vindo", "Seja bem vindo ao balta store.");

            //Retornar o resultado apra tela.
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);

        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
