using Product.Core.Entities;
using Product.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Product.Core.Repositories
{
    public interface IProductRepository:IRepository<ProductEntity>
    {
        Task<ProductEntity> CheckByIDAsync(int id);
    }
}
