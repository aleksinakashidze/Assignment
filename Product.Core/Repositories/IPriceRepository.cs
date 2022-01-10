using Product.Core.Entities;
using Product.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Core.Repositories
{
    public interface IPriceRepository:IRepository<PriceEntity>
    {
        Task<IEnumerable<PriceEntity>> GetByProductID(int id);
        Task<IEnumerable<PriceEntity>> GetByMarketID(int id);
        Task DeleteWithRangeAsyncs(IEnumerable<PriceEntity> priceEntities);
    }
}
