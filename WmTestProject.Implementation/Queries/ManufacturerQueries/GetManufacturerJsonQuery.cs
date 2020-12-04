using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Manufacturer;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.Implementation.Queries.ManufacturerQueries
{
    public class GetManufacturerJsonQuery : IGetManufacturersQuery
    {
        private readonly IJsonManufacturerContext _context;

        public GetManufacturerJsonQuery(IJsonManufacturerContext context)
        {
            _context = context;
        }

        public string Name => typeof(GetManufacturerJsonQuery).Name;

        public IReadOnlyList<ManufacturerDto> Execute(string search)
        {
            return _context.Read().ToList();
        }
    }
}
