using DeskClock.ViewModels;

namespace DeskClock.Pages;

public partial class StopWatchPage : ContentPage
{
	public StopWatchPage(StopWatchViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}