using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgBot.Clients;

namespace TgBot.Command
{
    public abstract class Command
    {
        public abstract string Name { get; set; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public abstract TelegramBotClient client { get; set; }
        private readonly ImageClient _imageClient = new ImageClient();

    }
}
