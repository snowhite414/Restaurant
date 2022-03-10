using Restaurant.Data.Interfaces;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public class MenuItemRepo : IMenuItemRepo
    {
        private readonly AppDbContext _context;

        public MenuItemRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(MenuItem input)
        {
            _context.MenuItems.Add(input);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var menuItemDb = _context.MenuItems.FirstOrDefault(m => m.Id == id);

            if (menuItemDb != null)
            {
                _context.Remove(menuItemDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MenuItem> GetAll()
        {
            return _context.MenuItems.ToList();
        }

        public MenuItem GetById(int id)
        {
            var menuItemDb = _context.MenuItems.FirstOrDefault(m => m.Id == id);
            return menuItemDb;
        }

        public void Update(int id, MenuItem input)
        {
            var menuItemDb = _context.MenuItems.FirstOrDefault(m => m.Id == id);

            if (menuItemDb != null)
            {
                menuItemDb.Name = input.Name;
                menuItemDb.Price = input.Price;
                _context.SaveChanges();
            }
            
        }
    }
}
