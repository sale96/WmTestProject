using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Categories;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.Implementation.Queries.CategoryQueries
{
    public class GetCategoriesJsonQuery : IGetCategoriesQuery
    {
        private readonly IJsonCategoryContext _categoryContext;

        public GetCategoriesJsonQuery(IJsonCategoryContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public string Name => typeof(GetCategoriesJsonQuery).Name;

        public IReadOnlyList<CategoryDto> Execute(string search)
        {
            return _categoryContext.Read().ToList();
        }
    }
}
