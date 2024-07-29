using Newtonsoft.Json.Linq;
using Xunit;

namespace ConsoleApp1.Test
{
    public class VersionManagementTests
    {
        [Fact]
        public void UpdateVersion_MinorRelease_IncrementsMinorAndResetsPatch()
        {
            // Arrange
            var jsonObj = new JObject { ["Version"] = "1.2.3" };
            var versionManagement = new VersionManagement(jsonObj);

            // Act
            versionManagement.UpdateVersion("minor");
            var updatedJson = versionManagement.GetUpdatedJson();
            var newVersion = updatedJson["Version"].ToString();

            // Assert
            Assert.Equal("1.3.0", newVersion);
        }

        [Fact]
        public void UpdateVersion_PatchRelease_IncrementsPatch()
        {
            // Arrange
            var jsonObj = new JObject { ["Version"] = "1.2.3" };
            var versionManagement = new VersionManagement(jsonObj);

            // Act
            versionManagement.UpdateVersion("patch");
            var updatedJson = versionManagement.GetUpdatedJson();
            var newVersion = updatedJson["Version"].ToString();

            // Assert
            Assert.Equal("1.2.4", newVersion);
        }

        [Fact]
        public void UpdateVersion_InvalidRelease_ThrowsArgumentException()
        {
            // Arrange
            var jsonObj = new JObject { ["Version"] = "1.2.3" };
            var versionManagement = new VersionManagement(jsonObj);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => versionManagement.UpdateVersion("major"));
        }
    }
}