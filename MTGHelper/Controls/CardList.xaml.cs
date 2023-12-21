using Scryfall.API.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MTGHelper.Controls;

public partial class CardList : ContentView
{
    private int cardsIndex;
    public ObservableCollection<Card> Cards
    {
        get => (ObservableCollection<Card>)GetValue(CardsProperty);
        set => SetValue(CardsProperty, value);
    }

    public static readonly BindableProperty CardsProperty = BindableProperty.Create(nameof(Cards), typeof(ObservableCollection<Card>), typeof(ObservableCollection<Card>), new ObservableCollection<Card>(), BindingMode.TwoWay, propertyChanged: CardsChanged);

    public CardList()
	{
		InitializeComponent();
	}
    private static void CardsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is CardList cardList && newValue is ObservableCollection<Card> cards)
        {
            cardList.verticalStackLayoutRoot.Children.Clear();
            foreach(var card in cards)
            {
                cardList.verticalStackLayoutRoot.Add(new CardListCard
                {
                    BindingContext = card
                }) ;                
            }
        }
    }
    public void ClearCardIndex()
    {
        this.cardsIndex = 0;
    }
    public void AddCards()
    {
        if (cardsIndex >= Cards.Count) return;
        int cardsToAdd = cardsIndex <= Cards.Count + 20 ? cardsIndex + 20 : Cards.Count - cardsIndex;
        for(int i = cardsIndex;i <= cardsToAdd;i++) 
        {
            if (i >= Cards.Count - 1) return;
            
        }
    }
}