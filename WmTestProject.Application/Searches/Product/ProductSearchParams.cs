using System;
using System.Collections.Generic;
using System.Text;

namespace WmTestProject.Application.Searches.Product
{
    public class ProductSearchParams : SearchParams
    {
        public string Name { get; set; }

        public SortOrder? Order { get; set; }
    }
}
