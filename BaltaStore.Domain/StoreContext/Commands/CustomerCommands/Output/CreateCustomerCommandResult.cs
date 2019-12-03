using System;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Output
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult() { }
        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            this.Id = id;
            this.Name= name;
            this.Email = email;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}