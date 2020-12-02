using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.Application.Queries.Product
{
    public interface IGetProductsQuery : IQuery<string, ProductDto>
    {
    }
}
