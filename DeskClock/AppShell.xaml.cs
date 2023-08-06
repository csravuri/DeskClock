using DeskClock.Pages;

namespace DeskClock;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TimeSelectionPage), typeof(TimeSelectionPage));
	}
}
