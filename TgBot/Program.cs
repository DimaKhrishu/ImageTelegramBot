using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using TgBot.Command.Commands;

namespace TgBot
{
    class Program
    {
        static TelegramBotClient client;
        private static List<Command.Command> commands;
        static void Main(string[] args)
        {
            client = new TelegramBotClient("1703267911:AAHhRFPWypVB--ZI1_DYfjySakPklkCS4yI");

            client.OnMessage += BotOnMessageReceived;
            client.OnCallbackQuery += BotOnCallbackQueryReceived;
            commands = new List<Command.Command>();
            commands.Add(new Start());
            commands.Add(new RemoveBackground());
            commands.Add(new JpgToPdf());
            commands.Add(new Help());
            var me = client.GetMeAsync().Result;
            Console.WriteLine(me.FirstName);
            client.StartReceiving();
            Console.ReadLine();
            client.StopReceiving();
        }

        private static void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null || message.Type != MessageType.Text)
                return;
            string name = $"{message.From.FirstName} {message.From.LastName}";
            Console.WriteLine($"{name} отправил сообщение: '{message.Text}'");
            foreach (var comm in commands)
            {
                if (message.Text == comm.Name)
                {
                    comm.Execute(message, client);
                }
            }
        }
    }
}
