using Scryfall.API.Models;
using System.Diagnostics;

namespace MTGHelper.Controls;

public partial class CardVersions : ContentView
{
    public Card Card
    {
        get => (Card)GetValue(CardProperty);
        set => SetValue(CardProperty, value);
    }
    public static readonly BindableProperty CardProperty = BindableProperty.Create(nameof(Card), typeof(Card), typeof(Card), new Card(), BindingMode.TwoWay, propertyChanged: CardChanged);
    private static void CardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        Trace.WriteLine("Loading card versions");
        if (bindable is CardVersions cardVersions && newValue is Card card)
        {
            cardVersions.flexLayoutRoot.Clear();
            Trace.WriteLine($"Card Faces: {card.CardFaces.Count}");
            foreach (CardFace cardFace in card.CardFaces)
            {
                CardVersion cardVersion = new CardVersion();
                cardVersion.BindingContext = cardFace;
                cardVersions.flexLayoutRoot.Add(cardVersion);
            }
        }
    }
    public CardVersions()
	{
		InitializeComponent();
	}
}