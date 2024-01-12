using Test_Builder.ViewModels;

namespace Test_Builder.Pages;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel vm;
    public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
    }

    private void searchTest_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(!string.IsNullOrWhiteSpace(e.OldTextValue)
            && string.IsNullOrWhiteSpace(e.NewTextValue))
            vm.SearchTestCommand.Execute(null);
    }
}

