using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Exceptions;
using WmTestProject.Application.Queries.Product;
using WmTestProject.DataAccess;
using WmTestProject.Domain.Entities;

namespace WmTestProject.Implementation.Commands.ProductCommands
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly WmTestContext _context;
        private readonly IMapper _mapper;

        public UpdateProductCommand(
            WmTestContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string Name => typeof(UpdateProductCommand).Name;

        public void Execute(ProductDto request)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
                throw new UnexistingEntityException();

            product.CategoryId = _context.Categories.FirstOrDefault(x => x.Name == request.Category).Id;
            product.ManufacturerId = _context.Manufacturers.FirstOrDefault(x => x.Name == request.Manufacturer).Id;
            product.SupplierId = _context.Suppliers.FirstOrDefault(x => x.Name == request.Supplier).Id;
            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
