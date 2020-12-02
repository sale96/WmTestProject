using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WmTestProject.Application.Queries.Product;

namespace WmTestProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IGetProductsQuery _query;

        public ProductsController(IGetProductsQuery query)
        {
            _query = query;
        }

        public IActionResult Index(string search)
        {
            return View(_query.Execute(search));
        }
    }
}
