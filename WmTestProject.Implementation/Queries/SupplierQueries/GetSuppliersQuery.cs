using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Supplier;
using WmTestProject.DataAccess;
using WmTestProject.Implementation.Utilities;

namespace WmTestProject.Implementation.Queries.SupplierQueries
{
    public class GetSuppliersQuery : IGetSuppliersQuery
    {
        private readonly WmTestContext _context;

        public GetSuppliersQuery(WmTestContext context)
        {
            _context = context;
        }

        public string Name => typeof(GetSuppliersQuery).Name;

        public IReadOnlyList<SupplierDto> Execute(string search)
        {
            var query = _context.Suppliers.AsQueryable();

            if (!search.IsTotalyEmpty())
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            return query.Select(x => new SupplierDto { Name = x.Name }).ToList();
        }
    }
}
