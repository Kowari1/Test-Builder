using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using Test_Builder.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Builder.Services
{
    public class TestServices
    {
        public TestServices(IFileService fileService)
        {
            this.fileService = fileService;
            Tests = new ObservableCollection<Test>(fileService.OpenFileDirectiry
                (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "*.txt"));
        }

        IFileService fileService;

        private ObservableCollection<Test>? Tests;

        #region METHODS
        public IEnumerable<Test>? GetAllTests() => Tests;

        public IEnumerable<Test>? GetSearchTests(string testName) =>
             string.IsNullOrWhiteSpace(testName)
             ? Tests
             : Tests.Where(x => x.Name.Contains(testName, StringComparison.OrdinalIgnoreCase));


        public bool СheckingNamevaiAlability(Test test)
        {
            Test? result = Tests?.SingleOrDefault(x => x.Name.Equals(test.Name, StringComparison.OrdinalIgnoreCase));
            if (result == null || test == result)
                return true;
            else
                return false;
                
        }

        public void RemoveTest(Test test)
        {
            Tests.Remove(test);
        }

        public void AddTest(Test test)
        {
            Tests.Add(test);
        }

        public Test DeepClone(Test test)
        {
            using (var ms = new MemoryStream())
            {
                JsonSerializer.Serialize<Test>(ms, test);
                ms.Position = 0;
                return JsonSerializer.Deserialize<Test>(ms);
            }
        }

        public Test ResettingFieldValues(Test test)
        {
            foreach (var question in test.Questions)
            {                         
                foreach(var item in question.items)
                {
                    var ansverProp = item.GetType().GetProperty("CorrectAnswer");
                    ansverProp.SetValue(item, null);
                }
            }
            return test;
        }
        #endregion
    }
}
