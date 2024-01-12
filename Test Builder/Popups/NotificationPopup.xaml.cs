using CommunityToolkit.Maui.Views;

namespace Test_Builder.Popups;

public partial class NotificationPopup : Popup
{
	public NotificationPopup(string message)
	{
		InitializeComponent();
		Message.Text = message;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}