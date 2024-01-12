using CommunityToolkit.Mvvm.Input;
using Test_Builder.ViewModels;

namespace Test_Builder.Pages;

public partial class RunTestPage : ContentPage
{
    TimeSpan count;

    RunTestViewModel vm;

    public RunTestPage(RunTestViewModel vm)
	{
		InitializeComponent();
        this.Loaded += CurrentTime;
        BindingContext = vm;
        this.vm = vm;       			
    }
	private void CurrentTime(object sender, EventArgs e)
	{
        count = this.vm.Test.TimerValue;
        MainThread.BeginInvokeOnMainThread(() => {
			var timer = new System.Threading.Timer(obj =>
			{
				MainThread.InvokeOnMainThreadAsync(() =>
				{					
                    Timer.Time = count - TimeSpan.FromSeconds(1); });
                },
			null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        });       
    }
}