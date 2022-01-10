using System.ComponentModel.DataAnnotations;

namespace Product.Core.Entities
{
    public class PriceEntity
    {
        [Key]
        public int PriceID { get; set; }
        public int ProductID { get; set; }
        public int MarketID { get; set; }
       
        public double Price { get; set; }
    }
}
