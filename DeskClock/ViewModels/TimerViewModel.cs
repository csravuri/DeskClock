using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeskClock.Models;
using DeskClock.Pages;

namespace DeskClock.ViewModels;

public partial class TimerViewModel : ObservableObject, IQueryAttributable
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
		timeCounter = TimeSpan.FromSeconds(timeBackup.TotalSeconds);
		UpdateTimer();
	}

	[RelayCommand]
	async Task EditTime()
	{
		if (selectedTime is null)
		{
			selectedTime = new TimeModel();
		}
		else
		{
			selectedTime.IsSaved = false;
		}

		if (!IsRunning)
		{
			selectedTime.Time = timeCounter;
		}

		await Shell.Current.GoToAsync(nameof(TimeSelectionPage),
			new Dictionary<string, object>()
			{
				{ nameof(TimeSelectionViewModel.SelectedTime), selectedTime }
			});
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

	void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if (query.TryGetValue(nameof(TimeSelectionViewModel.SelectedTime), out var obj)
			&& obj is TimeModel timeModel
			&& timeModel.IsSaved)
		{
			timeCounter = timeModel.Time;
			selectedTime = timeModel;
			timeBackup = TimeSpan.FromSeconds(timeCounter.TotalSeconds);
			UpdateTimer();
		}
	}

	TimeSpan timeCounter = TimeSpan.Zero;
	TimeModel selectedTime;
	TimeSpan timeBackup;
	readonly TimeSpan Time1Second = TimeSpan.FromSeconds(1);
	readonly IDispatcherTimer dispatcherTimer;
}
