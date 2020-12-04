using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Categories;
using WmTestProject.DataAccess;
using WmTestProject.Implementation.Utilities;

namespace WmTestProject.Implementation.Queries.CategoryQueries
{
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly WmTestContext _context;

        public GetCategoriesQuery(WmTestContext context)
        {
            _context = context;
        }

        public string Name => typeof(GetCategoriesQuery).Name;

        public IReadOnlyList<CategoryDto> Execute(string search)
        {
            var query = _context.Categories.AsQueryable();

            if (!search.IsTotalyEmpty())
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            return query.Select(x => new CategoryDto { Name = x.Name }).ToList();
        }
    }
}
