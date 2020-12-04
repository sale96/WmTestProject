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
            var product = _mapper.Map<ProductDto, Product>(request);

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
