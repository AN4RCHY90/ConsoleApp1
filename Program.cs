using Newtonsoft.Json.Linq;

namespace ConsoleApp1;

static class Program
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <exception cref="Exception">Thrown when there is an error updating the version number.</exception>
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the path to the json file, or a blank entry to use the default path...");
        string? filePath = Console.ReadLine();
        
        
        if (string.IsNullOrEmpty(filePath))
        {
            filePath = "C:\\Rider\\ConsoleApp1\\ProjectDetails.json";
        }
        
        Console.WriteLine("Enter the type of release (minor/patch):");
        string releaseType = Console.ReadLine()?.ToLower() ?? throw new InvalidOperationException("Please enter a valid option");

        if (releaseType != "minor" && releaseType != "patch")
        {
            Console.WriteLine("Invalid input. Please enter 'minor' or 'patch'.");
            return;
        }

        try
        {
            JsonFileHandler fileHandler = new JsonFileHandler();
            JObject jsonObj = fileHandler.ReadJson(filePath);

            VersionManagement versionManagement = new VersionManagement(jsonObj);
            versionManagement.UpdateVersion(releaseType);
            
            fileHandler.WriteJson(filePath, versionManagement.GetUpdatedJson());
            Console.WriteLine("Version number updated");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred: {e.Message}");
        }
    }
}