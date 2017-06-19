

using DroneLander.Service.DataObjects;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using System.Threading.Tasks;
using System.Web.Http;

namespace DroneLander.Service.Controllers
{
    /**
     * Note the [MobileAppController] attribute decorating the class definition. This attribute designates an ApiController as an Azure Mobile App controller, meaning it can be accessed through the Azure Mobile SDK using standard APIs. TelemetryController is responsible for sending real-time telemetry to Mission Control to monitor the progress of landing attempts.
     * **/
    [Authorize]
    [MobileAppController]
    public class TelemetryController : ApiController
    {
        // GET api/telemetry
        public string Get()
        {
            MobileAppSettingsDictionary settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            string host = settings.HostName ?? "localhost";
            string greeting = $"Hello {host}. You are currently connected to Mission Control";

            return greeting;
        }

        // POST api/telemetry
        public async Task<string> Post(TelemetryItem telemetry)
        {
            await Helpers.TelemetryHelper.SendToMissionControlAsync(telemetry);
            return $"Telemetry for {telemetry.UserId} received by Mission Control.";
        }
    }
}