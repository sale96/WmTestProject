using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WmTestProject.Application;
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
        private readonly UseCaseExecutor _executor;
        private readonly IGetProductsQuery _query;
        private readonly IGetProductsJsonQuery _jsonQuery;
        private readonly IGetCategoriesQuery _categories;
        private readonly IGetManufacturersQuery _manufacturers;
        private readonly IGetSuppliersQuery _suppliers;

        public ProductsController(
            UseCaseExecutor executor,
            IGetProductsQuery query,
            IGetProductsJsonQuery jsonQuery,
            IGetCategoriesQuery categories,
            IGetManufacturersQuery manufacturers,
            IGetSuppliersQuery suppliers)
        {
            _executor = executor;
            _query = query;
            _jsonQuery = jsonQuery;
            _categories = categories;
            _manufacturers = manufacturers;
            _suppliers = suppliers;
        }

        public IActionResult Index(ProductSearchParams search)
        {
            return View(_executor.ExecuteQuery(_query, search));
        }

        [HttpGet]
        public IActionResult Add()
        {
            GenerateViewBags();
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
                GenerateViewBags();
                return View(product);
            }

            _executor.ExecuteCommand(command, product);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(
            int id,
            [FromServices] IGetSingleProductQuery query)
        {
            GenerateViewBags();

            return View(_executor.ExecuteQuery(query, id));
        }

        [HttpPost]
        public IActionResult Edit(
            ProductDto product,
            [FromServices] IUpdateProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model error");
                GenerateViewBags();
                return View(product);
            }

            _executor.ExecuteCommand(command, product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(
            int id,
            [FromServices] IDeleteProductCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return RedirectToAction("Index");
        }

        private void GenerateViewBags()
        {

            ViewBag.Categories = _executor.ExecuteQuery(_categories, "").Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });

            ViewBag.Manufacturers = _executor.ExecuteQuery(_manufacturers, "").Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });

            ViewBag.Suppliers = _executor.ExecuteQuery(_suppliers, "").Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });
        }
    }
}
