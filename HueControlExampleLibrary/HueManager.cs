using HueControlExampleLibrary;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace HueControlExampleLibrary
{
    public static class HueManager
    {
        public static async Task<LocalHueClient> GetClient()
        {
            LocalHueClient client;

            HueSystemSettings Settings = new HueSystemSettings
            {
                IpAddress = "192.168.1.160",
                Key = "CYME6zExAy7IznAFHjHzhhCUyHPq-nYlHN5-eJDW"
            };

            client = new LocalHueClient(Settings.IpAddress);
            client.Initialize(Settings.Key);

            if (client.IsInitialized == false)
            {
                return null;
            }

            return client;
        }
    }
}
