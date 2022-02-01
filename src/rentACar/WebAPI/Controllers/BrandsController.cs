using Application.Features.Brands.Commands.CreateBrand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand) 
        {
            var result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

    }
}
