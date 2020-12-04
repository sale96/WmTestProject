using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WmTestProject.Application.Commands.Product;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Queries.Categories;
using WmTestProject.Application.Queries.Manufacturer;
using WmTestProject.Application.Queries.Product;
using WmTestProject.Application.Queries.Supplier;
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

        [HttpGet]
        public IActionResult Add(
            [FromServices] IGetCategoriesQuery categories,
            [FromServices] IGetManufacturersQuery manufacturers,
            [FromServices] IGetSuppliersQuery suppliers)
        {
            ViewBag.Categories = categories.Execute("").Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });

            ViewBag.Manufacturers = manufacturers.Execute("").Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });

            ViewBag.Suppliers = suppliers.Execute("").Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });

            return View();
        }

        [HttpPost]
        public IActionResult Add(
            ProductDto product,
            [FromServices] IAddProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error in the model");
                return View(product);
            }

            command.Execute(product);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(
            int id,
            [FromServices] IGetSingleProductQuery query)
        {
            return View(query.Execute(id));
        }
    }
}
