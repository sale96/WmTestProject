using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WmTestProject.Application.Dto;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;

namespace WmTestProject.DataAccess.JsonContext
{
    public class JsonManufacturerContext : JsonContextBase, IJsonManufacturerContext
    {
        public IEnumerable<ManufacturerDto> Read()
        {
            return base.Read().Manufactures;
        }

        public void Write(ManufacturerDto entity)
        {
            var manufacturers = Read().ToList();

            var exist = manufacturers.FirstOrDefault(x => x.Id == entity.Id) == null;

            if (!exist)
            {
                manufacturers.Add(entity);
            }

            var data = base.Read();
            data.Manufactures = manufacturers;

            var fileData = JsonConvert.SerializeObject(data);
            File.WriteAllText(file, fileData);
        }
    }
}
