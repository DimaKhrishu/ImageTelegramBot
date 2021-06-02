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
    class Start : Command
    {
        public override string Name { get; set; } = "/start";
        private readonly ImageClient _imageClient = new ImageClient();
        public override TelegramBotClient client { get; set; }

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string startText =
                    $"Hi {message.From.FirstName} {message.From.LastName}! I can help you with your images." +
                    $"\nHere is what I can do:" +
                    $"\n/removeBg - remove background." +
                     $"\n/convertToPdf - convert image/images to PDF";
            await client.SendTextMessageAsync(message.From.Id, startText);
        }
    }
}
