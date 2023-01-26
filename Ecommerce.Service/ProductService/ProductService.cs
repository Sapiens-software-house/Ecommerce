using Ecommerce.Interface.IProductService;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.ServiceResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            var dbProductToCheck = new Product();
            var dbProduct = await _unitOfWork.ProductRepository.FindAsync(x=> x.id == productId.ToString());

            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found."
                };
            }
            else
            {
                dbProductToCheck = dbProduct.FirstOrDefault();
            }

            _unitOfWork.ProductRepository.UpdateAsync(productId, x => { x.Deleted = true; });

            await _unitOfWork.SaveAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();

            var response = new ServiceResponse<List<Product>>
            {
                Data = products.ToList()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                //product = await _context.Products
                //    .Include(p => p.Variants.Where(v => !v.Deleted))
                //    .ThenInclude(v => v.ProductType)
                //    .Include(p => p.Images)
                //    .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted);
            }
            else
            {
                var repoToCheck = new Product();
                var repo = await _unitOfWork.ProductRepository
                    .FindAsync(p => p.id == productId.ToString() && !p.Deleted && p.Visible);

                if (repo != null)
                {
                    repoToCheck = repo.FirstOrDefault();
                }

                product = repoToCheck;
            }

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
            var products = await _unitOfWork.ProductRepository
                                .GetAllAsyncPaged(p => p.name.ToLower().Contains(searchText.ToLower())
                                    &&
                                    p.Visible && !p.Deleted, page);

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products.ToList(),
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            var find = await _unitOfWork.ProductRepository
                                .GetAllAsync(p => p.name.ToLower().Contains(searchText.ToLower()) &&
                                    p.Visible && !p.Deleted);

            return (List<Product>)find;
        }
    }
}
