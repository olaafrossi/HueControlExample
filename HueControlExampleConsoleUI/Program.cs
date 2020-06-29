using HueControlExampleLibrary;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HueControlExampleConsoleUI
{
    class Program
    {
        static public void Main(string[] args)
        {
            // Doesn't need to register
            //Register();
            //Thread.Sleep(500);
            GetClient();
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

        static async Task<LocalHueClient> GetClient()
        {
            LocalHueClient client;

            HueSystemSettings Settings = new HueSystemSettings
            {
                IpAddress = "192.168.1.160", Key = "CYME6zExAy7IznAFHjHzhhCUyHPq-nYlHN5-eJDW"
            };

            client = new LocalHueClient(Settings.IpAddress);
            client.Initialize(Settings.Key);

            if (client.IsInitialized == false)
            {
                return null;
            }

            return client;
        }

        async static Task RunLightCommand()
        {
            LocalHueClient client = await GetClient();

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
