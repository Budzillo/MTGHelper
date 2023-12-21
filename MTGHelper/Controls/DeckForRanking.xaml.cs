using MTGHelper.Models;
using System.Runtime.CompilerServices;

namespace MTGHelper.Controls;

public partial class DeckForRanking : ContentView
{
    public DeckRankingModel DeckRankingModel
    {
        get => (DeckRankingModel)GetValue(DeckRankingModelProperty);
        set => SetValue(DeckRankingModelProperty, value);
    }
    public static readonly BindableProperty DeckRankingModelProperty = BindableProperty.Create(nameof(DeckRankingModel), typeof(DeckRankingModel), typeof(DeckRankingModel), new DeckRankingModel(), BindingMode.TwoWay, propertyChanged: DeckRankingModelChanged);

    private static void DeckRankingModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is DeckForRanking deckForRanking && newValue is DeckRankingModel deckRankingModel)
        {
            if(deckRankingModel != null)
            {
                deckForRanking.imageCommander.Source = new UriImageSource
                {
                    Uri = deckRankingModel.CommanderImageUri,
                    CacheValidity = new TimeSpan(1),
                    CachingEnabled = true,
                };
                deckForRanking.labelCommanderName.Text = deckRankingModel.CommanderName;
                deckForRanking.labelPowerLevel.Text = deckRankingModel.PowerLevel;

                foreach(Scryfall.API.Models.Colors color in deckRankingModel.Colors)
                {
                    switch(color)
                    {
                        case Scryfall.API.Models.Colors.R:
                            AddColorImageToStack(deckForRanking.horizontalStackLayoutColors, "red");
                            break;
                        case Scryfall.API.Models.Colors.W:
                            AddColorImageToStack(deckForRanking.horizontalStackLayoutColors, "white");
                            break;
                        case Scryfall.API.Models.Colors.B:
                            AddColorImageToStack(deckForRanking.horizontalStackLayoutColors, "blue");
                            break;
                        case Scryfall.API.Models.Colors.G:
                            AddColorImageToStack(deckForRanking.horizontalStackLayoutColors, "green");
                            break;
                        case Scryfall.API.Models.Colors.U:
                            AddColorImageToStack(deckForRanking.horizontalStackLayoutColors, "black");
                            break;

                    }
                }
            }
        }
    }
    private static void AddColorImageToStack(HorizontalStackLayout stackLayout,string colorString)
    {
        Image image = new Image
        {
           Source = new UriImageSource
           {
               Uri = new Uri($"/Resources/Images/colors/{colorString}.svg")
           },
           WidthRequest = 20,
           Margin = 2
        };
        stackLayout.Children.Add(image);
    }

    public DeckForRanking()
	{
		InitializeComponent();
	}
}