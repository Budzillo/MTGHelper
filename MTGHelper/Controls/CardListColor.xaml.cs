namespace MTGHelper.Controls;

public partial class CardListColor : ContentView
{
	private string colorName;
	private string colorImageSource;
	public string ColorName
	{
		get=>colorName; set => colorName = value;
	}
	public string ColorImageSource
	{
		get=> colorImageSource; set => colorImageSource = value;
	}

	public static readonly BindableProperty ColorImageSourceProperty = BindableProperty.Create(nameof(ColorImageSource),typeof(string),typeof(string),"/Resources/Images/colors/white.svg",BindingMode.TwoWay);
	public CardListColor()
	{
		InitializeComponent();
	}
}