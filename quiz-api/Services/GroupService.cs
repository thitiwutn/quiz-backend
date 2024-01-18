using Microsoft.EntityFrameworkCore;
using quiz_api.Entities;
using quiz_api.Services.Models;

namespace quiz_api.Services;

public class GroupService
{
    private readonly DatabaseContext _context;

    public GroupService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ICollection<GroupModel>> GetGroups()
    {
        var groups = await _context.Groups
            .Select(a => new GroupModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToListAsync();
        return groups;
    }
}