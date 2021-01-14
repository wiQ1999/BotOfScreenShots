using BotOfScreenShots_Application.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BotOfScreenShots_Application.Serilizer
{
    public class XMLSerializer : ISerializer
    {
        const string PROFILESPATH = @"./Profiles.xml";

        public List<ProfileCompiler> Deserialize()
        {
            List<ProfileCompiler> result;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<ProfileCompiler>));

            if (!File.Exists(PROFILESPATH))
            {
                File.Create(PROFILESPATH);
                return new List<ProfileCompiler>();
            }
            else if (new FileInfo(PROFILESPATH).Length == 0)
                return new List<ProfileCompiler>();

            using (TextReader reader = new StreamReader(PROFILESPATH))
            {
                result = (List<ProfileCompiler>)deserializer.Deserialize(reader);
            }

            return result;
        }

        public void Serialize(List<ProfileCompiler> list)
        {
            //if (list == null || list.Count < 1)
            //{
            //    throw new ArgumentNullException("Empty list of profiles.");
            //}

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProfileCompiler>));

            using (TextWriter writer = new StreamWriter(PROFILESPATH))
            {
                serializer.Serialize(writer, list);
            }
        }
    }
}
