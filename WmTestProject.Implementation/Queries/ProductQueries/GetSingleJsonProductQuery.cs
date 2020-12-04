using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Product;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.Implementation.Queries.ProductQueries
{
    public class GetSingleJsonProductQuery : IGetSingleProductQuery
    {
        private readonly IJsonProductContext _productContext;

        public GetSingleJsonProductQuery(IJsonProductContext productContext)
        {
            _productContext = productContext;
        }

        public string Name => typeof(GetSingleJsonProductQuery).Name;

        public ProductDto Execute(int search)
        {
            return _productContext.ReadSingle(search);
        }
    }
}
