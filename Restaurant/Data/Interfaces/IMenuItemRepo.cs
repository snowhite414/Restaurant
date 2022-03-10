using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data.Interfaces
{
    public interface IMenuItemRepo
    {
        IEnumerable<MenuItem> GetAll();
        MenuItem GetById(int id);
        void Create(MenuItem input);
        void Update(int id, MenuItem input);
        void Delete(int id);
    }
}
