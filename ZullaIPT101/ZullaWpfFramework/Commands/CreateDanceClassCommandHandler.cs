using ZullaWpfDomain.Commands;
using ZullaWpfFramework.DTOs;

namespace ZullaWpfFramework.Commands;

public class CreateDanceClassCommandHandler : ICommandHandler<CreateDanceClassCommand>
{
    private readonly ZullaWpfDbContext _context;

    public CreateDanceClassCommandHandler(ZullaWpfDbContext context)
    {
        _context = context;
    }

    public async Task ExecuteAsync(CreateDanceClassCommand command)
    {
        var danceClass = new DanceClassDto
        {
            Title = command.Title,
            DanceStyle = command.DanceStyle,
            Instructor = command.Instructor,
            Schedule = command.Schedule
        };

        _context.DanceClasses.Add(danceClass);
        await _context.SaveChangesAsync();
    }
}
