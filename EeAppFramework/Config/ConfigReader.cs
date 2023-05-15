using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EaAppFramework.Config
{
    public static class ConfigReader
    {
        public static TestSettings ReadConfig()
        {
            //Getting the location of the appsettins.json
            var appSettingsLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appsettings.json";

            //Read all the property from the File.
            var configFile = File.ReadAllText(appSettingsLocation);

            //Adding some serializer option to be case insensitive of the property
            var jsonSerializerSetting = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
               
            };

            //Passing enum string converter
            jsonSerializerSetting.Converters.Add(new JsonStringEnumConverter());

            //Deserializing the property of the Test setting class.
            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerSetting);


        }
    }
}
