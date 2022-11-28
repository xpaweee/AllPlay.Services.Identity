using AllPlay.Services.Identity.Core.Entities;

namespace AllPlay.Services.Identity.Core.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task GetUserByNameAsync(string name);
}