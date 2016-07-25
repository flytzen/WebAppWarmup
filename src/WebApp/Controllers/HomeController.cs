namespace WebApp.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using Serilog;

    using WebApp.Services;

    public class HomeController : Controller
    {
        private FakeService service;

        public HomeController()
        {
            this.service = new FakeService();
        }

        public IActionResult Index()
        {
            Log.Information("HomeController.Index called");
            try
            {
                return this.View("Index", this.service.GetSomeData());
                //return this.Ok("plain");
                //return this.View("Index", "bob");
            }
                catch (Exception e)
            {
                Log.Error(e, "HomeController.Index failed");
                throw;
            }
        }
    }
}