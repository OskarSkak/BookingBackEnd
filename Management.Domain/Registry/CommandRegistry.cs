using System;
using SimpleSoft.Mediator;
namespace Management.Domain.Registry
{
	public class CommandRegistry : StructureMap.Registry
    {
        public CommandRegistry()
        {
			Scan(scanner =>
			{
                //Define that this scanning goes for the assembly or project that contains the CommandRegistry class
				scanner.AssemblyContainingType<CommandRegistry>();

				//Scanning conventions, instead of defining each new handler in the this component we tell structuremap to look for all class implementing respective interfaces
				scanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<,>));
				scanner.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));
			});
        }
    }
}
