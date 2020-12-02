using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Searches.Product;

namespace WmTestProject.Application.Queries.Product
{
    public interface IGetProductsQuery : IQuery<ProductSearchParams, IReadOnlyList<ProductDto>>
    {
    }
}
