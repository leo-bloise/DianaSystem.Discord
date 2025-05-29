using DianaSystem.Discord.Data;
using DianaSystem.Discord.Data.Entities;

namespace DianaSystem.Discord.Application
{
    public class WalletService : IWalletService
    {
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
    }
}
