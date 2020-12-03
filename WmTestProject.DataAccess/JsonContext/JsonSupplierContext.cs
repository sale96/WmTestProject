using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess.JsonContext.Interfaces;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.DataAccess.JsonContext
{
    public class JsonSupplierContext : JsonContextBase, IJsonSupplierContext
    {
        public IEnumerable<SupplierDto> Read()
        {
            return base.Read().Suppliers;
        }

        public void Write(SupplierDto entity)
        {
            var supplier = Read().ToList();

            var exist = supplier.FirstOrDefault(x => x.Id == entity.Id) == null;

            if (!exist)
            {
                supplier.Add(entity);
            }

            var data = base.Read();
            data.Suppliers = supplier;

            var fileData = JsonConvert.SerializeObject(data);
            File.WriteAllText(file, fileData);
        }
    }
}
