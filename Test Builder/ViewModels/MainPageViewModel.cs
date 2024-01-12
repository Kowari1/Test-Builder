using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;
using Test_Builder.Models;
using Test_Builder.Pages;
using Test_Builder.Services;

namespace Test_Builder.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(IFileService fileService,TestServices testServices)
        {
            this.fileService = fileService;
            this.testServices = testServices;
            Tests = new ObservableCollection<Test>((ObservableCollection<Test>?)testServices.GetAllTests());
        }
        
        private readonly TestServices testServices;

        private readonly IFileService fileService;

        public ObservableCollection<Test>? Tests { get; set; }

        #region COMMANND
        [RelayCommand]
        private async Task SearchTest(string searchTerm)
        {
            Tests.Clear();
            foreach(var Test in testServices.GetSearchTests(searchTerm))
            {
                Tests.Add(Test);
            }
        }

        [RelayCommand]
        private async Task GoToCreateTestPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateTestPage)}?EditTest={false}", new Dictionary<string, object>
            {
                {"Test", new Test()}
            });
        }

        [RelayCommand]
        private void GoToRunTestPage(Test test)
        {
            
            Shell.Current.GoToAsync(nameof(RunTestPage), new Dictionary<string, object>
            {
                {"Test", test},
                {"DeepCloneTest", testServices.ResettingFieldValues(testServices.DeepClone(test))}
            });
        }

        [RelayCommand]
        private void RemoveTest(Test test)
        {
            fileService.DeleteFile(test.PathFile);
            Tests.Remove(test);
            testServices.RemoveTest(test);
        }

        [RelayCommand]
        private async Task EditTest(Test test)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateTestPage)}?EditTest={true}", new Dictionary<string,object>
            {
                {"Test", test}              
            });
        }
        #endregion

        #region METHODS
        #endregion
    }
}
