using HueControlExampleLibrary;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace HueControlExampleConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {

            // Doesn't need to register
            //Register();
            //Thread.Sleep(500);
            HueManager.GetClient();
            Thread.Sleep(500);
            RunLightCommand();

            Console.WriteLine("Ran some lights");
        }

        //async static Task Register()
        //{
        //    string ip = "192.168.1.160";
        //    ILocalHueClient client = new LocalHueClient(ip);
        //    var appKey = await client.RegisterAsync("Project", "CYME6zExAy7IznAFHjHzhhCUyHPq-nYlHN5-eJDW");
        //}

       

        static async Task RunLightCommand()
        {
            LocalHueClient client = await HueManager.GetClient();

            if (client == null)
            {
                return;
            }

            var command = new LightCommand();

            // some random settings for tests
            command.SetColor(255);
            client.SendCommandAsync(command);
            Thread.Sleep(1000);
            command.TurnOff();
            client.SendCommandAsync(command);
            Thread.Sleep(1000);
            command.TurnOn();
            client.SendCommandAsync(command);
            Thread.Sleep(1000);
            command.TurnOff();
            client.SendCommandAsync(command);
            Thread.Sleep(1000);
            command.TurnOn();
            client.SendCommandAsync(command);
            Thread.Sleep(1000);
            command.SetColor(100);
            client.SendCommandAsync(command);
        }

    }
}
