using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DroneLander.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            //app.Screenshot("First screen.");
            // querying the UI for a button labeled "Start" and then passing it to the Tap method
            app.Tap(x => x.Button("START"));
            //a screen shot after the button is tapped — that is, once the drone has begun descending to the Mars surface.
            app.Screenshot("The app in progress.");
        }
    }
}

