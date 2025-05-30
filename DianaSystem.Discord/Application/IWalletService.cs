using DianaSystem.Discord.Data;
using DianaSystem.Discord.Data.Entities;
namespace DianaSystem.Discord.Application
{
    public interface IWalletService
    {
        /// <summary>
        /// Creates a wallet for an User.
        /// It must not be used alone, so the client must provide a valid context to use it properly.
        /// The created wallet is attached to the context and you must call SaveChanges or SaveChangesAsync to persist it.
        /// </summary>        
        Task<Wallet> CreateWalletAsync(User user, DianaContext context);
        Task<Wallet?> GetWalletAsync(string discordId);
    }
}
