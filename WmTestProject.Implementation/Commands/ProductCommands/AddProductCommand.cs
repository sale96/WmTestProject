using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Commands.Product;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess;

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
        }
    }
}
