using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoConfession
{
    class userConfigUtils
    {
        static string path = Directory.GetCurrentDirectory() + "config.txt";
        private static userConfig _userConfig;
       // public static userConfig _userConfig { get; set; }

        public static userConfig ReadConfigFile()
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return JsonConvert.DeserializeObject<userConfig>(System.IO.File.ReadAllText(path));
              
            }
        }

        public static void writeConfigFile(bool rememberPasswordChecked = false, string userName = "", byte[] userPassword = null)
        {
            _userConfig = new userConfig();
            _userConfig.rememberPasswordChecked = rememberPasswordChecked;
            _userConfig.userName = userName;
            _userConfig.userPassword = userPassword;
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(_userConfig, Formatting.Indented));
        }

        public static void checkForConfigFile()
        {
            if (!File.Exists(path))
                File.Create(path);
        }

     

        public class userConfig
        {
            public bool rememberPasswordChecked { get; set; }
            public string userName { get; set; }
            public byte[] userPassword { get; set; }
        }
    }
}
