using LaptopStores.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStores.API.Controllers.Abstractions
{
    public abstract class BaseController : ControllerBase
    {
        //Response base on Result
        protected IActionResult HandleResult(Result result)
        {
            if(result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Message);
        }
    }
}
