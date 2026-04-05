using Microsoft.Maui.ApplicationModel;
namespace MobileApp1;


public partial class ButtonNavbar : ContentView
{
    private Border? _selectedBorder;

    public ButtonNavbar()
    {
        InitializeComponent();

        VisualStateManager.GoToState(NavbarBorder, "Normal");
    }

    private async void OnNavTapped(object sender, EventArgs e)
    {
        var tapped = sender as Border;
        if (tapped == null)
            return;

        if (_selectedBorder != null)
            VisualStateManager.GoToState(_selectedBorder, "Normal");

        VisualStateManager.GoToState(tapped, "Selected");
        _selectedBorder = tapped;

        var targetRoute = tapped.AutomationId;
        if (!string.IsNullOrWhiteSpace(targetRoute))
        {
            var route = targetRoute.StartsWith("//") ? targetRoute : $"//{targetRoute}";
            try
            {
                await Shell.Current.GoToAsync(route);
            }
            catch
            {
            }
        }
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (Parent != null)
        {
            if (Shell.Current != null)
                Shell.Current.Navigated += Shell_Navigated;

            UpdateSelectionFromShell();
        }
        else
        {
            if (Shell.Current != null)
                Shell.Current.Navigated -= Shell_Navigated;
        }
    }

    private void Shell_Navigated(object sender, ShellNavigatedEventArgs e)

    {

        MainThread.BeginInvokeOnMainThread(UpdateSelectionFromShell);
    }

    private void UpdateSelectionFromShell()
    {
        try
        {
            var location = Shell.Current?.CurrentState?.Location?.OriginalString;
            if (string.IsNullOrWhiteSpace(location))
                return;

            var route = location.Trim('/');
            var qm = route.IndexOf('?');
            if (qm >= 0)
                route = route.Substring(0, qm);

            Border? found = null;
            if (string.Equals(route, HomeNav?.AutomationId, StringComparison.OrdinalIgnoreCase))
                found = HomeNav;
            else if (string.Equals(route, EventsNav?.AutomationId, StringComparison.OrdinalIgnoreCase))
                found = EventsNav;
            else if (string.Equals(route, LearningNav?.AutomationId, StringComparison.OrdinalIgnoreCase))
                found = LearningNav;
            else if (string.Equals(route, NoticeNav?.AutomationId, StringComparison.OrdinalIgnoreCase))
                found = NoticeNav;
            else if (string.Equals(route, ProfileNav?.AutomationId, StringComparison.OrdinalIgnoreCase))
                found = ProfileNav;

            if (_selectedBorder != null && _selectedBorder != found)
                VisualStateManager.GoToState(_selectedBorder, "Normal");

            if (found != null)
            {
                VisualStateManager.GoToState(found, "Selected");
                _selectedBorder = found;
            }
        }
        catch
        {
            // ignore errors during selection sync
        }
    }
}
