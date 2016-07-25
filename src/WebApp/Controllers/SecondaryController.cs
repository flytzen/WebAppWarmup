namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using WebApp.Services;

    public class SecondaryController : Controller
    {
        private FakeService service;

        public SecondaryController()
        {
            this.service = new FakeService();
        }

        public IActionResult Index()
        {
            return this.View("Index", this.service.GetSomeData());
        }
    }
}