using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

 

namespace ShopProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly dbContext _db;

        public CustomerController(dbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            var customerList = _db.customers.ToList();
            return View(customerList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var creta = _db.customers.FirstOrDefault(x => x.Id == id);


            if (creta == null)
            {
                return NotFound();
            }
            return View(creta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Customer dataPass)
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
            var creta = _db.customers.FirstOrDefault(x => x.Id == id);
            if (creta == null)
            {
                return NotFound();
            }

            return View(creta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Customer creta)
        {
            if (creta == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(creta);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(creta);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var creta = _db.customers.FirstOrDefault(x => x.Id == id);
            _db.customers.Remove(creta);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
