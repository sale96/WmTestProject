using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.Application.Queries.Categories
{
    public interface IGetCategoriesQuery : IQuery<string, IReadOnlyList<CategoryDto>>
    {
    }
}
