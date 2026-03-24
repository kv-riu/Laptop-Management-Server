using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaptopStores.Application.AddLaptopUseCase;
using LaptopStores.API.Controllers.Abstractions;

namespace LaptopStores.API.Controllers
{
    [ApiController]
    [Route("api/store")] // api/store/...
    public class AddLaptopController : BaseController
    {
        public readonly IAddLaptop _addLaptop;
        public AddLaptopController(IAddLaptop addLaptop)
        {
            _addLaptop = addLaptop;
        }

        [HttpPost("{storeId}/laptop/{laptopId}")] // POST api/store/{storeId}/laptop/{laptopId})
        public async Task<IActionResult> AddLaptopToStore([FromRoute] Guid storeId, [FromRoute] Guid laptopId)
        // Route binding: {storeId} and {laptopId} will be extracted from the URL and passed as parameters to the method
        {
            var result = await _addLaptop.AddLaptopAsync(storeId, laptopId);
            return HandleResult(result);
        }
    }
}
