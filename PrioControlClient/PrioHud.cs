
using CitizenFX.Core.Native;

namespace PrioControlClient
{
    internal class PrioHud
    {
        public static void DrawTextCity(string city)
        {
            API.SetTextFont(0);
            API.SetTextScale(0.0f, 0.3f);
            API.SetTextColour(128, 128, 128, 255);
            API.SetTextDropshadow(0, 0, 0, 0, 255);
            API.SetTextDropShadow();
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString($"~w~City Priority: {city}");
            API.DrawText(0.168f, 0.8725f);
        }

        public static void DrawTextCounty(string county)
        {
            API.SetTextFont(0);
            API.SetTextScale(0.0f, 0.3f);
            API.SetTextColour(128, 128, 128, 255);
            API.SetTextDropshadow(0, 0, 0, 0, 255);
            API.SetTextDropShadow();
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString($"~w~County Priority: {county}");
            API.DrawText(0.168f, 0.8520f);
        }
    }
}
