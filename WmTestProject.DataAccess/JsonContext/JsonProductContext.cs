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
