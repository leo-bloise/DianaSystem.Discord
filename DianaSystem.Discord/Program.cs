using Diana.Core.Defaults;
using DianaSystem.Discord.Application;
using DianaSystem.Discord.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DianaSystem.Discord
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            DianaApplicationBuilder builder = DianaApplicationBuilder.Create(args);
            builder.Services.AddDbContextPool<DianaContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWalletService, WalletService>();
            IHost host = builder.Build();
            await host.StartAsync();
            await Task.Delay(-1);
        }
    }
}
