using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.DataAccess.JsonContext.Interfaces.Implementations
{
    public interface IJsonProductContext : IJsonContextRead<IEnumerable<ProductDto>>, IJsonContextWrite<ProductDto>
    {
    }
}
