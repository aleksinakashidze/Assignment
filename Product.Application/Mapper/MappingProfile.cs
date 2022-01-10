using AutoMapper;
using Product.Application.DTO;
using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, ProductDTO>().ReverseMap();
            CreateMap<MarketEntity, MarketDTO>().ReverseMap();
            CreateMap<PriceEntity, PriceDTO>().ReverseMap();
            CreateMap<PriceEntity, PriceResponse>().ReverseMap();

        }
    }
}
