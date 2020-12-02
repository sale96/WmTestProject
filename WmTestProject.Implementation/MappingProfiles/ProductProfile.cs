using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Domain.Entities;

namespace WmTestProject.Implementation.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Category, p => p.MapFrom(x => x.Category.Name))
                .ForMember(dto => dto.Manufacturer, p => p.MapFrom(x => x.Manufacturer.Name))
                .ForMember(dto => dto.Supplier, p => p.MapFrom(x => x.Supplier.Name));
        }
    }
}
