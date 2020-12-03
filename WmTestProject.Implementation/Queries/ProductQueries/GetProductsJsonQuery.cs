using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Product;
using WmTestProject.Application.Searches;
using WmTestProject.Application.Searches.Product;
using WmTestProject.DataAccess;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.Implementation.Queries.ProductQueries
{
    public class GetProductsJsonQuery : IGetProductsJsonQuery
    {
        private readonly IJsonProductContext _context;

        public GetProductsJsonQuery(IJsonProductContext context)
        {
            _context = context;
        }

        public string Name => typeof(GetProductsQuery).Name;

        public IReadOnlyList<ProductDto> Execute(ProductSearchParams search)
        {
            var data = _context.Read();

            if (!(string.IsNullOrEmpty(search.Name) || string.IsNullOrWhiteSpace(search.Name)))
            {
                data = data.Where(p => p.Name.Contains(search.Name));
            }

            if (search.Order != null)
            {
                data = search.Order == SortOrder.Ascending ?
                    data.OrderBy(x => x.Name) :
                    data.OrderByDescending(x => x.Name);
            }

            return data.ToList();
        }
    }
}
