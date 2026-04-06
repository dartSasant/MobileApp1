namespace MobileApp1;

public partial class HomePage : ContentPage
{

	public HomePage()
	{
		InitializeComponent();


	}

    private async void OnResultsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ResultsPage));
    }

    private async void OnAttendanceTapped(object sender, EventArgs e)
    {
        // This looks for the route you registered in AppShell
        await Shell.Current.GoToAsync(nameof(AttendancePage));
    }

    private async void OnAchievementsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AchievementsPage));
    }
}