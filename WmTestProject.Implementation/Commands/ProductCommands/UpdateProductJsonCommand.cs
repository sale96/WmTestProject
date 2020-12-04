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
    public class UpdateProductJsonCommand : IUpdateProductCommand
    {
        private readonly IJsonProductContext _productContext;
        private readonly CreateProductValidation _productValidation;

        public UpdateProductJsonCommand(IJsonProductContext productContext, CreateProductValidation productValidation)
        {
            _productContext = productContext;
            _productValidation = productValidation;
        }


        public string Name => typeof(UpdateProductJsonCommand).Name;

        public void Execute(ProductDto request)
        {
            _productValidation.ValidateAndThrow(request);

            _productContext.Update(request);
        }
    }
}
