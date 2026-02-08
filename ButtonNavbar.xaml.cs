	namespace MobileApp1;

	public partial class ButtonNavbar : ContentView
	{
		Border _IsSelected;

		public ButtonNavbar()
		{

			InitializeComponent();


			VisualStateManager.GoToState(NavbarBorder, "Normal");

		}
		void ToggleSelection()
		{

		}
		void OnNavTapped(object sender, EventArgs e)
		{
			if (_IsSelected != null) {
				VisualStateManager.GoToState(_IsSelected, "Normal");
			}
			_IsSelected = sender as Border;
			VisualStateManager.GoToState(_IsSelected, "Selected");
		}
	}