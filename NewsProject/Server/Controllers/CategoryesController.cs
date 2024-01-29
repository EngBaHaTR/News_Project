using Microsoft.AspNetCore.Mvc;
using NewsProject.Server.Repository.Main;
using NewsProject.Server.Repository.Services;
using NewsProject.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CateProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryesController : ControllerBase
    {
        private readonly CategoriesServices services;
        public CategoryesController(CategoriesServices _services) { services = _services; }

        // GET: api/<CategoryesController>
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var respons = await services.GetAll();
            if (respons == null)
                return Ok("thi table is empty!!");
            return Ok(respons);
        }

        // GET api/<CategoryesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var respons = await services.GetbyId(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            return Ok(respons);
        }

        // POST api/<CategoryesController>
        [HttpPost]
        public async Task<IActionResult> AddRowe([FromBody] Category value)
        {
           if (ModelState.IsValid)
            {
                return Ok(value);
            }
            var respons = await services.AddRowe(value);
            if (respons == null)
                return BadRequest("something is wrong");
            return Ok("this Item wase Added!!");
        }

        // PUT api/<CategoryesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateItem(int id, [FromBody] Category value)
        {
            var respons = await services.GetbyId(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            await services.Update(id, value);
            return Ok(respons);
        }

        // DELETE api/<CategoryesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRow(int id)
        {
            var respons = await services.GetbyId(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            await services.Delete(id);
            return Ok("This Item wase deleted!!");
        }
    }
}
