using Ecommerce.Interface.IProductService;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.ServiceResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();
            return new ServiceResponse<Product> { Data = product };
        }
    }
}
