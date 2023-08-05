﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DeskClock.ViewModels
{
	public partial class StopWatchViewModel : ObservableObject
	{
		public StopWatchViewModel(IDispatcher dispatcher)
		{
			dispatcherTimer = dispatcher.CreateTimer();
			dispatcherTimer.Interval = Time100Mills;
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

		void DispatcherTimer_Tick(object sender, EventArgs e)
		{
			timeCounter += Time100Mills;
			UpdateTimer();
		}

		void UpdateTimer()
		{
			TimerNow = timeCounter.ToString(TimerFormat);
		}


		const string TimerFormat = "h':'mm':'ss'.'f";
		readonly TimeSpan Time100Mills = TimeSpan.FromMilliseconds(100);
		TimeSpan timeCounter = TimeSpan.Zero;
		private readonly IDispatcherTimer dispatcherTimer;
	}
}
