using MTGHelper.Models;
using Scryfall.API.Models;
using System.Diagnostics;

namespace MTGHelper.Controls;

public partial class PlayerForRanking : ContentView
{
    public DeckRankingModel DeckRankingModel { get; set; } = new DeckRankingModel();
    public string CommanderName { get; set; }
    public PlayerRankingModel PlayerRankingModel
    {
        get => (PlayerRankingModel)GetValue(PlayerRankingModelProperty);
        set => SetValue(PlayerRankingModelProperty, value);
    }
    public static readonly BindableProperty PlayerRankingModelProperty = BindableProperty.Create(nameof(PlayerRankingModel), typeof(PlayerRankingModel), typeof(PlayerRankingModel), new PlayerRankingModel(), BindingMode.TwoWay, propertyChanged: PlayerRankingModelChanged);

    private static void PlayerRankingModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is PlayerForRanking playerForRanking && newValue is PlayerRankingModel playerRankingModel)
        {            
            playerForRanking.verticalStackLayoutDeckList.IsVisible = playerRankingModel.IsDeckListShow;
            playerForRanking.labelName.Text = playerRankingModel.Name;
            playerForRanking.labelDeckCount.Text = playerRankingModel.DeckCount.ToString();
            playerForRanking.labelTournamentWins.Text = playerRankingModel.TournamentWins.ToString();
            playerForRanking.verticalStackLayoutDeckList.Children.Clear();

            foreach(DeckRankingModel deckRankingModel in playerRankingModel.DeckRankingModels)
            {
                DeckForRanking deckForRanking = new DeckForRanking();
                deckForRanking.DeckRankingModel = deckRankingModel;
                playerForRanking.verticalStackLayoutDeckList.Children.Add(deckForRanking);
            }
            
        }        
    }

    public PlayerForRanking()
	{
		InitializeComponent();
	}

    private void imageButtonShow_Clicked(object sender, EventArgs e)
    {
        if(this.PlayerRankingModel != null)
        {
            this.PlayerRankingModel.IsDeckListShow = !this.PlayerRankingModel.IsDeckListShow;
        }
    }

    private void buttonAddDeck_Clicked(object sender, EventArgs e)
    {
        if(this.PlayerRankingModel != null)
        {
            this.PlayerRankingModel.DeckRankingModels.Add(this.DeckRankingModel);
        }
    }

    private void selectCommander_Clicked(object sender, EventArgs e)
    {
        if(this.carouselViewCommanders.CurrentItem is Card card)
        {
            this.DeckRankingModel.CommanderImage = card.ImageUris.Png;
            this.DeckRankingModel.Colors = card.Colors.ToList();
            this.DeckRankingModel.Id = this.PlayerRankingModel.DeckCount + 1;
            this.DeckRankingModel.Deck = new DeckModel();
        }
    }
}