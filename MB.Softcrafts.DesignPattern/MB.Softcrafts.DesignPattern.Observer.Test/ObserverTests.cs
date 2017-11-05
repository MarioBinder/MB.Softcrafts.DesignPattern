using System;
using NUnit.Framework;

namespace MB.Softcrafts.DesignPattern.Observer.Test
{
    [TestFixture]
    public class ObserverTests
    {
        [Test]
        public void Test()
        {
            NotificationProvider provider = new NotificationProvider();
            NotificationMonitor observer1 = new NotificationMonitor("Taxi Filiale 1");
            NotificationMonitor observer2 = new NotificationMonitor("Taxi Filiale 2");

            observer1.Subscribe(provider);
            //observer2.Subscribe(provider);


            provider.InfoStatus(712, "Neue Fahrt - Berlin-Weißensee nach Lichtenberg", 3);
            provider.InfoStatus(400, "Neue Fahrt - Berlin Lichterfelde", 1);

            provider.InfoStatus(712, "Fahrt storniert - Berlin-Weißensee nach Lichtenberg", 3);
            provider.LastNotificationClaimed();
            Console.WriteLine("ende");


            //           Console.WriteLine("Taxi Filiale 2 - Keine Fahrer");
            //observer2.Unsubscribe();

            observer1.Subscribe(provider);
            provider.InfoStatus(400, "Neue Fahrt - Berlin Charlottenburg", 3);







        }
    }
}
