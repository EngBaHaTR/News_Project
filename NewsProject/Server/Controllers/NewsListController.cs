using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsProject.Server.Repository.Services;
using NewsProject.Shared.Dto;
using NewsProject.Shared.Models;

namespace servicesProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsListController : ControllerBase
    {
        private readonly NewsListServices services;
        public NewsListController(NewsListServices _services) { services = _services; }

        // GET: api/<NewsListServices>
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var respons = await services.GetAll("Category");
            if (respons == null)
                return Ok("thi table is empty!!");
            return Ok(respons);
        }

        // GET: api/<NewsListServices>
        [HttpGet]
        public async Task<IActionResult> GetAllbyTitle(string Title)
        {
            var respons = await services.GetAllbyTitle(Title);
            if (respons == null)
                return Ok("thi table is empty!!");
            return Ok(respons);
        }

        // GET api/<servicesListsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var respons =await services.GetbyId(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            return Ok(respons);
        }
        // GET api/<servicesListsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyCategoryId(int id)
        {
            var respons = await services.GetbyCategory(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            return Ok(respons);
        }

        // POST api/<servicesListsController>
        [HttpPost]
        public async Task<IActionResult> AddRowe([FromForm] NewsListDto value)
        {
          var respons = await services.AddRowe(value);
           
            if (respons == null)
                return NotFound("something is wrong");
            return Ok("this Item wase Added!!");
        }

        // PUT api/<servicesListsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateItem(int id, [FromBody] NewsList value)
        {
            var respons = await services.GetbyId(id);
            if (respons == null)
                return NotFound("This Item Not Found!!");
            await services.Update(id, value);
            return Ok(respons);
        }

        // DELETE api/<servicesListsController>/5
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
