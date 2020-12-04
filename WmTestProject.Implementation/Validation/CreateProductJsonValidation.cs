using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.Implementation.Validation
{
    public class CreateProductJsonValidation : AbstractValidator<ProductDto>
    {
        public CreateProductJsonValidation(
            IJsonProductContext productContext,
            IJsonSupplierContext supplierContext,
            IJsonManufacturerContext manufacturerContext,
            IJsonCategoryContext categoryContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !productContext.Read().Any(x => x.Name == name))
                .WithMessage("Name must be unique.");
            RuleFor(x => x.Category)
                .Must(category => categoryContext.Read().Any(x => x.Name == category))
                .WithMessage("Category must exist");
            RuleFor(x => x.Manufacturer)
                .Must(manufacturer => manufacturerContext.Read().Any(x => x.Name == manufacturer))
                .WithMessage("Manufacturer must exist");
            RuleFor(x => x.Supplier)
                .Must(supplier => supplierContext.Read().Any(x => x.Name == supplier))
                .WithMessage("Supplier must exist");
        }
    }
}
