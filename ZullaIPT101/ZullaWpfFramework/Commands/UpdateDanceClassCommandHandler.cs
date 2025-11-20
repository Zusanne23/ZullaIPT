using Microsoft.EntityFrameworkCore;
using ZullaWpfDomain.Commands;

namespace ZullaWpfFramework.Commands;

public class UpdateDanceClassCommandHandler : ICommandHandler<UpdateDanceClassCommand>
{
    private readonly ZullaWpfDbContext _context;

    public UpdateDanceClassCommandHandler(ZullaWpfDbContext context)
    {
        _context = context;
    }

    public async Task ExecuteAsync(UpdateDanceClassCommand command)
    {
        var danceClass = await _context.DanceClasses.FirstOrDefaultAsync(d => d.Id == command.Id);
        
        if (danceClass != null)
        {
            danceClass.Title = command.Title;
            danceClass.DanceStyle = command.DanceStyle;
            danceClass.Instructor = command.Instructor;
            danceClass.Schedule = command.Schedule;

            await _context.SaveChangesAsync();
        }
    }
}
