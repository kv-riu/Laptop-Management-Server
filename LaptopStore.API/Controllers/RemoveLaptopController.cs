using LaptopStores.Application.RemoveLaptopUseCase;
using LaptopStores.API.Controllers.Abstractions;

using Microsoft.AspNetCore.Mvc;

namespace LaptopStores.API.Controllers
{
    public class RemoveLaptopController : BaseController
    {
        public readonly IRemoveLaptop _removeLaptop;
        public RemoveLaptopController(IRemoveLaptop removeLaptop)
        {
            _removeLaptop = removeLaptop;
        }

        [HttpPost("{storeId}/laptop/{laptopId}")] // DEELETE api/store/{storeId}/laptop/{laptopId}
        public async Task<IActionResult> AddLaptopToStore([FromRoute] Guid storeId, [FromRoute] Guid laptopId)
        // Route binding: {storeId} and {laptopId} will be extracted from the URL and passed as parameters to the method
        {
            var result = await _removeLaptop.RemoveLaptopAsync(storeId, laptopId);
            return HandleResult(result);
        }
    }
}
