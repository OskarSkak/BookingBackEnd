using System;
using Management.Documents.Documents;
using Management.Persistence.Model;
using SimpleSoft.Mediator;

namespace Management.Domain.Commands
{
    public class UpdateUserCommand : Command<IdResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Acceslevel { get; set; }
        public double Wage { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Guid Id { get; set; }

        public UpdateUserCommand(string name, string email, string password, UserRoles acceslevel, double wage, DateTime employmentDate, Guid Id)
        {
            Name = name;
            Email = email;
            Password = password;
            Acceslevel = acceslevel;
            Wage = wage;
            EmploymentDate = employmentDate;
            
            this.Id = Id;
        }
        
    }
}