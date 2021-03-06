﻿using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Commands.Product;
using WmTestProject.Application.Dto;
using WmTestProject.Application.Exceptions;
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

            var product = new Product
            {
                Name = request.Name,
                Id = request.Id,
                Price = request.Price,
                Description = request.Description,
                CategoryId = _context.Categories.FirstOrDefault(x => x.Name == request.Category).Id,
                ManufacturerId = _context.Manufacturers.FirstOrDefault(x => x.Name == request.Manufacturer).Id,
                SupplierId = _context.Suppliers.FirstOrDefault(x => x.Name == request.Supplier).Id,
            };

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
