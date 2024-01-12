using Test_Builder.ViewModels;

namespace Test_Builder.Pages;

public partial class CreateTestPage : ContentPage
{
    CreateTestPageViewModel vm;
    public CreateTestPage(CreateTestPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
    }
}