using Test_Builder.Pages;

namespace Test_Builder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CreateTestPage), typeof(CreateTestPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(RunTestPage), typeof(RunTestPage));
        }
    }
}
