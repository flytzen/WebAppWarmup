namespace WebApp.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Serilog;

    using WebApp.Services;

    public class HealthcheckController : Controller
    {
        private FakeService service;

        public HealthcheckController()
        {
            this.service = new FakeService();
        }

        public IActionResult Index()
        {
            // It would be very nice to use NotDeadYet here as it has timeouts on checks etc, but doesn't support dotnetcore yet
            try
            {
                Log.Information("Health check started");
                var result = this.service.GetSomeData();
                // You could be more sophisticated here; right now we are just relying on this timing out. But you could, for example, 
                // directly test for whether it has already been initialised and return a 503 if not. That is especially useful if we have something that 
                // kicks off initialisation code separately
                return this.Ok("Happy");
            }
            catch (Exception e)
            {
                Log.Error(e, "Healthcheck failed!");
                return this.StatusCode(500, "Healthcheck failed");
            }
        }
        
    }
}