using Newtonsoft.Json.Linq;

namespace ConsoleApp1;

public class VersionManagement
{
    private JObject _jObject;
    private string _version;

    public VersionManagement(JObject jObject)
    {
        _jObject = jObject;
        _version = _jObject["version"].ToString();
    }

    public string UpdateVersion(string releaseType)
    {
        string[] versionParts = _version.Split('.');
        int major = int.Parse(versionParts[0]);
        int minor = int.Parse(versionParts[1]);
        int patch = int.Parse(versionParts[2]);

        if (releaseType == "minor")
        {
            minor++;
            patch = 0;
        }
        else if (releaseType == "patch")
        {
            patch++;
        }
        
        _version = $"{major}.{minor}.{patch}";
        _jObject["Version"] = _version;

        return _version;
    }

    public JObject GetUpdatedJson()
    {
        return _jObject;
    }
}