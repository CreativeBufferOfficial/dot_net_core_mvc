using Sample.Common.Infrastructure.Models.Entities;
using Sample.Common.Infrastructure.Models.ViewModels;

namespace Sample.BLL.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Creates a new product based on the provided product details.
        /// </summary>
        /// <param name="productDetails">The details of the product to be created.</param>
        /// <returns></returns>
        Task<bool> CreateProduct(ProductsViewModel productDetails);

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Products>> GetAllProducts();

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <returns></returns>
        Task<Products> GetProductById(int productId);

        /// <summary>
        /// Updates an existing product based on the provided product details.
        /// </summary>
        /// <param name="productDetails">The updated details of the product.</param>
        /// <returns></returns>
        Task<bool> UpdateProduct(ProductsViewModel productDetails);

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to be deleted.</param>
        /// <returns></returns>
        Task<bool> DeleteProduct(int productId);
    }

}
