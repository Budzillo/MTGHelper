using MTGHelper.Models;
using System.Collections.ObjectModel;

namespace MTGHelper.Controls;

public partial class PlayerForRankingList : ContentView
{
    public ObservableCollection<PlayerRankingModel> PlayerRankingModels
    {
        get => (ObservableCollection<PlayerRankingModel>) GetValue(PlayerRankingModelsProperty);
        set => SetValue(PlayerRankingModelsProperty, value);
    }
    public static readonly BindableProperty PlayerRankingModelsProperty = BindableProperty.Create(nameof(ObservableCollection<PlayerRankingModel>), typeof(ObservableCollection<PlayerRankingModel>), typeof(ObservableCollection<PlayerRankingModel>), new ObservableCollection<PlayerRankingModel>(), BindingMode.TwoWay, propertyChanged: PlayerRankingModelsChanged);

    private static void PlayerRankingModelsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is PlayerForRankingList playerForRankingList && newValue is ObservableCollection<PlayerRankingModel> playerRankingModels)
        {
            playerForRankingList.mainVerticalStackLayout.Children.Clear();
            foreach(PlayerRankingModel playerRankingModel in playerRankingModels)
            {
                PlayerForRanking playerForRanking = new PlayerForRanking();
                playerForRanking.PlayerRankingModel = playerRankingModel;
                playerForRankingList.mainVerticalStackLayout.Children.Add(playerForRanking);
            }
        }
    }

    public PlayerForRankingList()
	{
		InitializeComponent();
	}
}