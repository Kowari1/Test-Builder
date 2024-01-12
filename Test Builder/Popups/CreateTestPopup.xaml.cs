using CommunityToolkit.Maui.Views;
using Test_Builder.ViewModels;

namespace Test_Builder.Popups;

public partial class CreateTestPopup : Popup
{
	public CreateTestPopup(CreateTestPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		this.Close();
    }
}