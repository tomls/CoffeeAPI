using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CoffeeApi.Models;

namespace CoffeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public CoffeeController(CoffeeContext context)
        {
            _context = context;

            if (_context.CoffeeItems.Count() == 0)
            {
                _context.CoffeeItems.Add(new CoffeeItem { 
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/52/Coffee_font_awesome.svg", 
                    Name = "Espresso", 
                    Price = 1.25 
                });
                _context.CoffeeItems.Add(new CoffeeItem { 
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/52/Coffee_font_awesome.svg", 
                    Name = "Double Espresso", 
                    Price = 2.25 
                });
                _context.CoffeeItems.Add(new CoffeeItem { 
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/52/Coffee_font_awesome.svg", 
                    Name = "Macchiato", 
                    Price = 3.25 });
                _context.CoffeeItems.Add(new CoffeeItem { 
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/52/Coffee_font_awesome.svg", 
                    Name = "Americano", 
                    Price = 3.50 });
                _context.CoffeeItems.Add(new CoffeeItem { 
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/52/Coffee_font_awesome.svg", 
                    Name = "Café Latte", 
                    Price = 2.50 });
                _context.CoffeeItems.Add(new CoffeeItem { 
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/52/Coffee_font_awesome.svg", 
                    Name = "Cappuccino", 
                    Price = 4.25 });
                _context.SaveChanges();
            }
        }

        #region GetAll
        [HttpGet]
        public ActionResult<List<CoffeeItem>> GetAll()
        {
            return _context.CoffeeItems.ToList();
        }
        #endregion

        #region GetByID
        [HttpGet("{id}", Name = "GetCoffee")]
        public ActionResult<CoffeeItem> GetById(long id)
        {
            var item = _context.CoffeeItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        #endregion

        #region Create
        [HttpPost]
        public IActionResult Create(CoffeeItem item)
        {
            _context.CoffeeItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCoffee", new { id = item.Id }, item);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, CoffeeItem item)
        {
            var coffee = _context.CoffeeItems.Find(id);
            if (coffee == null)
            {
                return NotFound();
            }

            coffee.ImageURL = item.ImageURL;
            coffee.Name = item.Name;
            coffee.Price = item.Price;
            
            _context.CoffeeItems.Update(coffee);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var coffee = _context.CoffeeItems.Find(id);
            if (coffee == null)
            {
                return NotFound();
            }

            _context.CoffeeItems.Remove(coffee);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}