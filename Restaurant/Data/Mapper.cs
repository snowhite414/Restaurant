using Restaurant.Models;
using Restaurant.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public class Mapper
    {
        public MenuItemCreateDto Map(MenuItem input)
        {
            return new MenuItemCreateDto
            {
                Name = input.Name, Price = input.Price
            };
        }
        public MenuItem Map(MenuItemCreateDto input)
        {
            return new MenuItem
            {
                Name = input.Name,
                Price = input.Price
            };
        }

        public MenuItemReadDto Map(MenuItem input, bool flag)
        {
            return new MenuItemReadDto
            {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }
        public Reservation Map(ReservationCreateDto input)
        {
            return new Reservation
            {
                Name = input.Name,
                Date = input.Date
            };
        }
        public ReservationReadDto Map(Reservation input, bool v)
        {
            return new ReservationReadDto
            {
                Id = input.Id,
                Name = input.Name,
                Date = input.Date
            };
        }
    }
}
