# VersionManagement Console Application

### Description of the Sections

- **Overview:** Gives a brief description of what the application does.
- **Features:** Highlights the key functionalities provided by the application.
- **Usage:** Explains how to run the application, including prerequisites and command line usage.
- **How It Works:** Describes the basic workflow of the application.
- **JSON File Structure:** Provides a template for the expected structure of the JSON file.
- **Important Notes:** Notes on default behavior and file permissions.
- **Error Handling:** Information on how the application handles errors and exceptions.
- **Development:** Instructions for running tests and contributing to the project.
- **License:** Specifies the licensing under which the project is shared.

## Overview

The **VersionManagement** console application is designed to manage the versioning of a software project stored in a JSON file. The application can update the version number based on the type of release specified by the user, either "minor" or "patch".

## Features

- **Version Management**: Increment the minor or patch version numbers based on the user's input.
- **Flexible File Input**: Users can specify a JSON file path or use a default path if one is not provided.

## Usage

### Prerequisites

- Ensure you have the .NET runtime installed on your system.

### Running the Application

To run the application, use the command line. You can specify the path to the JSON file containing the version information or use the default path provided by the application.

#### Command Line Arguments

1. **File Path**: The path to the JSON file (optional, will be prompted if not provided).
2. **Release Type**: The type of release ("minor" or "patch").

#### Examples

**Using Command Line Arguments:**
dotnet run --project ./path/to/ConsoleApp1 "path/to/version.json" minor
Prompted for File Path:

dotnet run --project ./path/to/ConsoleApp1
When run without the file path, the application will prompt:

Enter the path to the JSON file (or press Enter to use the default path):

**How It Works**
Reading the JSON File: The application reads the specified JSON file to extract the current version number.
Updating the Version: Based on the user input ("minor" or "patch"), the application increments the corresponding version component.
Saving Changes: The updated version number is saved back to the JSON file, preserving all other data.
JSON File Structure
The JSON file should contain a "Version" key as follows:

{
    "Version": "1.2.3",
    "OtherData": {
        "Example": "Data"
    }
}

**Important Notes**
Default Path: If you do not specify a file path, the application uses a default path (default/path/to/json/file.json). Ensure this path exists and is accessible, or specify your own path when prompted.
Permissions: Ensure the application has permission to read and write to the specified JSON file.
Error Handling
If the specified file does not exist or cannot be accessed, the application will display an error message.
An invalid version format in the JSON file will result in an exception, indicating the issue.
Development
Running Tests
Unit tests are implemented using xUnit. To run the tests, navigate to the test project's directory and use:

dotnet test
This command will execute all tests and provide a summary of the results.