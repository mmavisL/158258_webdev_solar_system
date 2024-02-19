using _14068570___Solar_System.Data;
using _14068570___Solar_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _14068570___Solar_System.Controllers
{
    public class PlanetController : Controller
    {
        private SolarSystemContext _context;
        public PlanetController()
        {
            _context = new SolarSystemContext();
        }
        public ActionResult Index(string search,string category,string sortBy)
        {
            List<Planet> planets = _context.Planets.OrderBy(p=>p.Body).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                planets = planets.Where(p=>p.Body.ToLower().Contains(search.ToLower())).ToList();
            }
            if(!string.IsNullOrEmpty(category))
            {
                planets = planets.Where(p => p.Category.Name == category).ToList();    
            }

            if (!string.IsNullOrEmpty(sortBy)) 
            {
                switch (sortBy)
                {
                    case "Body Ascending":
                    default:
                        planets = planets.OrderBy(p => p.Body).ToList();
                        break;
                    case "Body Descending":
                        planets =planets.OrderByDescending(p => p.Body).ToList();
                        break;
                    case "Radius Ascending":
                        planets =planets.OrderBy(p=>p.Radius).ToList();
                        break;
                    case "Radius Descending":
                        planets =planets.OrderByDescending(p => p.Radius).ToList();
                        break;

                }
            }

            var categories = _context.Categories.Select(c=>c.Name).Distinct().ToList();

            ViewBag.category = new SelectList(categories);

            
            ViewBag.sortBy = new SelectList(new List<string>() { "Body Descending", "Body Ascending", "Radius Descending", "Radius Ascending" });
            return View(planets);

        }

        public ActionResult Details(int id) { 
            
            return View(_context.Planets.FirstOrDefault(x => x.Id == id));
        }
    }
}