using DeskClock.ViewModels;

namespace DeskClock.Pages;

public partial class TimeSelectionPage : ContentPage
{
	public TimeSelectionPage(TimeSelectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}