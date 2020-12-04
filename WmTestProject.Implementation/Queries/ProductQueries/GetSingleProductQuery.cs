using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Product;
using WmTestProject.DataAccess;
using WmTestProject.Domain.Entities;

namespace WmTestProject.Implementation.Queries.ProductQueries
{
    public class GetSingleProductQuery : IGetSingleProductQuery
    {
        private readonly WmTestContext _context;
        private readonly IMapper _mapper;

        public GetSingleProductQuery(WmTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string Name => typeof(GetSingleProductQuery).Name;

        public ProductDto Execute(int search)
        {
            return _mapper.Map<Product, ProductDto>(_context.Products.FirstOrDefault(x => x.Id == search));
        }
    }
}
