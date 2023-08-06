using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeskClock.Pages;

namespace DeskClock.ViewModels
{
	public partial class TimerViewModel : ObservableObject
	{
		[ObservableProperty]
		TimeSpan selectedTime;

		[RelayCommand]
		async Task EditTime()
		{
			await Shell.Current.GoToAsync(nameof(TimeSelectionPage));
		}
	}
}
