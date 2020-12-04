using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess;
using WmTestProject.Domain.Entities;

namespace WmTestProject.Implementation.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile(WmTestContext context)
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Category, p => p.MapFrom(x => x.Category.Name))
                .ForMember(dto => dto.Manufacturer, p => p.MapFrom(x => x.Manufacturer.Name))
                .ForMember(dto => dto.Supplier, p => p.MapFrom(x => x.Supplier.Name));

            CreateMap<ProductDto, Product>()
                .ForMember(p => p.CategoryId, dto => dto.MapFrom(
                    x => context.Categories.FirstOrDefault(m => m.Name == x.Category).Id))
                .ForMember(p => p.ManufacturerId, dto => dto.MapFrom(
                    x => context.Manufacturers.FirstOrDefault(m => m.Name == x.Manufacturer).Id))
                .ForMember(p => p.SupplierId, dto => dto.MapFrom(
                    x => context.Suppliers.FirstOrDefault(m => m.Name == x.Supplier).Id));
        }
    }
}
