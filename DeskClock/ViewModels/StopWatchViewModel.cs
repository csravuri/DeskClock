using CommunityToolkit.Mvvm.ComponentModel;

namespace DeskClock.ViewModels
{
	public partial class StopWatchViewModel : ObservableObject
	{
		[ObservableProperty]
		string timeNow;

		[ObservableProperty]
		bool isRunning;
	}
}
