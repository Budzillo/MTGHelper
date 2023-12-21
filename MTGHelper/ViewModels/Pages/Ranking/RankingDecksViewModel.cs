using CommunityToolkit.Mvvm.Input;
using Microsoft.Rest;
using MTGApi.Repository;
using MTGApi.ScryfallRepository;
using MTGHelper.Models;
using Scryfall.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class RankingDecksViewModel : BaseViewModel
    {
        private ObservableCollection<PlayerRankingModel> playerRankings = new ObservableCollection<PlayerRankingModel>();   
        private bool isAddPlayerOpen = false;
        private PlayerRankingModel playerRankingToAdd;
        public ObservableCollection<PlayerRankingModel> PlayerRankings
        {
            get => playerRankings;
            set
            {
                if(value == playerRankings) return;
                playerRankings = value;
                OnPropertyChanged();
            }
        }
        public bool IsAddPlayerOpen
        {
            get => isAddPlayerOpen;
            set
            {
                if (isAddPlayerOpen == value) return;
                isAddPlayerOpen = value;
                OnPropertyChanged();
            }
        }
        public PlayerRankingModel PlayerRankingToAdd
        {
            get => playerRankingToAdd;
            set
            {
                if (playerRankingToAdd == value) return;
                playerRankingToAdd = value;
                OnPropertyChanged();
            }
        }    
        
        [RelayCommand]
        private void AddPlayerRanking()
        {
            this.PlayerRankingToAdd = new PlayerRankingModel();
            this.IsAddPlayerOpen = true;
        }
        [RelayCommand]
        private void InsertPlayerRanking()
        {
            this.PlayerRankings.Add(this.PlayerRankingToAdd);
            this.PlayerRankings = new ObservableCollection<PlayerRankingModel>(PlayerRankings);
        }
        public RankingDecksViewModel()
        {
            this.PlayerRankingToAdd = new PlayerRankingModel();

        }
    }
}
