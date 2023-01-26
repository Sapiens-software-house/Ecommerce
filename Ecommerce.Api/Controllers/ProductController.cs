using Ecommerce.Interface.IProductService;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.ServiceResponse;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProductService _service;

        public ProductController(ILogger<WeatherForecastController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost(Name = "PostSigleProduct")]
        public async Task<ServiceResponse<Product>> Post(Product product)
        {
          return await _service.CreateProduct(product);
        }
    }
}