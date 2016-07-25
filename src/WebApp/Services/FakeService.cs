namespace WebApp.Services
{
    using System;
    using System.Threading;

    using Serilog;

    public class FakeService
    {
        private static readonly object Locker = new object();

        private static Guid identifier;
        private static volatile bool initialized;

        public static DateTime Initialised { get; private set; }

        public string GetSomeData()
        {
            InitializeIfRequired();
            return identifier.ToString();
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
            identifier = Guid.NewGuid();
            Initialised = DateTime.UtcNow;
            initialized = true;
            Log.Information("FakeService initialization finished");
        }
    }
}
