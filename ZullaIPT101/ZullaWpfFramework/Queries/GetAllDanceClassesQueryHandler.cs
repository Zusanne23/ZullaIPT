using Microsoft.EntityFrameworkCore;
using ZullaWpfDomain.Models;
using ZullaWpfDomain.Queries;

namespace ZullaWpfFramework.Queries;

public class GetAllDanceClassesQueryHandler : IQueryHandler<GetAllDanceClassesQuery, IEnumerable<DanceClass>>
{
    private readonly ZullaWpfDbContext _context;

    public GetAllDanceClassesQueryHandler(ZullaWpfDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DanceClass>> HandleAsync(GetAllDanceClassesQuery query)
    {
        var dtos = await _context.DanceClasses.ToListAsync();
        
        return dtos.Select(dto => new DanceClass
        {
            Id = dto.Id,
            Title = dto.Title,
            DanceStyle = dto.DanceStyle,
            Instructor = dto.Instructor,
            Schedule = dto.Schedule
        });
    }
}
