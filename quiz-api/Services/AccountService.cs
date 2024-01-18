using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using quiz_api.Entities;
using quiz_api.Entities.Models;
using quiz_api.Services.Models.Request;
using quiz_api.Services.Models.Response;

namespace quiz_api.Services;

public class AccountService
{
    private readonly DatabaseContext _context;

    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<UserResponse> GetUser(string userName)
    {
        var user = await _context.Users
            .Include(i => i.Group)
            .FirstOrDefaultAsync(a => a.Name == userName);
        if (user == null)
            throw new ValidationException("User not found.");
        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            GroupId = user.GroupId,
            GroupName = user.Group.Name
        };
    }

    public async Task<UserResponse> CreateUser(CreateUser user)
    {
        if (_context.Users.Any(a => a.Name == user.Name))
            throw new ValidationException("User already exists cannot be used to register again.");

        var group = await _context.Groups.FirstOrDefaultAsync(a => a.Id == user.GroupId);
        if (group == null)
            throw new ValidationException("Group not found.");
        var newUser = new User
        {
            Name = user.Name,
            Group = group,
            Inactive = false
        };
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        return new UserResponse
        {
            Id = newUser.Id,
            Name = newUser.Name,
            GroupId = newUser.GroupId,
            GroupName = newUser.Group.Name
        };
    }
}