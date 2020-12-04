using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.Application.Queries.Supplier
{
    public interface IGetSuppliersQuery : IQuery<string, IReadOnlyList<SupplierDto>>
    {
    }
}
