using DianaSystem.Discord.Data.Entities;
using Discord.WebSocket;

namespace DianaSystem.Discord.Application
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(SocketUser socketUser);
    }
}
