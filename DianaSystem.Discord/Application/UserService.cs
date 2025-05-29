using DianaSystem.Discord.Data;
using DianaSystem.Discord.Data.Entities;
using Discord.WebSocket;

namespace DianaSystem.Discord.Application
{
    public class UserService : IUserService
    {
        private IWalletService WalletService { get; }
        private DianaContext Context { get; }
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
    }
}
