using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.Domain.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
