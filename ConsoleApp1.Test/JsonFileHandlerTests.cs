using Newtonsoft.Json.Linq;

namespace ConsoleApp1.Test;

public class JsonFileHandlerTests
{
    [Fact]
    public void ReadJson_ValidFile_ReturnsJObect()
    {
        // Arrange
        var tempFilePath = Path.GetTempFileName();
        var expectedJson = new JObject { ["Version"] = "1.2.3" };
        File.WriteAllText(tempFilePath, expectedJson.ToString());

        var jsonFileHandler = new JsonFileHandler();

        try
        {
            // Act
            var result = jsonFileHandler.ReadJson(tempFilePath);
            
            // Assert
            Assert.Equal(expectedJson.ToString(), result.ToString());
        }
        finally
        {
            // Clean up
            File.Delete(tempFilePath);
        }
    }

    [Fact]
    public void WriteJson_ValidJObject_WritesToFile()
    {
        // Arrange
        var tempFilePath = Path.GetTempFileName();
        var jsonObj = new JObject{ ["Version"] = "1.2.3" };

        var jsonFileHandler = new JsonFileHandler();

        try
        {
            // Act
            jsonFileHandler.WriteJson(tempFilePath, jsonObj);

            // Assert
            var fileContent = File.ReadAllText(tempFilePath);
            var result = JObject.Parse(fileContent);
            Assert.Equal(jsonObj.ToString(), result.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
            throw;
        }
        finally
        {
            // Clean up
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
    }

    [Fact]
    public void ReadJson_InvalidFilePath_ThrowsFileNotFoundException()
    {
        // Arrange
        var invalidFilePath = Path.Combine(Path.GetTempPath(), "nonexistentfile.json");
        var jsonFileHandler = new JsonFileHandler();
        
        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => jsonFileHandler.ReadJson(invalidFilePath));
    }
}