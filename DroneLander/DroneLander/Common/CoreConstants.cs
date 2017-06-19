﻿

namespace DroneLander.Common
{
    public static class CoreConstants
    {
        public const double Gravity = 3.711;      // Mars gravity (m/s2)
        public const double LanderMass = 17198.0; // Lander mass (kg)
        public const int PollingIncrement = 500;

        public const double StartingAltitude = 5000.0;
        public const double StartingVelocity = 0.0;
        public const double StartingFuel = 1000.0;
        public const double StartingThrust = 0.0;
    }

    public static class MobileServiceConstants
    {
        public const string AppUrl = "https://dronelandermobilejw.azurewebsites.net";
    }

    public static class TelemetryConstants
    {
        public const string DisplayName = "Johnson";
        public const string Tagline = "jjj";
    }
}
