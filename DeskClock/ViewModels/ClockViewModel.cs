using CommunityToolkit.Mvvm.ComponentModel;

namespace DeskClock.ViewModels
{
	public partial class ClockViewModel : ObservableObject
	{
		public ClockViewModel(IDispatcher dispatcher)
		{
			dispatcherTimer = dispatcher.CreateTimer();
			dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
			dispatcherTimer.Tick += Timer_Tick;
			dispatcherTimer.Start();
		}
		readonly IDispatcherTimer dispatcherTimer;

		~ClockViewModel()
		{
			if (dispatcherTimer != null)
			{
				dispatcherTimer.Tick -= Timer_Tick;
				dispatcherTimer.Stop();
			}
		}

		[ObservableProperty]
		string timeNow;

		void Timer_Tick(object sender, EventArgs e)
		{
			TimeNow = DateTime.Now.ToString(TimeFormat);
		}

		const string TimeFormat = "HH:mm:ss";
	}
}
