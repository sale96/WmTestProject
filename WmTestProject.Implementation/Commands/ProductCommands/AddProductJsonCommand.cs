using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Commands.Product;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.Implementation.Commands.ProductCommands
{
    public class IAddProductJsonCommand : IAddProductCommand
    {
        private readonly IJsonProductContext _context;

        public IAddProductJsonCommand(IJsonProductContext context)
        {
            _context = context;
        }

        public string Name => typeof(IAddProductJsonCommand).Name;

        public void Execute(ProductDto request)
        {
            _context.Write(request);
        }
    }
}
