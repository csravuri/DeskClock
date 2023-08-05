using DeskClock.ViewModels;

namespace DeskClock.Pages;

public partial class ClockPage : ContentPage
{
	public ClockPage(ClockViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}