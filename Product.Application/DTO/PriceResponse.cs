using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTO
{
    public class PriceResponse
    {
        public int PriceID { get; set; }
        public string  ProductName { get; set; }
        public string MarketName { get; set; }
        public Double Price { get; set; }
    }
}
