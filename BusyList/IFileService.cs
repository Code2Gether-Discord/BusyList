using Newtonsoft.Json;
using System.IO;

namespace BusyList
{
    public interface IFileService
    {
        T DeserializeOrDefault<T>(string path);
        void SerializeToFile(string path, object obj);
    }

    public class JsonFileService : IFileService
    {
        public T DeserializeOrDefault<T>(string path)
        {
            if (File.Exists(path))
            {
                var text = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(text);
            }

            return default;
        }

        public void SerializeToFile(string path, object obj)
        {
            var text = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, text);
        }
    }
}
