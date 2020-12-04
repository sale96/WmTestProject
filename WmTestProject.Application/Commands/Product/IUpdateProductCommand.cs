using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;

namespace WmTestProject.Application.Commands.Product
{
    public interface IUpdateProductCommand : ICommand<ProductDto>
    {
    }
}
