using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotdEditor.Models
{
    public class AppSettings
    {
        [JsonIgnore]
        private string ConfigFilePath;
        public string motd = "";
        //TODO 保存MOTD，下次打开直接能修改上次的
        public AppSettings()
        {
            ConfigFilePath = Path.Combine(Environment.CurrentDirectory, "config.json");
            CheakFileExist();
            ReadFormText();
        }
        private void ReadFormText()
        {
            var json = JObject.Parse(ReadConfigJson());
            motd = json["motd"].ToString();
        }

        public void Save() 
        {
            File.WriteAllText(ConfigFilePath,GetConfigJsonFormThis());
        }

        void CheakFileExist()
        {
            if (!File.Exists(ConfigFilePath))
                File.WriteAllText(ConfigFilePath, GetConfigJsonFormThis());
        }

        string GetConfigJsonFormThis() => JObject.FromObject(this).ToString();

        string ReadConfigJson()
        {
            CheakFileExist();
            return File.ReadAllText(ConfigFilePath);
        }
    }
}
