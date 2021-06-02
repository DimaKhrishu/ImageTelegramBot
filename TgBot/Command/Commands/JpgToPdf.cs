using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using TgBot.Clients;

namespace TgBot.Command.Commands
{
    class JpgToPdf : Command
    {
        public static List<Command> commands { get; set; }
        public override string Name { get; set; } = "/convertToPdf";
        private readonly ImageClient _imageClient = new ImageClient();
        public override TelegramBotClient client { get; set; }
        private string Url { get; set; }
        
        public override async void Execute(Message message, TelegramBotClient _client)
        {
            this.client = _client;
            await _client.SendTextMessageAsync(message.From.Id, "Send URL for image");
            this.client.OnMessage += GetString;
        }
        private async void GetString(object sender, MessageEventArgs e)
        {
            Url = e.Message.Text;
            foreach (Command command in commands)
            {
                if (Url == command.Name)
                {
                    return;
                }
            }
            Regex reg = new Regex(@"https(?:[\w\d\/\:\.\-]+)\.jpg");
            MatchCollection match = reg.Matches(Url);
            ImageClient im = new ImageClient();
            
            if (match.Count > 0)
            {
                var result = await im.ConvertToPdf(Url);
                await client.SendTextMessageAsync(e.Message.From.Id, result);
                await client.SendTextMessageAsync(e.Message.From.Id, "Here is your PDF! " +
                   "Type /help to see my commands.");
                this.client.OnMessage -= GetString;
            }
            else
            {
                await client.SendTextMessageAsync(e.Message.From.Id, "This is not URL");
            }
                
            
            
           
        }
    }
}
