using System;
using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class PrefixModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task HandlerPingCommand()
        {
            await Context.Message.ReplyAsync("Ping!");
        }
    }
}
