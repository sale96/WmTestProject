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
            var product = _mapper.Map<ProductDto, Product>(request);

            _context.Products.Add(product);
            _context.SaveChanges();

        }
    }
}
