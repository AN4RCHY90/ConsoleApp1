using Newtonsoft.Json.Linq;

namespace ConsoleApp1;

public class JsonFileHandler
{
    public JObject ReadJson(string filePath)
    {
        string jContent = File.ReadAllText(filePath);
        return JObject.Parse(jContent);
    }

    public void WriteJson(string filePath, JObject jsonObj)
    {
        File.WriteAllText(filePath, jsonObj.ToString());
    }
}