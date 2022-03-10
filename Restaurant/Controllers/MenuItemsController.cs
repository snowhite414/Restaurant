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
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemRepo _menuItemRepo;
        private readonly Mapper _mapper = new Mapper();

        public MenuItemsController(IMenuItemRepo menuItemRepo)
        {
            _menuItemRepo = menuItemRepo;
        }
        // GET: api/<MenuItemsController>
        [HttpGet]
        public ActionResult Get()
        {
            var menuItemtoPresent = _menuItemRepo.GetAll()
                .Select(m => _mapper.Map(m, true));
            return Ok(menuItemtoPresent); //200
        }

        // GET api/<MenuItemsController>/5  
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _menuItemRepo.GetById(id);

            if (result != null)
            {
                return Ok(_mapper.Map(result, true));
            }
            return NotFound();
        }

        // POST api/<MenuItemsController>
        [HttpPost]
        public ActionResult Post(MenuItemCreateDto value)  //create
        {
            _menuItemRepo.Create(_mapper.Map(value));
            return Ok();
        }

        // PUT api/<MenuItemsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, MenuItemCreateDto value)  // edit by id
        {
            var result = _menuItemRepo.GetById(id);
            if (result != null)
            {
                _menuItemRepo.Update(id, _mapper.Map(value));
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }

        // DELETE api/<MenuItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _menuItemRepo.GetById(id);
            if(result != null)
            {
                _menuItemRepo.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
           
        }
    }
}
