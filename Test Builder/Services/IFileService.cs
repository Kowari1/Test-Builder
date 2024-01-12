using System.Text.Json;
using Test_Builder.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Builder.Services
{
    public interface IFileService
    {
        Test Open(string filename);
        void Save(Test test);
        void DeleteFile(string path);
        IEnumerable<Test> OpenFileDirectiry(string folderPath,string fileExtension);
    }

    public class JsonFormatterService : IFileService
    {
        public void DeleteFile(string path)
        {
             File.Delete(path);
        }

        public Test Open(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
               return JsonSerializer.Deserialize<Test>(fs);
            }
        }

        async public void Save(Test test)
        {
            using (FileStream fs = new FileStream(test.PathFile, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, test);
            }
        }

        public IEnumerable<Test> OpenFileDirectiry(string folderPath, string fileExtension)
        {
            List<Test> result = new List<Test>();
            var filesPath = Directory.GetFiles(folderPath, fileExtension);
            foreach (var file in filesPath)
            {
                result.Add(Open(file));
            }
            return result;
        }
    }
}
