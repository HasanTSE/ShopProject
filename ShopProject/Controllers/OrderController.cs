using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ShopProject.Controllers
{
    public class OrderController : Controller
    {

       
         
        private readonly dbContext _db;

        
        public OrderController(dbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {

            var orderList = _db.orders.Include(o => o.Customer)
               .Include(o => o.Item)
               .Include(o => o.Unit);
                return View(await orderList.ToListAsync());
            //return View(orderList);

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderObj = _db.orders.FirstOrDefault(x => x.Id == id);


            if (orderObj == null)
            {
                return NotFound();
            }
            return View(orderObj);

        }

        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_db.customers, "Id", "CustomerName");
            ViewData["ItemId"] = new SelectList(_db.items, "Id", "ItemName");
            ViewData["UnitId"] = new SelectList(_db.Units, "Id", "UnitName");
             
                Order order = new Order();
                order.OrderDate = DateTime.Now;
            
 
                int count = _db.orders.Count();
                count = count + 1;
              
                order.OrderNumber = "Inv-"+DateTime.Now.Year+"-"+count;
                
            
            return View(order);

            


        }

        [HttpPost]
    //[ValidateAntiForgeryToken]

        public IActionResult Create(Order order)
        {
            //if (dataPass != null && ModelState.IsValid)
            if (ModelState.IsValid)
            {
                _db.Add(order);
                _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_db.customers, "Id", "CustomerName", order.CustomerId);
            ViewData["ItemId"] = new SelectList(_db.items, "Id", "ItemName", order.ItemId);
            ViewData["UnitId"] = new SelectList(_db.Units, "Id", "UnitName", order.UnitId);

            return View(order);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var orderObj = _db.orders.FirstOrDefault(x => x.Id == id);
            if (orderObj == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_db.customers, "Id", "CustomerName");
            ViewData["ItemId"] = new SelectList(_db.items, "Id", "ItemName");
            ViewData["UnitId"] = new SelectList(_db.Units, "Id", "UnitName");


            return View(orderObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult Edit(Order orderObj)
        {
            if (orderObj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(orderObj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_db.customers, "Id", "CustomerName");
            ViewData["ItemId"] = new SelectList(_db.items, "Id", "ItemName");
            ViewData["UnitId"] = new SelectList(_db.Units, "Id", "UnitName");


            return View(orderObj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderObj = _db.orders.FirstOrDefault(x => x.Id == id);
            _db.orders.Remove(orderObj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }




        private bool OrderExists(int id)
        {
            return _db.orders.Any(e => e.Id == id);
        }

        public IActionResult GetItemById(int itemId)
        {
            Item item = _db.items.FirstOrDefault(x => x.Id == itemId);

            if (item != null)
            {
                var vData = new
                {
                    item.ItemName,
                    item.SellPrice
                };
                return Json(vData);
            }
            return Json(string.Empty);
        }


    }
}