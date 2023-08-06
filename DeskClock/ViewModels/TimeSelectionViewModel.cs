using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeskClock.Models;

namespace DeskClock.ViewModels;

//[QueryProperty(nameof(SelectedTime), nameof(SelectedTime))]
public partial class TimeSelectionViewModel : ObservableObject, IQueryAttributable
{
	[ObservableProperty]
	int hours;

	[ObservableProperty]
	int minutes;

	[ObservableProperty]
	int seconds;

	[ObservableProperty]
	TimeModel selectedTime;

	[RelayCommand]
	async Task Saved()
	{
		if (SelectedTime is null)
		{
			SelectedTime = new TimeModel();
		}
		SelectedTime.IsSaved = true;
		SelectedTime.Time = new TimeSpan(Hours, Minutes, Seconds);
		//Time.Time = new TimeSpan(ToInt(Hours), ToInt(Minutes), ToInt(Seconds));

		await Shell.Current.GoToAsync("..", new Dictionary<string, object>
			{
				{ nameof(SelectedTime), SelectedTime}
			});
	}

	[RelayCommand]
	async Task Cancelled()
	{
		if (SelectedTime is null)
		{
			SelectedTime = new TimeModel();
		}
		SelectedTime.IsSaved = false;
		await Shell.Current.GoToAsync("..");
	}

	void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if (query.TryGetValue(nameof(SelectedTime), out var obj)
			&& obj is TimeModel timeModel)
		{
			var timeCounter = timeModel.Time;
			Hours = (int)timeCounter.TotalHours;
			Minutes = timeCounter.Minutes;
			Seconds = timeCounter.Seconds;
		}
	}



	//int ToInt(string intInString)
	//{
	//	int.TryParse(intInString, out var value);
	//	return value;
	//}
}
