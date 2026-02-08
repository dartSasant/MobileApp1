namespace MobileApp1
{
    public partial class MainPage : ContentPage
    {
        private Border? _selectedBorder;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }

        private async void OnNavTapped(object sender, EventArgs e)
        {
            var tapped = (Border)sender;

            if (_selectedBorder != null)
                VisualStateManager.GoToState(_selectedBorder, "Normal");

            VisualStateManager.GoToState(tapped, "Selected");

            _selectedBorder = tapped;

            string targetRoute = tapped.AutomationId;
            if (!string.IsNullOrEmpty(targetRoute)) 
            {
                await Shell.Current.GoToAsync(targetRoute);
            }

        }

    }
}
