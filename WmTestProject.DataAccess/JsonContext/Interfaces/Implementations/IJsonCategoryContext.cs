using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.DataAccess.JsonContext.Interfaces.Implementations
{
    public interface IJsonCategoryContext : IJsonContextRead<IEnumerable<CategoryDto>>, IJsonContextWrite<CategoryDto>
    {
    }
}
