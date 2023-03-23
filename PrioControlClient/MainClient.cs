using CitizenFX.Core;
using System;
using System.Threading.Tasks;

namespace PrioControlClient
{
    public class MainClient : BaseScript
    {
        static string city;
        static string county;
        static bool synced = false;
        
        public MainClient() {
            Tick += OnTick;
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private static void OnClientResourceStart(string resource)
        {
            if (!synced) { 
                TriggerServerEvent("Sync");
                synced = true;
            }
        }

        private async Task OnTick()
        {
            PrioHud.DrawTextCity(city);
            PrioHud.DrawTextCounty(county);
        }

        [EventHandler("UpdateHud")]
        private static void UpdateHud(string newCity, string newCounty)
        {
            city = newCity;
            county = newCounty;
        }
    }
}
