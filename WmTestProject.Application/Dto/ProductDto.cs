using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.Application.Dto
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
    }
}
