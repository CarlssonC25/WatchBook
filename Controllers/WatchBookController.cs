using Microsoft.AspNetCore.Mvc;

namespace WatchBook.Controllers
{
    public class WatchBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnimeView()
        {
            return View();
        }

        public IActionResult MovieView()
        {
            return View();
        }

        public IActionResult SettingsView()
        {
            return View();
        }

		public IActionResult SearchView()
		{
			return View();
		}

        public IActionResult ItemView() 
        { 
            return View(); 
        }

        public IActionResult AddNewView()
        {
            return View();
        }

    }
}
