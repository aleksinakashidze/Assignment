using System.ComponentModel.DataAnnotations;

namespace Product.Core.Entities
{
    public class MarketEntity
    {
        [Key]
        public int MarketID { get; set; }
        public string MarketName { get; set; }
    }
}
