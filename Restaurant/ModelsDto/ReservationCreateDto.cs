using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ModelsDto
{
    public class ReservationCreateDto
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<int> MenuItems { set; get; }
    }
}
