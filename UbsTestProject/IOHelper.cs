using Newtonsoft.Json;
using System;
using System.IO;

namespace UbsTestProject
{
    /// <summary>
    /// Utility for managing json files and directory access
    /// </summary>
    public class IOHelper
    {
        public string getSolutionDirectory()
        {
            var currentDir = Environment.CurrentDirectory;
            var directory = new DirectoryInfo(
            Path.GetFullPath(Path.Combine(currentDir, @"..\UbsTestProject\")));
            return directory.ToString();
        }

        public T readJson<T>(string jsonName)
        {
            StreamReader file = File.OpenText(getSolutionPath(jsonName));
            String json = file.ReadToEnd();
            var configuration = JsonConvert.DeserializeObject<T>(json);
            return configuration;
        }

        public string getSolutionPath(String path)
        {
            var directory = new DirectoryInfo(
            Path.GetFullPath(Path.Combine(getSolutionDirectory(), path)));
            return directory.ToString();
        }

        public string getDriversDirectory()
        {
            var solutionDir = getSolutionDirectory();
            var directory = new DirectoryInfo(
            Path.GetFullPath(Path.Combine(solutionDir, "drivers")));
            return directory.ToString();
        }
    }
}
