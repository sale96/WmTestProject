using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WmTestProject.Application.Dto;
using System.Reflection;
using WmTestProject.DataAccess.JsonContext.Interfaces;

namespace WmTestProject.DataAccess.JsonContext
{
    public class JsonContextBase : IJsonContextRead<JsonData>, IJsonContextWrite<JsonData>
    {
        protected string file = $"{Directory.GetCurrentDirectory()}/Data/data.json";

        public JsonData Read()
        {
            return JsonConvert.DeserializeObject<JsonData>(File.ReadAllText(file)) ?? new JsonData();
        }

        public void Write(JsonData entity)
        {
            var fileData = JsonConvert.SerializeObject(entity);
            File.WriteAllText(file, fileData);
        }
    }
}
