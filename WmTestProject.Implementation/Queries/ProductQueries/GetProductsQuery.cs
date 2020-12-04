using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Product;
using WmTestProject.Application.Searches;
using WmTestProject.Application.Searches.Product;
using WmTestProject.DataAccess;
using WmTestProject.Domain.Entities;
using WmTestProject.Implementation.Utilities;

namespace WmTestProject.Implementation.Queries.ProductQueries
{
    public class GetProductsQuery : IGetProductsQuery
    {
        private readonly WmTestContext _context;
        private readonly IMapper _mapper;
        public GetProductsQuery(
            WmTestContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string Name => typeof(GetProductsQuery).Name;

        public IReadOnlyList<ProductDto> Execute(ProductSearchParams search)
        {
            var query = _context.Products.AsQueryable();

            if (!search.Name.IsTotalyEmpty())
            {
                query = query.Where(p => p.Name.Contains(search.Name));
            }

            if (search.Order != null)
            {
                query = search.Order == SortOrder.Ascending ?
                    query.OrderBy(x => x.Name) :
                    query.OrderByDescending(x => x.Name);
            }

            query = query.Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier);

            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(query.ToList());
        }
    }
}
