using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WmTestProject.Application.Queries.Categories;
using WmTestProject.Application.Queries.Manufacturer;
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

        public IActionResult Add(
            [FromServices] IGetCategoriesQuery categories,
            [FromServices] IGetManufacturersQuery manufacturers)
        {
            ViewBag.Categories = categories.Execute("").Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()
            });

            ViewBag.Manufacturers = manufacturers.Execute("").Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name.ToString()
            });

            return View();
        }
    }
}
