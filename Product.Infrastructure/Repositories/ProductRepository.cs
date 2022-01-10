using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Repositories;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository: Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ProductContext DbContext ):base(DbContext)
        {
        }

        public async Task<ProductEntity> CheckByIDAsync(int id)
        {
            return await Where(x => x.ProductID == id).FirstOrDefaultAsync();
        }

    }
}
