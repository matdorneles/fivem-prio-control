using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace PrioControlServer
{
    internal class MainServer : BaseScript
    {
        public static Dictionary<string, string> status = new Dictionary<string, string>()
        {
            { "av", "~g~Available" },
            { "oh", "~y~On Hold" },
            { "cd", "~b~Cooldown" }
        };

        string cityStatus = status["av"];
        string countyStatus = status["av"];

        string cityHud = status["av"];
        string countyHud = status["av"];

        public MainServer() {
            RegisterCommand("cityppause", new Action(CityPrioPause), false);
            RegisterCommand("countyppause", new Action(CountyPrioPause), false);

            RegisterCommand("cityprio",)

            RegisterCommand("citycd10", new Action(CityCd10), false);
        }

        [EventHandler("Sync")]
        public void Sync()
        {
            TriggerClientEvent("UpdateHud", cityHud, countyHud);
        }

        public void CityPrioPause()
        {
            if (cityStatus == status["av"])
            {
                cityStatus = status["oh"];
                cityHud = status["oh"];
            }
            else if (cityStatus == status["oh"])
            {
                cityStatus = status["av"];
                cityHud = status["av"];
            }
            Sync();
        }

        public void CountyPrioPause()
        {
            if (countyStatus == status["av"])
            {
                countyStatus = status["oh"];
                countyHud = status["oh"];
            }
            else if (countyStatus == status["oh"])
            {
                countyStatus = status["av"];
                countyHud = status["av"];
            }
            Sync();
        }

        public async void CityCd10()
        {
            if(cityStatus == status["av"])
            {
                for (int i = 10; i > 0; i--)
                {
                    cityStatus = status["cd"];
                    cityHud = $"~b~{i} minutes {cityStatus}";
                    Sync();
                    await Delay(60000);
                }
                cityStatus = status["av"];
                cityHud = cityStatus;
                Sync();
            }
            else
            {
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] {255, 0, 0},
                    multiline = false,
                    args = new[] {"Me", "You can not activate cooldown at the moment"}
                });
            }
        }
    }
}
