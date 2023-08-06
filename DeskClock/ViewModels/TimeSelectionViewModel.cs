using CommunityToolkit.Mvvm.ComponentModel;

namespace DeskClock.ViewModels
{
	public partial class TimeSelectionViewModel : ObservableObject
	{
		[ObservableProperty]
		string hours;

		[ObservableProperty]
		string minutes;

		[ObservableProperty]
		string seconds;
	}
}
