using LaptopStores.API.Controllers.Abstractions;
using LaptopStores.Application.LaptopUseCase;
using LaptopStores.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LaptopStores.API.Controllers
{
    [ApiController]
    [Route("api/laptop")] // If use [controller], it will remove "Controller" from the name,
                         // convert to lowercase, so it will be "api/laptopstorecrud"
    public class LaptopCRUDController : BaseController
    {
        private readonly ILaptopCRUD _laptopCRUD;
        public LaptopCRUDController(ILaptopCRUD laptopCRUD)
        {
            _laptopCRUD = laptopCRUD;
        }

        [HttpGet] // GET api/laptop
        public async Task<IActionResult> GetAllLaptops()
        {
            var result = await _laptopCRUD.GetAllLaptopsAsync();
            return HandleResult(result);
        }

        [HttpGet("{id}")] // GET api/laptop/{id}
        public async Task<IActionResult> GetLaptopById([FromRoute] Guid id)
        {
            var result = await _laptopCRUD.GetLaptopByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost] // POST api/laptop
        public async Task<IActionResult> CreateLaptop([FromBody] LaptopDto createDto)
        {
            var result = await _laptopCRUD.CreateLaptopAsync(createDto);
            return HandleResult(result);
        }

        [HttpPut("{id}")] // PUT api/laptop/{id}
        public async Task<IActionResult> UpdateLaptopStore([FromRoute] Guid id, [FromBody] LaptopDto dto)
        {
            var updateDto = new UpdateLaptopDto(
                id,
                dto.Brand,
                dto.Model,
                dto.RAM,
                dto.Storage,
                dto.KeyboardBacklight,
                dto.Price
                );
            var result = await _laptopCRUD.UpdateLaptopAsync(updateDto);
            return HandleResult(result);
        }

        [HttpDelete("{id}")] // DELETE api/laptop/{id}
        public async Task<IActionResult> DeleteLaptopStore([FromRoute] Guid id)
        {
            var result = await _laptopCRUD.DeleteLaptopAsync(id);
            return HandleResult(result);
        }
    }
}
