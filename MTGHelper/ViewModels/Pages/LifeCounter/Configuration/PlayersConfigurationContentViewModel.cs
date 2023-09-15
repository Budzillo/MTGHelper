using MTGHelper.Models;
using MTGHelper.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public class PlayersConfigurationContentViewModel : BaseViewModel
    {
        private ObservableCollection<PlayerModel> players;
        private int playerCount = 0;

        private PlayerConfigurationContent player1ConfigurationContent;
        private PlayerConfigurationContent player2ConfigurationContent;
        private PlayerConfigurationContent player3ConfigurationContent;
        private PlayerConfigurationContent player4ConfigurationContent;
        private PlayerConfigurationContent player5ConfigurationContent;
        private PlayerConfigurationContent player6ConfigurationContent;
        public PlayerConfigurationContent Player1ConfigurationContent
        {
            get => player1ConfigurationContent;
            set
            {
                if(player1ConfigurationContent == value) return;
                player1ConfigurationContent = value;
                OnPropertyChanged();
            }
        }
        public PlayerConfigurationContent Player2ConfigurationContent
        {
            get => player2ConfigurationContent;
            set
            {
                if (player2ConfigurationContent == value) return;
                player2ConfigurationContent = value;
                OnPropertyChanged();
            }
        }
        public PlayerConfigurationContent Player3ConfigurationContent
        {
            get => player3ConfigurationContent;
            set
            {
                if (player3ConfigurationContent == value) return;
                player3ConfigurationContent = value;
                OnPropertyChanged();
            }
        }
        public PlayerConfigurationContent Player4ConfigurationContent
        {
            get => player4ConfigurationContent;
            set
            {
                if (player4ConfigurationContent == value) return;
                player4ConfigurationContent = value;
                OnPropertyChanged();
            }
        }
        public PlayerConfigurationContent Player5ConfigurationContent
        {
            get => player5ConfigurationContent;
            set
            {
                if (player5ConfigurationContent == value) return;
                player5ConfigurationContent = value;
                OnPropertyChanged();
            }
        }
        public PlayerConfigurationContent Player6ConfigurationContent
        {
            get => player6ConfigurationContent;
            set
            {
                if (player6ConfigurationContent == value) return;
                player6ConfigurationContent = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PlayerModel> Players
        {
            get => players;
            set
            {
                if (players == value) return;
                players = value;
                OnPropertyChanged();
            }
        }
        public int PlayerCount
        {
            get => playerCount;
            set
            {
                if (playerCount == value) return;
                playerCount = value;
                OnPropertyChanged();
            }
        }
        public bool IsPlayer1Visible
        {
            get => playerCount >= 1;
        }
        public bool IsPlayer2Visible
        {
            get => playerCount >= 2;
        }
        public bool IsPlayer3Visible
        {
            get => playerCount >= 3;
        }
        public bool IsPlayer4Visible
        {
            get => playerCount >= 4;
        }
        public bool IsPlayer5Visible
        {
            get => playerCount >= 5;
        }
        public bool IsPlayer6Visible
        {
            get => playerCount >= 6;
        }

        public PlayersConfigurationContentViewModel()
        {

        }
        public PlayersConfigurationContentViewModel(ObservableCollection<PlayerModel> players,int playerCount)
        {
            this.Players = players;
            this.PlayerCount = playerCount; 
            PreparePlayerConfigurationContents();
        }
        private void PreparePlayerConfigurationContents()
        {
            if(this.Players != null && this.Players.Count == 6)
            {
                PlayerConfigurationContentViewModel player1ViewModel = new PlayerConfigurationContentViewModel(this.Players[0]);
                this.Player1ConfigurationContent = new PlayerConfigurationContent();
                this.Player1ConfigurationContent.BindingContext = player1ViewModel;
                PlayerConfigurationContentViewModel player2ViewModel = new PlayerConfigurationContentViewModel(this.Players[1]);
                this.Player2ConfigurationContent = new PlayerConfigurationContent();
                this.Player2ConfigurationContent.BindingContext = player2ViewModel;
                PlayerConfigurationContentViewModel player3ViewModel = new PlayerConfigurationContentViewModel(this.Players[2]);
                this.Player3ConfigurationContent = new PlayerConfigurationContent();
                this.Player3ConfigurationContent.BindingContext = player3ViewModel;
                PlayerConfigurationContentViewModel player4ViewModel = new PlayerConfigurationContentViewModel(this.Players[3]);
                this.Player4ConfigurationContent = new PlayerConfigurationContent();
                this.Player4ConfigurationContent.BindingContext = player4ViewModel;
                PlayerConfigurationContentViewModel player5ViewModel = new PlayerConfigurationContentViewModel(this.Players[4]);
                this.Player5ConfigurationContent = new PlayerConfigurationContent();
                this.Player5ConfigurationContent.BindingContext = player5ViewModel;
                PlayerConfigurationContentViewModel player6ViewModel = new PlayerConfigurationContentViewModel(this.Players[5]);
                this.Player6ConfigurationContent = new PlayerConfigurationContent();
                this.Player6ConfigurationContent.BindingContext = player6ViewModel;
            }
        }
    }
}
