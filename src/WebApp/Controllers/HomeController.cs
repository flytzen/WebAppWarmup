namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
            return this.View(this.service.GetSomeData());
        }
    }
}