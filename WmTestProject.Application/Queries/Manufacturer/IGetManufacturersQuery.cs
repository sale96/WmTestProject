using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.Application.Queries.Manufacturer
{
    public interface IGetManufacturersQuery : IQuery<string, IReadOnlyList<ManufacturerDto>>
    {
    }
}
