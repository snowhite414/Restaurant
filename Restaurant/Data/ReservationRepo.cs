using Restaurant.Data.Interfaces;
using Restaurant.Models;
using Restaurant.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper mapper = new Mapper();

        public ReservationRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(ReservationCreateDto input)
        {
            Reservation reservationToAdd = mapper.Map(input);
            _context.Reservations.Add(reservationToAdd);
            _context.SaveChanges();

            foreach(int id in input.MenuItems)
            {
                var rm = new ReservationMenuItems
                {
                    ReservationId = reservationToAdd.Id,
                    MenuItemId = id
                };
                _context.ReservationMenuItems.Add(rm);
            }
            _context.SaveChanges(); 
        }

        public ReservationReadDto GetById(int id)
        {
            var reservation = _context.Reservations.Where(r => r.Id == id)
                .Select(r => new ReservationReadDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Date = r.Date,

                    MenuItems = _context.ReservationMenuItems.Where(rm => rm.ReservationId == r.Id)
                    .Select(c => new MenuItemReadDto
                    {
                        Id = c.MenuItem.Id,
                        Name = c.MenuItem.Name,
                        Price = c.MenuItem.Price
                    }).ToList()
                }).FirstOrDefault();

            return reservation;
        }

        public void Update(int id, ReservationCreateDto input)
        {

            var reservationDb = _context.Reservations.FirstOrDefault(r => r.Id == id);
            var menuItems = _context.ReservationMenuItems.Where(m => m.ReservationId == id).ToList();

            if (reservationDb != null)        // uncomment the name if wants to edit name and date
            {
                //reservationDb.Name = input.Name;  
                //reservationDb.Date = input.Date;
                _context.RemoveRange(menuItems);
                _context.SaveChanges();
            }
 
            foreach (int menuId in input.MenuItems)
            {
                var rm = new ReservationMenuItems
                {
                    ReservationId = id,
                    MenuItemId = menuId
                };
                _context.ReservationMenuItems.Add(rm);
            }
            _context.SaveChanges();
        }
 
        public IEnumerable<ReservationReadDto> GetAll()
        {
            var reservations = _context.Reservations.Select(r => mapper.Map(r, true)).ToList();
            var menuItems = _context.MenuItems.Select(m => mapper.Map(m, true)).ToList();
            var reservationMenuItems = _context.ReservationMenuItems.ToList();

            foreach (var reservation in reservations)
            {
                List<MenuItemReadDto> menusToAdd = new List<MenuItemReadDto>();

                foreach (var rm in reservationMenuItems)
                {
                    if(rm.ReservationId == reservation.Id)
                    {
                        var menu = menuItems.FirstOrDefault(m => m.Id == rm.MenuItemId);
                        if (menu != null)
                        {
                            menusToAdd.Add(menu);
                        }
                    }
                }
                reservation.MenuItems = menusToAdd;
            }
            return reservations;
        }

        public void Delete(int id)
        {
            var reservationDb = _context.Reservations.FirstOrDefault(r => r.Id == id);
            var menuItems = _context.ReservationMenuItems.FirstOrDefault(rm => rm.ReservationId == id);

            if (reservationDb != null)
            {
                _context.Remove(reservationDb);
                _context.Remove(menuItems);
                _context.SaveChanges();
            }
        }
    }
}
