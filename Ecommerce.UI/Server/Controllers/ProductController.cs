using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;  
        }

        [HttpGet("GetProductsFromHell")]
        public async Task<string> GetProductsFromHell()
        {
            return await _productService.GetProductFrom();
        }
    }
}
