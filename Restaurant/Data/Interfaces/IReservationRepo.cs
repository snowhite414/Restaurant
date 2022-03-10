using Restaurant.Models;
using Restaurant.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data.Interfaces
{
    public interface IReservationRepo
    {
        IEnumerable<ReservationReadDto> GetAll();
        void Create(ReservationCreateDto input);
        ReservationReadDto GetById(int id);
        void Update(int id, ReservationCreateDto input);
        void Delete(int id);
       
    }
}
