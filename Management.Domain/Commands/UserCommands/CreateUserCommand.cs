using System;
using Management.Domain.Documents;
using Management.Persistence.Model;

namespace Management.Domain.Commands
{
	public class CreateUserCommand : CommandWithIdResponse
    {
	    public Guid Id { get; }
	    public UserRoles _acceslevel { get;  }
	    public string Name { get; }
		public string Email { get; }
		public string Password { get; }
	    public double BaseWage { get; }
	    public DateTime EmploymentDate { get; }

		public CreateUserCommand(Guid id, string name, string email, string password, UserRoles acceslevel, double baseWage , DateTime employmentDate)
		{
			if (id.Equals(Guid.Empty))
			{
				throw new ArgumentException(nameof(id) + " CreateUserCommand may not be initiated with a id value of Guid.Empty");
			}
			
			Id = id;
			_acceslevel = acceslevel;
			Name = name;
			Email = email;
			Password = password;
			BaseWage = baseWage;
			EmploymentDate = employmentDate;


		}
    }
}
