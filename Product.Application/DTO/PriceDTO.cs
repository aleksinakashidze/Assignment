using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTO
{
    public class PriceDTO
    {
        public int PriceID  { get; set; }
        public int ProductID { get; set; }
        public int MarketID { get; set; }
        public double Price { get; set; }
    }

}
