using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WmTestProject.Application.Dto;
using System.Reflection;

namespace WmTestProject.DataAccess
{
    public class JsonContext : IJsonContext
    {
        private string file = $"{Directory.GetCurrentDirectory()}/Data/data.json";

        public IEnumerable<TEntity> Read<TEntity>() where TEntity : BaseDto
        {
            return JsonConvert.DeserializeObject<List<TEntity>>(File.ReadAllText(file)) ?? new List<TEntity>();
        }

        public void Write<TEntity>(TEntity entity) where TEntity : BaseDto
        {
            var data = Read<TEntity>().ToList();

            var exists = data.FirstOrDefault(x => x.Id == entity.Id) == null;

            if (!exists)
            {
                data.Add(entity);
            }

            var fileData = JsonConvert.SerializeObject(data);
            File.WriteAllText(file, fileData);
        }
    }
}
