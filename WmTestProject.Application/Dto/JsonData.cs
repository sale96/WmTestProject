using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.Application.Dto
{
    public class JsonData
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<ManufacturerDto> Manufactures { get; set; }
        public IEnumerable<SupplierDto> Suppliers { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
