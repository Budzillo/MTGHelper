using MtgApiManager.Lib.Model;
using Scryfall.API.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MTGHelper.Controls;

public partial class CardSearchResult : ContentView
{
    public ObservableCollection<Card> Cards
    {
        get => (ObservableCollection<Card>)GetValue(CardsProperty);
        set => SetValue(CardsProperty, value);
    }

    public static readonly BindableProperty CardsProperty = BindableProperty.Create(nameof(Cards), typeof(ObservableCollection<Card>), typeof(ObservableCollection<Card>), new ObservableCollection<Card>(), BindingMode.TwoWay, propertyChanged: CardsChanged);

    private static void CardsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CardSearchResult cardSearchResult && newValue is ObservableCollection<Card> cards)
        {
           cardSearchResult.mainVerticalStackLayout.Children.Clear();
           foreach (Card card in cards)
            {
                CardNoDetails cardNoDetails = new CardNoDetails();
                cardNoDetails.Card = card;
                cardSearchResult.mainVerticalStackLayout.Children.Add(cardNoDetails);
            }
        }
    }
    public CardSearchResult()
	{
		InitializeComponent();
	}
}