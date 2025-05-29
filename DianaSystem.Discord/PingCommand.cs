using Diana.Core.Host;
using Discord;
using Discord.WebSocket;

namespace DianaSystem.Discord
{
    public class PingCommand : ICommand
    {
        public SlashCommandBuilder Build()
        {
            return new SlashCommandBuilder()
                .WithName("ping")
                .WithDescription("Replies with Pong!");
        }

        public async Task Handle(SocketSlashCommand command)
        {
            await command.RespondAsync("Pong!");
        }
    }
}
