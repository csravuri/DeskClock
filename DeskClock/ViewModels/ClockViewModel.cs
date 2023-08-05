using CommunityToolkit.Mvvm.ComponentModel;

namespace DeskClock.ViewModels
{
	public partial class ClockViewModel : ObservableObject
	{
		[ObservableProperty]
		string timeNow = DateTime.Now.ToString("HH:mm:ss");
	}
}
