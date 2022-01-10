using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;

namespace Product.Infrastructure.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) 
            : base(options) { }
        public virtual DbSet<ProductEntity> CopmanyEntities { get; set; }
        public virtual DbSet<MarketEntity> MarketEntities { get; set; }
        public virtual DbSet<PriceEntity> PraceEntities { get; set; }
    }
}
