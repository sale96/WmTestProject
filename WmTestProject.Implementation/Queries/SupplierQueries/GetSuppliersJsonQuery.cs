using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Supplier;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.Implementation.Queries.SupplierQueries
{
    public class GetSuppliersJsonQuery : IGetSuppliersQuery
    {
        private readonly IJsonSupplierContext _context;

        public GetSuppliersJsonQuery(IJsonSupplierContext context)
        {
            _context = context;
        }

        public string Name => typeof(GetSuppliersJsonQuery).Name;

        public IReadOnlyList<SupplierDto> Execute(string search)
        {
            return _context.Read().ToList();
        }
    }
}
