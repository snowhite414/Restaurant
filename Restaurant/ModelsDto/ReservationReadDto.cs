using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ModelsDto
{
    public class ReservationReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<MenuItemReadDto> MenuItems { set; get; }
         
    }
}
