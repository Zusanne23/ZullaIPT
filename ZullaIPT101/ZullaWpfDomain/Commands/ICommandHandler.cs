namespace ZullaWpfDomain.Commands;

public interface ICommandHandler<TCommand>
{
    Task ExecuteAsync(TCommand command);
}
