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

namespace WmTestProject.Implementation.Queries.Product
{
    public class GetProductsQuery : IGetProductsQuery
    {
        private readonly WmTestContext _context;
        public GetProductsQuery(WmTestContext context)
        {
            _context = context;
        }

        public string Name => typeof(GetProductsQuery).Name;

        public IReadOnlyList<ProductDto> Execute(ProductSearchParams search)
        {
            //TODO: Use automapper
            var query = _context.Products.AsQueryable();

            if (!(string.IsNullOrEmpty(search.Name) || string.IsNullOrWhiteSpace(search.Name)))
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

            return query.Select(x => new ProductDto
            {
                Id= x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Category = x.Category.Name,
                Manufacturer = x.Manufacturer.Name,
                Supplier = x.Supplier.Name
            }).ToList();
        }
    }
}
