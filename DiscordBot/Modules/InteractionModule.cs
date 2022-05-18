using System;
using Discord.Interactions;
using Discord;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiscordBot.Modules
{
    public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("ping", "Receive a ping message!")]

        public async Task HandlePingCommand()
        {
            await RespondAsync("Ping!");
        }
        [SlashCommand("components", "Demonstrate buttons and select menus.")]

        public async Task HandleComponentCommand()
        {


            var button = new ButtonBuilder()
            {
                Label = "Button!",
                CustomId = "button",
                Style = ButtonStyle.Primary
            };

            var menu = new SelectMenuBuilder()
            {
                CustomId = "menu",
                Placeholder = "Sample Menu"
            };

            menu.AddOption("First Option", "first");
            menu.AddOption("Second Option", "second");

            var component = new ComponentBuilder();
            component.WithButton(button);
            component.WithSelectMenu(menu);

            await RespondAsync("test", components: component.Build());
        }
        [ComponentInteraction("button")]

        public async Task HandleButtonInput()
        {
            await RespondWithModalAsync<DemoModal>("test_modal");
        }

        [ComponentInteraction("menu")]

        public async Task HandleMenuSelection(string[] inputs)
        {
            await RespondAsync(inputs[0]);
        }


        [ModalInteraction("test_modal")]

        public async Task  HandleModalInput(DemoModal modal)
        {
            string input = modal.Greeting;
            await RespondAsync(input);
        }
      
    }

    public class DemoModal : IModal
    {
        public string Title => "Demo Modal";
        [InputLabel("Send a greating!")]
        [ModalTextInput("greeting_input", TextInputStyle.Short, placeholder: "Be nice...", maxLength: 100)] 
        public string Greeting { get; set; }
    }

}
