using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Data.Interfaces;
using Restaurant.Models;
using Restaurant.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo _reservationRepo;
        private readonly Mapper _mapper = new Mapper();

        public ReservationsController(IReservationRepo reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }
        // GET: api/<ReservationsController>
        [HttpGet]
        public ActionResult Get()
        { 
            return Ok(_reservationRepo.GetAll()); //200
            
        }

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _reservationRepo.GetById(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public ActionResult Post(ReservationCreateDto value)  // create
        {
            _reservationRepo.Create(value);
            return Ok();  
        }

        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ReservationCreateDto value)
        {
            if (_reservationRepo.GetById(id) == null)
            {
                return NotFound();
            }
            _reservationRepo.Update(id, value);
            return Ok();
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_reservationRepo.GetById(id) == null)
            {
                return NotFound();
            }
            _reservationRepo.Delete(id);
            return Ok();
        }
    }
}
