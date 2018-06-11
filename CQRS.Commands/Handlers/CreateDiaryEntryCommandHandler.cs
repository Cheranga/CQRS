using System;
using CQRS.Infrastructure;

namespace CQRS.Commands.Handlers
{
    public class CreateDiaryEntryCommandHandler : ICommandHandler<CreateDiaryEntryCommand>
    {
        public void Execute(CreateDiaryEntryCommand command)
        {
            Console.WriteLine("Write command logic here");
        }
    }
}