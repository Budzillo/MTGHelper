using Scryfall.API.Models;
using System.Diagnostics;

namespace MTGHelper.Controls;

public partial class CardPrices : ContentView
{
    public Card Card
    {
        get => (Card)GetValue(CardProperty);
        set => SetValue(CardProperty, value);
    }
    public static readonly BindableProperty CardProperty = BindableProperty.Create(nameof(Card), typeof(Card), typeof(Card), new Card(), BindingMode.TwoWay, propertyChanged: CardChanged);

    private static void CardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CardPrices cardPrices && newValue is Card card)
        {
            cardPrices.labelPriceEuro.Text = $"{card.Prices?.Euro} €";
            cardPrices.labelPriceEuroFoil.Text = $"{card.Prices?.EuroFoil} €";
            cardPrices.labelPriceEuroEtched.Text = $"{card.Prices?.EuroEtched} €";

            cardPrices.labelPriceUSD.Text = $"{card.Prices?.Usd} $";
            cardPrices.labelPriceUSDFoil.Text = $"{card.Prices?.UsdFoil} $";
            cardPrices.labelPriceUSDEtched.Text = $"{card.Prices?.UsdEtched} $";
        }
    }
    public CardPrices()
	{
		InitializeComponent();
	}
}