using Newtonsoft.Json;
using System.Xml.Serialization;

namespace SofthouseDev.Utilities
{
    public class Serializer : ISerializer
    {
        public void SaveToFile<T>(T model, SerializationFormat format, string filePath)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            switch (format)
            {
                case SerializationFormat.Json:
                    SaveToJsonFile(model, filePath);
                    break;
                case SerializationFormat.Xml:
                    SaveToXmlFile(model, filePath);
                    break;
                default:
                    throw new ArgumentException($"Unsupported format: {format}", nameof(format));
            }
        }

        private static void SaveToJsonFile<T>(T model, string filePath) 
        {
            var jsonString = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        private static void SaveToXmlFile<T>(T model, string filePath)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, model);
            }
        }
    }
}
