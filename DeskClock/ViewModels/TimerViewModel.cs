using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeskClock.Pages;

namespace DeskClock.ViewModels
{
	public partial class TimerViewModel : ObservableObject
	{
		public TimerViewModel(IDispatcher dispatcher)
		{
			dispatcherTimer = dispatcher.CreateTimer();
			dispatcherTimer.Interval = Time1Second;
			UpdateTimer();
		}

		[ObservableProperty]
		string timerNow;

		[ObservableProperty]
		bool isRunning;

		[RelayCommand]
		void Start()
		{
			IsRunning = true;
			dispatcherTimer.Tick += DispatcherTimer_Tick;
			dispatcherTimer.Start();
		}

		[RelayCommand]
		void Pause()
		{
			IsRunning = false;
			dispatcherTimer.Tick -= DispatcherTimer_Tick;
			dispatcherTimer.Stop();
		}

		[RelayCommand]
		void Reset()
		{
			timeCounter = TimeSpan.Zero;
			UpdateTimer();
		}

		[RelayCommand]
		async Task EditTime()
		{
			await Shell.Current.GoToAsync(nameof(TimeSelectionPage));
		}

		void DispatcherTimer_Tick(object sender, EventArgs e)
		{
			if (timeCounter <= TimeSpan.Zero)
			{
				Pause();
				Reset();
				return;
			}
			timeCounter -= Time1Second;
			UpdateTimer();
		}

		void UpdateTimer()
		{
			TimerNow = string.Format("{0}:{1:00}:{2:00}",
				(int)timeCounter.TotalHours, timeCounter.Minutes, timeCounter.Seconds);
		}

		readonly TimeSpan Time1Second = TimeSpan.FromSeconds(1);
		TimeSpan timeCounter = TimeSpan.Zero;
		private readonly IDispatcherTimer dispatcherTimer;
	}
}
