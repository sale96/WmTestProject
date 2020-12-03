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
    public class JsonCategoryContext : JsonContextBase, IJsonCategoryContext
    {
        public IEnumerable<CategoryDto> Read()
        {
            return base.Read().Categories;
        }

        public void Write(CategoryDto entity)
        {
            var categories = Read().ToList();

            var exist = categories.FirstOrDefault(x => x.Id == entity.Id) == null;

            if (!exist)
            {
                categories.Add(entity);
            }

            var data = base.Read();
            data.Categories = categories;

            var fileData = JsonConvert.SerializeObject(data);
            File.WriteAllText(file, fileData);
        }
    }
}
