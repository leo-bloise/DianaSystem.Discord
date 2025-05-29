using Diana.Core.Host;
using DianaSystem.Discord.Application;
using Discord;
using Discord.WebSocket;
using DianaSystem.Discord.Data.Entities;

namespace DianaSystem.Discord.Commands
{
    public class CoinsCommand : ICommand
    {
        public IUserService UserService { get; }
        public CoinsCommand(IUserService userService)
        {
            UserService = userService;
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
            await UserService.CreateUserAsync(socketUser);
            await command.RespondAsync($"You have joined the Universe, {socketUser.Username}! Your coins will be tracked from now on.");
        }
    }
}
