using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    public class VersionManagement
    {
        private JObject _jObject;
        private string _version;

        public VersionManagement(JObject jObject)
        {
            _jObject = jObject ?? throw new ArgumentNullException(nameof(jObject));

            _version = _jObject["Version"]?.ToString() ?? throw new ArgumentException("Version key is missing or null.");
        }

        public string UpdateVersion(string releaseType)
        {
            if (string.IsNullOrEmpty(_version))
            {
                throw new InvalidOperationException("Version cannot be null or empty.");
            }

            string[] versionParts = _version.Split('.');
            if (versionParts.Length != 3)
            {
                throw new ArgumentException("Invalid version format. Expected 'Major.Minor.Patch'.");
            }

            if (!int.TryParse(versionParts[0], out int major) ||
                !int.TryParse(versionParts[1], out int minor) ||
                !int.TryParse(versionParts[2], out int patch))
            {
                throw new ArgumentException("Invalid version numbers. Expected integers.");
            }

            if (releaseType == "minor")
            {
                minor++;
                patch = 0;
            }
            else if (releaseType == "patch")
            {
                patch++;
            }
            else
            {
                throw new ArgumentException("Invalid release type.");
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
}