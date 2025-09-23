using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Request.ProductColor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductColorsController : Controller
    {
        protected readonly IProductColorService _productColorService;

        public ProductColorsController(IProductColorService productColorService)
        {
            _productColorService = productColorService;
        }

        [HttpPost("AddProductColor")]
        public async Task<IActionResult> AddProductColor(CreateProductColorRequest request)
        {
            var result = await _productColorService.Add(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateProductColor")]
        public async Task<IActionResult> UpdateProductColor(UpdateProductColorRequest request)
        {
            var result = await _productColorService.Update(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("DeleteProductColor")]
        public async Task<IActionResult> DeleteProductColor(DeleteProductColorRequest request)
        {
            var result = await _productColorService.Delete(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
