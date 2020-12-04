using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Exceptions;
using WmTestProject.Application.Queries.Product;
using WmTestProject.DataAccess;
using WmTestProject.Domain.Entities;
using WmTestProject.Implementation.Validation;

namespace WmTestProject.Implementation.Commands.ProductCommands
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly WmTestContext _context;
        private readonly IMapper _mapper;
        private readonly CreateProductValidation _productValidation;

        public UpdateProductCommand(
            WmTestContext context,
            IMapper mapper,
            CreateProductValidation productValidation)
        {
            _context = context;
            _mapper = mapper;
            _productValidation = productValidation;
        }

        public string Name => typeof(UpdateProductCommand).Name;

        public void Execute(ProductDto request)
        {
            _productValidation.ValidateAndThrow(request);

            var product = _mapper.Map<ProductDto, Product>(request);

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
