using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using MtgApiManager.Lib.Model;
using Scryfall.API.Models;
using System.Collections.ObjectModel;

namespace MTGHelper.Controls;

public partial class CardNoDetails : ContentView
{
    public Card Card
    {
        get => (Card)GetValue(CardProperty);
        set => SetValue(CardProperty, value);
    }
    public static readonly BindableProperty CardProperty = BindableProperty.Create(nameof(Card), typeof(Card), typeof(Card),new Card(), BindingMode.TwoWay, propertyChanged: CardChanged);

    private static void CardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is CardNoDetails cardNoDetails && newValue is Card card)
        {
            cardNoDetails.labelCardName.Text = card.Name;
            cardNoDetails.labelCardManaCost.Text = card.ManaCost;
            cardNoDetails.labelCardOracleText.Text = card.OracleText;
            cardNoDetails.labelCardPowerThougness.Text = $"{card.Power}/{card.Toughness}";
            cardNoDetails.labelCardType.Text = card.TypeLine;
            cardNoDetails.cardImage.Source = new UriImageSource
            {
                CacheValidity = new TimeSpan(1),
                CachingEnabled = true,
                Uri = new Uri(card.ImageUris.Png)
            };
        }
    }

    public CardNoDetails()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Popup popup = new Popup();
        popup.Size = new Size(400, 700);
        CardDetails cardDetailsContent = new CardDetails();
        cardDetailsContent.BindingContext = Card;
        popup.Content = cardDetailsContent;
        Shell.Current.CurrentPage.ShowPopup(popup);
    }
}