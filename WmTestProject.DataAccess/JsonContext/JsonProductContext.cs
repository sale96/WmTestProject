using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess.JsonContext.Interfaces;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.DataAccess.JsonContext
{
    public class JsonProductContext : JsonContextBase, IJsonProductContext
    {
        public IEnumerable<ProductDto> Read()
        {
            return base.Read().Products;
        }

        public ProductDto ReadSingle(int id)
        {
            var products = Read();

            return products.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ProductDto entity)
        {
            var data = base.Read();
            var products = Read().ToList();

            foreach (var product in products)
            {
                if (product.Id == entity.Id)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.Price = entity.Price;
                    product.Category = entity.Category;
                    product.Manufacturer = entity.Manufacturer;
                    product.Supplier = entity.Supplier;
                }
            }

            data.Products = products;
            var fileData = JsonConvert.SerializeObject(data);
            File.WriteAllText(file, fileData);
        }

        public void Write(ProductDto entity)
        {
            var products = Read().ToList();

            var exist = products.FirstOrDefault(x => x.Name == entity.Name);
            var lastId = products[products.Count - 1].Id;

            entity.Id = ++lastId;

            if (exist == null)
            {
                products.Add(entity);
            }

            var data = base.Read();
            data.Products = products;

            var fileData = JsonConvert.SerializeObject(data);
            File.WriteAllText(file, fileData);
        }
    }
}
