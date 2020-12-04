using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess;

namespace WmTestProject.Implementation.Validation
{
    public class CreateProductValidation : AbstractValidator<ProductDto>
    {
        public CreateProductValidation(WmTestContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !context.Products.Any(x => x.Name == name))
                .WithMessage("Name must be unique.");
            RuleFor(x => x.Category)
                .Must(category => context.Categories.Any(x => x.Name == category))
                .WithMessage("Category must exist");
            RuleFor(x => x.Manufacturer)
                .Must(manufacturer => context.Manufacturers.Any(x => x.Name == manufacturer))
                .WithMessage("Manufacturer must exist");
            RuleFor(x => x.Supplier)
                .Must(supplier => context.Suppliers.Any(x => x.Name == supplier))
                .WithMessage("Supplier must exist");
        }
    }
}
