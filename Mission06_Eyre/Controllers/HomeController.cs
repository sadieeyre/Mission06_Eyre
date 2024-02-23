using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Eyre.Models;
using System.Diagnostics;
using System.Linq;


namespace Mission06_Eyre.Controllers
{
    public class HomeController : Controller
    {

        private Mission06Context _context;
        public HomeController(Mission06Context temp) //Constructor
        {
            _context = temp;
        } 

        //Index or home page
        public IActionResult Index()
        {
            return View();
        }

        //Route to Get to Know Joel Page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        //Get page to load Add Movies page and add categories to the loads
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("AddMovie", new Movie());  
        }

        //When post form, this is the response. It will update any changes made or add a new record. 
        //It will then take them to the thank you page if submission is successful!
        [HttpPost]
        public IActionResult AddMovie(Movie response) 
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();


                return View("thankyou", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }

        }
        //Page to display the movie collection. Order by title for cleanliness and include the category table
        public IActionResult display()
        {
            var Movies = _context.Movies
                .OrderBy(x => x.Title)
                .Include(m => m.Category)
                .ToList();
            
            return View(Movies);
        }

        //route to edit. when the user clicks edit, it will preload their answers and allow them to update that specific record.
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("AddMovie", recordToEdit);
        }

        //Post for edit- it will update the info and save the changes. Then it takes them back to the list of movies!
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("display");
        }
       
        //Get for delete- it will load movies and set the movieID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        //When they click submit, it will remove the record, save the change, and take them back to the list.
        [HttpPost]
        public IActionResult Delete(Movie updatedInfo)
        {
            _context.Movies.Remove(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("display");
        }

    }
}
