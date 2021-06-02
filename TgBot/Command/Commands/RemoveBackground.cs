using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TgBot.Clients;
using System.Drawing;
using Telegram.Bot.Types.InputFiles;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using static TgBot.Models.GetTgImage;

namespace TgBot.Command.Commands
{
    class RemoveBackground : Command
    {
        public static List<Command> commands { get; set; }
        public override string Name { get; set; } = "/removeBg";
        private readonly ImageClient _imageClient = new ImageClient();
        public override TelegramBotClient client { get; set; }
        private string Url { get; set; }
        private string Photo { get; set; }
        public override async void Execute(Message message, TelegramBotClient _client)
        {
            this.client = _client;
            await _client.SendTextMessageAsync(message.From.Id,"Send URL for image");
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
            ImageClient im = new ImageClient();
            //var photo = e.Message.Photo[0];
            //var Id = photo.FileId;
            //Console.WriteLine(Id);
            //Url = await im.GetTgImage(Id);
            Regex reg = new Regex(@"https(?:[\w\d\/\:\.\-]+)\.jpg");
            MatchCollection match = reg.Matches(Url);
            
            
            if (match.Count > 0)
            {
                var result = await im.RemoveBackground(Url);
                await client.SendPhotoAsync(e.Message.From.Id, result);
                await client.SendTextMessageAsync(e.Message.From.Id, "Here is your processed image! " +
                    "Type /help to see my commands.");
                this.client.OnMessage -= GetString;
            }
            else
            {
                await client.SendTextMessageAsync(e.Message.From.Id, "This is not URL");

            }



            client.OnMessage -= GetString;
        }
      
    }
}
