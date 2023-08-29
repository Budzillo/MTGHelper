using MtgApiManager.Lib.Model;
using System.Collections.ObjectModel;

namespace MTGHelper.Controls;

public partial class CardListColor : ContentView
{
	private string colorName;
	private string colorImageSource;
	private ObservableCollection<ICard> cards;
	public string ColorName
	{
		get => (string)GetValue(ColorNameProperty);
		set=> SetValue(ColorNameProperty, value);
	}
	public string ColorImageSource
	{
        get => (string)GetValue(ColorImageSourcProperty);
        set => SetValue(ColorImageSourcProperty, value);
    }
	public ObservableCollection<ICard> Cards
	{
        get => (ObservableCollection<ICard>)GetValue(CardsProperty);
        set => SetValue(CardsProperty, value);
    }

	public static readonly BindableProperty ColorNameProperty = BindableProperty.Create(nameof(ColorName),typeof(string),typeof(string),"w",BindingMode.TwoWay,propertyChanged:ColorNameChanged);
	public static readonly BindableProperty ColorImageSourcProperty = BindableProperty.Create(nameof(ColorImageSource),typeof(string),typeof(string),"/Resources/Images/snow.svg",BindingMode.TwoWay, propertyChanged: ColorImageSourceChanged);
	public static readonly BindableProperty CardsProperty = BindableProperty.Create(nameof(Cards), typeof(ObservableCollection<ICard>), typeof(ObservableCollection<ICard>), new ObservableCollection<ICard>(), BindingMode.TwoWay, propertyChanged: CardsChanged);

	private static void ColorNameChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (CardListColor)bindable;
		control.labelColorName.Text = (string)newValue;
	}
    private static void ColorImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CardListColor)bindable;
        control.imageColorIdentity.Source = (string)newValue;
    }
    private static void CardsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CardListColor)bindable;
        control.listViewCardList.ItemsSource = (ObservableCollection<ICard>)newValue;
    }
    public CardListColor()
	{
		InitializeComponent();
	}
}