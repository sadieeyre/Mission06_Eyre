using Microsoft.AspNetCore.Mvc;
using Mission06_Eyre.Models;
using System.Diagnostics;

namespace Mission06_Eyre.Controllers
{
    public class HomeController : Controller
    {

        private Mission06Context _context;
        public HomeController(Mission06Context temp) //Constructor
        {
            _context = temp;
        } 

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult AddMovie(Application response) 
        {
            _context.Movies.Add(response);
            _context.SaveChanges();


            return View("thankyou", response);
        }
    }
}
