using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sample.BLL.Interfaces;
using Sample.Common.Infrastructure.Models.ViewModels;

namespace Shopping_Sample.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves the list of all products.
        /// </summary>
        /// <returns>The view displaying the list of products.</returns>
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        /// <summary>
        /// Adds a new product or updates an existing product.
        /// </summary>
        /// <param name="products">The details of the product to be created or updated.</param>
        /// <returns>The view indicating success or failure of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductsViewModel products)
        {
            var isProductUpsert = false;
            if (products.Id > 0)
            {
                isProductUpsert = await _productService.UpdateProduct(products);
            }
            else
            {
                isProductUpsert = await _productService.CreateProduct(products);
            }

            if (!isProductUpsert)
            {
                return View(isProductUpsert);
            }
            else
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
        }

        /// <summary>
        /// Retrieves the view to edit a product based on its ID.
        /// </summary>
        /// <param name="id">The ID of the product to be edited.</param>
        /// <returns>The view to edit the product.</returns>
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product != null)
            {
                return RedirectToAction("GetAllProducts", "Product");
            }

            return View();
        }

        /// <summary>
        /// Deletes a product based on its ID.
        /// </summary>
        /// <param name="id">The ID of the product to be deleted.</param>
        /// <returns>Redirects to the list of all products.</returns>
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productService.DeleteProduct(id);
            if (isDeleted)
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
            return RedirectToAction("GetAllProducts", "Product");
        }
    }

}
