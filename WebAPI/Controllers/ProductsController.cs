using System;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Request.Product;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(CreateProductRequest request)
        {
            var result = await _productService.Add(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductColor([FromBody] UpdateProductRequest request)
        {
            var result = await _productService.Update(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProductColor(DeleteProductRequest request)
        {
            var result = await _productService.Delete(request);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        //[Obsolete("DevExpress Import'u olmadigindan deaktif")]
        [HttpGet("GetAllProductsForDx")]
        public async Task<IActionResult> GetAllProductsForDx(DataSourceLoadOptions loadOptions)
        {
            var result = await _productService.GetAllProductsForDx();
            return Ok(await DataSourceLoader.LoadAsync(result.Data, loadOptions));
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();

            if (result.IsSuccess)
                return Ok(result);
            
            return BadRequest(result);

        }


    }
}
