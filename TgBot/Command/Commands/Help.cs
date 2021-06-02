using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgBot.Clients;

namespace TgBot.Command.Commands
{
    class Help : Command
    {
        public override string Name { get; set; } = "/help";
        private readonly ImageClient _imageClient = new ImageClient();
        public override TelegramBotClient client { get; set; }

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string helpText =
                    $"Here is what I can do:" +
                    $"\n/removeBg - remove background." +
                     $"\n/convertToPdf - convert image/images to PDF";
            await client.SendTextMessageAsync(message.From.Id, helpText);
        }
    }
}
