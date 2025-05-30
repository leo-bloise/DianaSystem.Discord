using Diana.Core.Host;
using DianaSystem.Discord.Application;
using DianaSystem.Discord.Data.Entities;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

namespace DianaSystem.Discord.Commands
{
    public class CoinsCommand : ICommand
    {
        public IUserService UserService { get; }
        public IWalletService WalletService { get; }
        public ILogger<CoinsCommand> Logger { get; }
        public CoinsCommand(
            IUserService userService, 
            IWalletService walletService,
            ILogger<CoinsCommand> logger
        )
        {
            UserService = userService;
            WalletService = walletService;
            Logger = logger;
        }
        public SlashCommandBuilder Build()
        {
            return new SlashCommandBuilder()
                .WithName("coins")
                .WithDescription("See how many coins you have or, maybe, join the Universe.");
        }
        public async Task Handle(SocketSlashCommand command)
        {
            SocketUser socketUser = command.User;
            string socketUserId = socketUser.Id.ToString();
            Logger.LogDebug($"CoinsCommand called from {socketUser.Username}");
            if (await UserService.UserExistsAsync(socketUserId))
            {
                Wallet? wallet = await WalletService.GetWalletAsync(socketUserId);
                if (wallet == null)
                {
                    Logger.LogError($"User [discordId][{socketUserId}] exists, but it does not have a wallet");
                    await command.RespondAsync("I've lost your wallet :(");
                    return;
                }
                await command.RespondAsync($"Coins {wallet.Balance}");
                return;
            }
            Logger.LogDebug($"User does not exist {socketUser.Username}. Creating it with DiscordId -> {socketUserId}");
            await UserService.CreateUserAsync(socketUser);
            await command.RespondAsync($"You have joined the Universe, {socketUser.Username}! Your coins will be tracked from now on.");
        }
    }
}
