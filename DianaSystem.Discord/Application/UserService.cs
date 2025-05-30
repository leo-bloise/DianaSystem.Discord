using DianaSystem.Discord.Data;
using DianaSystem.Discord.Data.Entities;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;

namespace DianaSystem.Discord.Application
{
    public class UserService : IUserService
    {
        private IWalletService WalletService { get; }
        private DianaContext Context { get; }
        private static readonly Func<DianaContext, string, bool> UserExistsQuery = EF.CompileQuery<DianaContext, string, bool>((dbContext, discordId) => dbContext.Users.Any(user => user.DiscordId == discordId));
        public UserService(IWalletService walletService, DianaContext context)
        {
            WalletService = walletService;
            Context = context;
        }
        public async Task<User> CreateUserAsync(SocketUser socketUser)
        {
            string id = socketUser.Id.ToString();
            User user = new User()
            {
                DiscordId = id,
            };
            await WalletService.CreateWalletAsync(user, Context);
            Context.SaveChanges();
            return user;
        }
        public Task<bool> UserExistsAsync(string username)
        {
            return Task.FromResult(UserExistsQuery.Invoke(Context, username));            
        }
    }
}
