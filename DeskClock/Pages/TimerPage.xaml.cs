using DeskClock.ViewModels;

namespace DeskClock.Pages;

public partial class TimerPage : ContentPage
{
	public TimerPage(TimerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}