using Sample.Common.Infrastructure.Models.Entities;
using Sample.DAL.DBContext;
using Sample.DAL.Interfaces;

namespace Sample.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

    }
}
