using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Manufacturer;
using WmTestProject.DataAccess;
using WmTestProject.Implementation.Utilities;

namespace WmTestProject.Implementation.Queries.ManufacturerQueries
{
    public class GetManufacturersQuery : IGetManufacturersQuery
    {
        private readonly WmTestContext _context;

        public GetManufacturersQuery(WmTestContext context)
        {
            _context = context;
        }

        public string Name => typeof(GetManufacturersQuery).Name;

        public IReadOnlyList<ManufacturerDto> Execute(string search)
        {
            var query = _context.Manufacturers.AsQueryable();

            if (!search.IsTotalyEmpty())
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            return query.Select(x => new ManufacturerDto { Name = x.Name }).ToList();
        }
    }
}
