namespace MobileApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EventsPage), typeof(EventsPage));
            Routing.RegisterRoute(nameof(LearningPage), typeof(LearningPage));
            Routing.RegisterRoute(nameof(NoticePage), typeof(NoticePage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(AttendancePage), typeof(AttendancePage));

        }
    }
}
