﻿namespace CQRS.Infrastructure
{
    public interface ICommandHandler<TCommand> where TCommand:Command
    {
        void Execute(TCommand command);
    }
}
