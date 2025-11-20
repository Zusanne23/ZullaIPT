using Microsoft.EntityFrameworkCore;
using ZullaWpfDomain.Commands;

namespace ZullaWpfFramework.Commands;

public class DeleteDanceClassCommandHandler : ICommandHandler<DeleteDanceClassCommand>
{
    private readonly ZullaWpfDbContext _context;

    public DeleteDanceClassCommandHandler(ZullaWpfDbContext context)
    {
        _context = context;
    }

    public async Task ExecuteAsync(DeleteDanceClassCommand command)
    {
        var danceClass = await _context.DanceClasses.FirstOrDefaultAsync(d => d.Id == command.Id);
        
        if (danceClass != null)
        {
            _context.DanceClasses.Remove(danceClass);
            await _context.SaveChangesAsync();
        }
    }
}
