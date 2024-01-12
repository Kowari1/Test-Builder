using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Test_Builder.Models;
using Test_Builder.Pages;

namespace Test_Builder.ViewModels
{
    [QueryProperty(nameof(Test), "Test")]
    [QueryProperty(nameof(DeepCloneTest), "DeepCloneTest")]
    public partial class RunTestViewModel : ObservableObject
    {
        public RunTestViewModel()
        {
            
        }

        [ObservableProperty]
        private Test test;

        [ObservableProperty]
        private Test deepCloneTest;

        #region COMMANND
        [RelayCommand]
        private void RadioButtonChekced(RadioButtonItem item)
        {
            Question question = deepCloneTest.Questions.Single(x => x.items.Contains(item));

            foreach (RadioButtonItem rb in question.items)
            {
                rb.CorrectAnswer = false;
            }

            item.CorrectAnswer = true;
        }

        [RelayCommand]
        private static async void GoToMainPage()
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        #endregion

        #region METHODS       
        #endregion
    }
}
