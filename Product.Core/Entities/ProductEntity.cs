using System.ComponentModel.DataAnnotations;

namespace Product.Core.Entities
{
    public class ProductEntity
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
