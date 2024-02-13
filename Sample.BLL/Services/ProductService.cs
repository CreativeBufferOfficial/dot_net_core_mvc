using AutoMapper;
using Sample.BLL.Interfaces;
using Sample.Common.Infrastructure.Models.Entities;
using Sample.Common.Infrastructure.Models.ViewModels;
using Sample.DAL.Interfaces;

namespace Sample.BLL.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;
        public IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        public async Task<bool> CreateProduct(ProductsViewModel productDetails)
        {
            var product = new Products
            {
                ProductName = productDetails.ProductName,
                ProductDescription = productDetails.ProductDescription,
                ProductStock = productDetails.ProductStock,
                ProductPrice = productDetails.ProductPrice
            };

            if (productDetails != null)
            {

                await _unitOfWork.ProductDetails.Add(product);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.ProductDetails.GetById(productId);
                if (productDetails != null)
                {
                    _unitOfWork.ProductDetails.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var products = await _unitOfWork.ProductDetails.GetAll();
            return products;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Products> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.ProductDetails.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        public async Task<bool> UpdateProduct(ProductsViewModel productDetails)
        {
            if (productDetails != null)
            {
                var product = await _unitOfWork.ProductDetails.GetById(productDetails.Id);
                if (product != null)
                {
                    product.ProductName = productDetails.ProductName;
                    product.ProductDescription = productDetails.ProductDescription;
                    product.ProductPrice = productDetails.ProductPrice;
                    product.ProductStock = productDetails.ProductStock;

                    _unitOfWork.ProductDetails.Update(product);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
