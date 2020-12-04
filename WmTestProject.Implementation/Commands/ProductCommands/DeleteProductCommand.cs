using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmTestProject.Application.Commands.Product;
using WmTestProject.DataAccess;

namespace WmTestProject.Implementation.Commands.ProductCommands
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly WmTestContext _context;
        public DeleteProductCommand(WmTestContext context)
        {
            _context = context;
        }

        public string Name => typeof(DeleteProductCommand).Name;

        public void Execute(int request)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
