using Microsoft.EntityFrameworkCore;
using Sample.Common.Infrastructure.Models.Entities;

namespace Sample.DAL.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> contextOptions) : base(contextOptions)
        {

        }
        /// <summary>
        /// Gets or sets the DbSet for products, allowing interaction with the product details in the database.
        /// </summary>
        public DbSet<Products> ProductDetails { get; set; }
    }
}
