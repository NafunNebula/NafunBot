using System;
using System.Threading.Channels;
using TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace NafunBot
{
    class Bot
    {
        TwitchClient client;

        public Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials("", "");
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, "PunguinVevo");

            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnConnected += Client_OnConnected;

            client.Connect();
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            //Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
            Console.Write(e.Data);
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            client.SendMessage(e.Channel, "Nafun Bot has arrived!");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            try
            {
                string[] message = e.ChatMessage.Message.Split(" ");
                if (e.ChatMessage.Message[0].ToString().Equals("$"))
                {
                    Console.WriteLine("Attempting to execute command!");
                    Console.WriteLine("Command is: " + message[1]);

                    var myCommand = CommandFactory.create(message[1]);
                    //Console.WriteLine(myCommand.executeCommand(null));
                    string commandResult = myCommand.executeCommand(null);

                    client.SendMessage(e.ChatMessage.Channel, commandResult);
                }
            }
            catch (Exception ex)
            {
                client.SendMessage(e.ChatMessage.Channel, "Invalid Command!");
            }
        }
    }
}