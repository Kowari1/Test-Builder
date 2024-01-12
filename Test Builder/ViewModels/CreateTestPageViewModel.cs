using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Test_Builder.Models;
using Test_Builder.Pages;
using Test_Builder.Popups;
using Test_Builder.Services;

namespace Test_Builder.ViewModels
{
    [QueryProperty(nameof(EditTest), "EditTest")]
    [QueryProperty(nameof(Test), "Test")]
    public partial class CreateTestPageViewModel : ObservableObject
    {
        public CreateTestPageViewModel(TestServices testServices,IFileService fileService)
        {
            this.fileService = fileService;
            this.testServices = testServices;
            Test = new Test();
        }

        private readonly TestServices testServices;
        private readonly IFileService fileService;

        [ObservableProperty]
        private Test test;

        [ObservableProperty]
        private bool editTest;

        #region COMMANND
        [RelayCommand]
        private void CreateQuestionCheckBoxItems() => AddAnyQuestion(new CheckBoxItem());

        [RelayCommand]
        private void CreateQuestionRadioButtomItems() => AddAnyQuestion(new RadioButtonItem());

        [RelayCommand]
        private void CreateQuestionTextItems() => AddAnyQuestion(new TextItem());

        [RelayCommand]
        private void RemoveQuestion(Question question) => Test.Questions.Remove(question);

        [RelayCommand]
        private void AddItem(Question question)
        {
            question.items.Add((IItem)Activator.CreateInstance(question.items[0].GetType()));            
        }

        [RelayCommand]
        private void RemoveItem(IItem item)
        {
            Question question = Test.Questions.Single(x => x.items.Contains(item));
            if (question.items.Count() > 1)
                question.items.Remove(item);
            else
                Test.Questions.Remove(question);
        }

        [RelayCommand]
        private void RadioButtonChekced(RadioButtonItem item)
        {
            Question question = Test.Questions.Single(x => x.items.Contains(item));

            foreach (RadioButtonItem rb in question.items)
            {
                rb.CorrectAnswer = false;
            }

            item.CorrectAnswer = true;
        }

        [RelayCommand]
        private void CreateTest()
        {
            bool resultСheckingName = testServices.СheckingNamevaiAlability(test);

            if (editTest == true && resultСheckingName == true)
                Shell.Current.CurrentPage.ShowPopupAsync(new CreateTestPopup(this));
            else if(resultСheckingName == true)
            {
                Test.PathFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"/{Test.Name}.txt";
                testServices.AddTest(test);                
                fileService.Save(Test);
                GoToMainPage();
            }
            else
                Shell.Current.CurrentPage.ShowPopupAsync(new NotificationPopup("A test with the same name already exists"));
        }

        [RelayCommand]
        private void PopupYesButton()
        {
            fileService.DeleteFile(Test.PathFile);
            Test.PathFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"/{Test.Name}.txt";           
            fileService.Save(Test);
            GoToMainPage();
        }

        [RelayCommand]
        private void PopupNoButton()
        {
            GoToMainPage();
        }
        #endregion

        #region METHODS
        async private void GoToMainPage()
        {
          await Shell.Current.GoToAsync(nameof(MainPage),animate: true);
        }

        private void AddAnyQuestion<T>(T item)
            where T : IItem, new()
        {
            Question question = new Question();
            question.items.Add(item);
            Test.Questions.Add(question);
        }       
        #endregion
    }
}
