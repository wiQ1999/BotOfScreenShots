using BotOfScreenShots_Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BotOfScreenShots_Application.Serilizer
{
    public class JSONSerializer : ISerializer
    {
        const string PROFILESPATH = @"./Profiles.json";

        private readonly JsonSerializer _json = new JsonSerializer();

        public List<ProfileCompiler> Deserialize()
        {
            List<ProfileCompiler> result = new List<ProfileCompiler>();

            if (!File.Exists(PROFILESPATH))
                return result;

            try
            {
                using (TextReader reader = new StreamReader(PROFILESPATH))
                {
                    string jsonString = reader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<List<ProfileCompiler>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        public void Serialize(List<ProfileCompiler> list)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(PROFILESPATH))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    _json.Serialize(writer, list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
