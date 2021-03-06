﻿using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;
using HueControlExampleLibrary;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.HSB;

namespace HueControlExampleWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("https://huecontrolwebassemblyexampleserve-olaafrossi.azurewebsites.net/ChatHub")
                .WithAutomaticReconnect()
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private async void connectButton_Click(object sender, RoutedEventArgs e)
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    messagesList.Items.Add(newMessage);
                    if (message == "1" )
                    {
                        RunLightCommand01();
                    }
                    else if (message == "2")
                    {
                        RunLightCommand02();
                    }
                });
            });

            try
            {
                await connection.StartAsync();
                messagesList.Items.Add("Connection started");
                connectButton.IsEnabled = false;
                sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void sendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    userTextBox.Text, messageTextBox.Text);
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private void Cue1Button_OnClickButton_Click(object sender, RoutedEventArgs e)
        {

            HueManager.GetClient();
            Thread.Sleep(500);
            RunLightCommand01();

            Console.WriteLine("Ran some lights");
        }
        private void Cue2Button_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            HueManager.GetClient();
            Thread.Sleep(500);
            RunLightCommand02();

            Console.WriteLine("Ran some lights");
        }

        //async static Task Register()
        //{
        //    string ip = "192.168.1.160";
        //    ILocalHueClient client = new LocalHueClient(ip);
        //    var appKey = await client.RegisterAsync("Project", "CYME6zExAy7IznAFHjHzhhCUyHPq-nYlHN5-eJDW");
        //}

        static async Task RunLightCommand01()
        {
            LocalHueClient client = await HueManager.GetClient();

            if (client == null)
            {
                return;
            }

            var command = new LightCommand();

            // some random settings for tests
            command.SetColor(new RGBColor(255, 0, 0));
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
            //command.SetColor(100);
            //client.SendCommandAsync(command);
            Thread.Sleep(1000);
            command.SetColor(new RGBColor(0,255,0));
            client.SendCommandAsync(command);
        }

        static async Task RunLightCommand02()
        {
            LocalHueClient client = await HueManager.GetClient();

            if (client == null)
            {
                return;
            }

            var command = new LightCommand();

            // some random settings for tests
            command.SetColor(new RGBColor(255, 255, 255));
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
            command.SetColor(new RGBColor(127, 0, 255));
            client.SendCommandAsync(command);
        }
    }
}


