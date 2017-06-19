

using DroneLander.Data;
using DroneLander.Models;
using System;
using Newtonsoft.Json.Linq;

namespace DroneLander.Helpers
{
    public static class ActivityHelper
    {
        public static async void AddActivityAsync(LandingResultType landingResult)
        {
            try
            {
                await TelemetryManager.DefaultManager.AddActivityAsync(new ActivityItem()
                {
                    ActivityDate = DateTime.Now.ToUniversalTime(),
                    Status = landingResult.ToString(),
                    Description = (landingResult == LandingResultType.Landed) ? "The Eagle has landed!" : "That's going to leave a mark!"
                });
            }
            catch { }
        }

        public static async void SendTelemetryAsync(string userId, double altitude, double descentRate, double fuelRemaining, double thrust)
        {
            TelemetryItem telemetry = new TelemetryItem()
            {
                Altitude = altitude,
                DescentRate = descentRate,
                Fuel = fuelRemaining,
                Thrust = thrust,
                Tagline = Common.TelemetryConstants.Tagline,
                DisplayName = Common.TelemetryConstants.DisplayName,
                UserId = userId,
            };

            try
            {
                await TelemetryManager.DefaultManager.CurrentClient.InvokeApiAsync("telemetry", JToken.FromObject(telemetry));
            }
            catch { }
        }
    }
}
