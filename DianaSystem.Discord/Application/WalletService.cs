using DianaSystem.Discord.Data;
using DianaSystem.Discord.Data.Entities;

namespace DianaSystem.Discord.Application
{
    public class WalletService : IWalletService
    {
        private DianaContext DianaContext;
        public WalletService(DianaContext Context) 
        { 
            DianaContext = Context;
        }
        public Task<Wallet> CreateWalletAsync(User user, DianaContext context)
        {
            Wallet wallet = new Wallet
            {
                User = user,
                Balance = 0 
            };
            context.Wallets.Add(wallet);
            return Task.FromResult(wallet);
        }

        public Task<Wallet?> GetWalletAsync(string discordId)
        {
            var wallet = DianaContext.Wallets.Where(wallet => wallet.User.DiscordId == discordId).First();
            return Task.FromResult(wallet);
        }
    }
}
