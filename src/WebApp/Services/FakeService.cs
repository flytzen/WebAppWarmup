namespace WebApp.Services
{
    using System;
    using System.Threading;

    using Serilog;

    public class FakeService
    {
        private static readonly object Locker = new object();

        private static volatile bool initialized;
        private static Random rnd;
        public int GetSomeData()
        {
            InitializeIfRequired();
            return rnd.Next(1, 100);
        }

        private static void InitializeIfRequired()
        {
            if (!initialized)
            {
                lock (Locker)
                {
                    Initialize();
                }
            }
        }

        private static void Initialize()
        {
            Log.Information("Starting FakeService initialisation");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            rnd = new Random();
            initialized = true;
            Log.Information("FakeService initialization finished");
        }
    }
}
