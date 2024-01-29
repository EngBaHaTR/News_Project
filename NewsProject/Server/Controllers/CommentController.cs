using Microsoft.AspNetCore.Mvc;
using NewsProject.Server.Repository.Main;
using NewsProject.Server.Repository.Services;
using NewsProject.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly MainInterface<Comment> services;
        public CommentController(MainInterface<Comment> _services) { services = _services; }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var respons = await services.GetAll("NewsList");
            if (respons == null)
                return Ok("thi table is empty!!");
            return Ok(respons);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var respons = await services.GetbyId(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            return Ok(respons);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> AddRowe([FromBody] Comment value)
        {
            await services.AddRowe(value);
            var respons = services.GetbyId(value.Id);
            if (respons == null)
                return NotFound("something is wrong");
            return Ok("this Item wase Added!!");
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateItem(int id, [FromBody] Comment value)
        {
            var respons = await services.GetbyId(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            await services.Update(id, value);
            return Ok(respons);
        }

        // DELETE api/<CommentController>/5
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
