using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Commands.Product;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;
using WmTestProject.Implementation.Validation;

namespace WmTestProject.Implementation.Commands.ProductCommands
{
    public class IAddProductJsonCommand : IAddProductCommand
    {
        private readonly IJsonProductContext _context;
        private readonly CreateProductJsonValidation _productValidation;

        public IAddProductJsonCommand(
            IJsonProductContext context,
            CreateProductJsonValidation productValidation)
        {
            _context = context;
            _productValidation = productValidation;
        }

        public string Name => typeof(IAddProductJsonCommand).Name;

        public void Execute(ProductDto request)
        {
            _productValidation.ValidateAndThrow(request);
            _context.Write(request);
        }
    }
}
