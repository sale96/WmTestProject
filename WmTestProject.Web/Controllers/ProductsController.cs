using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WmTestProject.Application.Queries.Product;
using WmTestProject.Application.Searches.Product;

namespace WmTestProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IGetProductsQuery _query;
        private readonly IGetProductsJsonQuery _jsonQuery;

        public ProductsController(
            IGetProductsQuery query,
            IGetProductsJsonQuery jsonQuery)
        {
            _query = query;
            _jsonQuery = jsonQuery;
        }

        public IActionResult Index(ProductSearchParams search)
        {
            return View(_jsonQuery.Execute(search));
        }

        public IActionResult Add() => View();
    }
}
