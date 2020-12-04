using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Commands.Product;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess;
using WmTestProject.Domain.Entities;

namespace WmTestProject.Implementation.Commands.ProductCommands
{
    public class AddProductCommand : IAddProductCommand
    {
        private readonly WmTestContext _context;
        private readonly IMapper _mapper;

        public AddProductCommand(
            WmTestContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public string Name => typeof(AddProductCommand).Name;

        public void Execute(ProductDto request)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Name.ToLower() == request.Category.ToLower());
            var manufacturer = _context.Manufacturers.FirstOrDefault(x => x.Name.ToLower() == request.Manufacturer.ToLower());
            var supplier = _context.Suppliers.FirstOrDefault(x => x.Name.ToLower() == request.Supplier.ToLower());

            if (category == null)
                throw new ArgumentException("Category fail");
            if (manufacturer == null)
                throw new ArgumentException("Manufacturer fail");
            if (supplier == null)
                throw new ArgumentException("Supplier fail");

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = category.Id,
                ManufacturerId = manufacturer.Id,
                SupplierId = supplier.Id
            };

            _context.Products.Add(product);
            _context.SaveChanges();

        }
    }
}
