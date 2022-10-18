using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ShopProject.Controllers
{
    public class UnitController : Controller
    {

        private readonly dbContext _db;

        public UnitController(dbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var unitList = _db.Units.ToList();
            return View(unitList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var unitObj = _db.Units.FirstOrDefault(x => x.Id == id);


            if (unitObj == null)
            {
                return NotFound();
            }
            return View(unitObj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Unit dataPass)
        {
            if (dataPass != null && ModelState.IsValid)
            {
                _db.Add(dataPass);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(dataPass);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var unitObj = _db.Units.FirstOrDefault(x => x.Id == id);
            if (unitObj == null)
            {
                return NotFound();
            }

            return View(unitObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult Edit(Unit unitObj)
        {
            if (unitObj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(unitObj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(unitObj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var unitObj = _db.Units.FirstOrDefault(x => x.Id == id);
            _db.Units.Remove(unitObj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
