namespace DeskClock.Pages;

public partial class NumberSelectionView : ContentView
{
	public NumberSelectionView()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty HeaderProperty
		= BindableProperty.Create(nameof(Header), typeof(string), typeof(NumberSelectionView));

	public static readonly BindableProperty NumberValueProperty
		= BindableProperty.Create(nameof(NumberValue), typeof(int), typeof(NumberSelectionView), defaultBindingMode: BindingMode.TwoWay);

	public static readonly BindableProperty MaxValueProperty
		= BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(NumberSelectionView));

	public static readonly BindableProperty MinValueProperty
		= BindableProperty.Create(nameof(MinValue), typeof(int), typeof(NumberSelectionView));

	public string Header
	{
		get => (string)GetValue(HeaderProperty);
		set => SetValue(HeaderProperty, value);
	}

	public int NumberValue
	{
		get => (int)GetValue(NumberValueProperty);
		set => SetValue(NumberValueProperty, value);
	}

	public int MaxValue
	{
		get => (int)GetValue(MaxValueProperty);
		set => SetValue(MaxValueProperty, value);
	}

	public int MinValue
	{
		get => (int)GetValue(MinValueProperty);
		set => SetValue(MinValueProperty, value);
	}

	void Increment_Clicked(object sender, EventArgs e)
	{
		if (NumberValue < MaxValue)
		{
			NumberValue++;
		}
	}

	void Decrement_Clicked(object sender, EventArgs e)
	{
		if (NumberValue > MinValue)
		{
			NumberValue--;
		}
	}
}