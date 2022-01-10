using Product.Core.Entities;
using Product.Core.Repositories;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repositories.Base;

namespace Product.Infrastructure.Repositories
{
    public class MarketRepository : Repository<MarketEntity>, IMarketRepository
    {
        public MarketRepository(ProductContext dbContext) : base(dbContext)
        {
        }
    }
}
