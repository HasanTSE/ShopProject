using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ShopProject.Controllers
{
    public class ItemController : Controller
    {
        private readonly dbContext _db;

        public ItemController(dbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var itemList = _db.items.ToList();
            return View(itemList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var itemObj = _db.items.FirstOrDefault(x => x.Id == id);


            if (itemObj == null)
            {
                return NotFound();
            }
            return View(itemObj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Item dataPass)
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
            var itemObj = _db.items.FirstOrDefault(x => x.Id == id);
            if (itemObj == null)
            {
                return NotFound();
            }

            return View(itemObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Item itemObj)
        {
            if (itemObj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(itemObj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(itemObj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var itemObj = _db.items.FirstOrDefault(x => x.Id == id);
            _db.items.Remove(itemObj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
