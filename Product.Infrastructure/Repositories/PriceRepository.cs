using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Repositories;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    public class PriceRepository : Repository<PriceEntity>, IPriceRepository
    {
        public PriceRepository(ProductContext dbContext) : base(dbContext)
        {
            
        }

        public async Task DeleteWithRangeAsyncs(IEnumerable<PriceEntity> priceEntities)
        {
            await DeleteWithRangeAsync(priceEntities);
        }
           

        public async Task<IEnumerable<PriceEntity>> GetByMarketID(int id)
        {
            return await Where(x => x.MarketID == id).ToListAsync();
        }

        public async Task<IEnumerable<PriceEntity>> GetByProductID(int id)
        {
            return await Where(x => x.ProductID == id).ToListAsync();
        }
    }
}
