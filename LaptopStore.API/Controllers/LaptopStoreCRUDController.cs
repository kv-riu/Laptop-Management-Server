using LaptopStores.API.Controllers.Abstractions;
using LaptopStores.Application.LaptopStoreUseCase;
using LaptopStores.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LaptopStores.API.Controllers
{
    [ApiController]
    [Route("api/store")] // If use [controller], it will remove "Controller" from the name,
                         // convert to lowercase, so it will be "api/laptopstorecrud"
    public class LaptopStoreCRUDController : BaseController
    {
        private readonly ILaptopStoreCRUD _laptopStoreCRUD;
        public LaptopStoreCRUDController(ILaptopStoreCRUD laptopStoreCRUD)
        {
            _laptopStoreCRUD = laptopStoreCRUD;
        }

        [HttpGet] // GET api/store
        public async Task<IActionResult> GetAllLaptopStores()
        {
            var result = await _laptopStoreCRUD.GetAllLaptopStoresAsync();
            return HandleResult(result);
        }

        [HttpGet("{id}")] // GET api/store/{id}
        public async Task<IActionResult> GetLaptopStoreById([FromRoute] Guid id)
        {
            var result = await _laptopStoreCRUD.GetLaptopStoreByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost] // POST api/store
        public async Task<IActionResult> CreateLaptopStore([FromBody] LaptopStoreDto createDto)
        {
            var result = await _laptopStoreCRUD.CreateLaptopStoreAsync(createDto);
            return HandleResult(result);
        }

        [HttpPut("{id}")] // PUT api/store/{id}
        public async Task<IActionResult> UpdateLaptopStore([FromRoute] Guid id, [FromBody] LaptopStoreDto dto)
        {
            var updateDto = new UpdateLaptopStoreDto(
                id,
                dto.Name,
                dto.Email,
                dto.PhoneNumber,
                dto.City,
                dto.Street,
                dto.Code
                );
            var result = await _laptopStoreCRUD.UpdateLaptopStoreAsync(updateDto);
            return HandleResult(result);
        }

        [HttpDelete("{id}")] // DELETE api/store/{id}
        public async Task<IActionResult> DeleteLaptopStore([FromRoute] Guid id)
        {
            var result = await _laptopStoreCRUD.DeleteLaptopStoreAsync(id);
            return HandleResult(result);
        }
    }
}
