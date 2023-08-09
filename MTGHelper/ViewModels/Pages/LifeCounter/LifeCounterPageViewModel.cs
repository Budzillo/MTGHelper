using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
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
    public partial class LifeCounterPageViewModel : BaseViewModel
    {
        private int playerCount;
        private int lifeTotal;
        private PlayerModel player1;
        private PlayerModel player2;
        private PlayerModel player3;
        private PlayerModel player4;
        private PlayerModel player5;
        private PlayerModel player6;
        private ContentView lifeTotalContent;
        private ContentView settingsContent;
        public int PlayerCount
        {
            get { return playerCount; }
            set
            {
                if (playerCount == value) return;
                playerCount = value;
                OnPropertyChanged();
            }
        }
        public int LifeTotal
        {
            get { return lifeTotal; }
            set
            {
                if (lifeTotal == value) return;
                lifeTotal = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel Player1
        {
            get => player1;
            set
            {
                if (player1 == value) return;
                player1 = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel Player2
        {
            get => player2;
            set
            {
                if (player2 == value) return;
                player2 = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel Player3
        {
            get => player3;
            set
            {
                if (player3 == value) return;
                player3 = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel Player4
        {
            get => player4;
            set
            {
                if (player4 == value) return;
                player4 = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel Player5
        {
            get => player5;
            set
            {
                if (player5 == value) return;
                player5 = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel Player6
        {
            get => player6;
            set
            {
                if (player6 == value) return;
                player6 = value;
                OnPropertyChanged();
            }
        }
        public ContentView LifeTotalContent
        {
            get { return lifeTotalContent; }
            set
            {
                if (lifeTotalContent == value) return;
                lifeTotalContent = value;
                OnPropertyChanged();
            }
        }
        public ContentView SettingsContent
        {
            get { return settingsContent; }
            set
            {
                if (settingsContent == value) return;
                settingsContent = value;
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        private async Task OpenSettingsWindowAsync(object sender)
        {
            if(sender is ScrollView scrollView)
            {
                int heightFrom = 0;
                int heightTo = 0;
                if (scrollView.HeightRequest == 0)
                {
                    heightFrom = 0;
                    heightTo = 70;
                }
                else
                {
                    heightFrom = 70;
                    heightTo = 0;
                }
                await MainThread.InvokeOnMainThreadAsync(() => {
                    var animation = new Animation(v => scrollView.HeightRequest = v, heightFrom, heightTo);
                    animation.Commit((IAnimatable)scrollView.Parent, "OpenSettingsAnimation",16,500,Easing.Linear);
                });

            }
        }
        [RelayCommand]
        private void ResetGame()
        {
            Player1.ResetValues();
            Player2.ResetValues();
            Player3.ResetValues();
            Player4.ResetValues();
            Player5.ResetValues();
            Player6.ResetValues();
        }
        [RelayCommand]
        private void ChangePlayerCount(string count)
        {
            this.PlayerCount = int.Parse(count);
            PrepareGame();
        }
        [RelayCommand]
        private void ChangeSettingsToPlayers()
        {
            this.SettingsContent = new SettingsPlayersContent();
            this.SettingsContent.BindingContext = this;
        }
        [RelayCommand]
        private void GoBackToSettings()
        {
            PrepareSettings();
        }
        public LifeCounterPageViewModel()
        {
            this.PlayerCount = 4;
            PrepareGame();
            PrepareSettings();
        }
        private void PrepareGame()
        {            
            this.SetFormat("Standard");
            this.PreparePlayers();
            this.PrepareCurrentLifeTotalView();
        }
        private void PrepareSettings()
        {
            SettingsContent settings = new SettingsContent();
            settings.BindingContext = this;
            this.SettingsContent = settings; 
        }
        private void PreparePlayers()
        {
            List<string> colors = new List<string> { "Red", "Blue", "Black","Purple","Pink","Gray" };
            Player1 = new PlayerModel(0, lifeTotal, $"Player {1}", colors[0]);
            Player2 = new PlayerModel(1, lifeTotal, $"Player {2}", colors[1]);
            Player3 = new PlayerModel(2, lifeTotal, $"Player {3}", colors[2]);
            Player4 = new PlayerModel(3, lifeTotal, $"Player {4}", colors[3]);
            Player5 = new PlayerModel(4, lifeTotal, $"Player {5}", colors[4]);
            Player6 = new PlayerModel(5, lifeTotal, $"Player {6}", colors[5]);
        }
        private void SetFormat(string name)
        {
            if (name == "Commander")
                this.LifeTotal = 40;
            else if (name == "Commander Pauper")
                this.LifeTotal = 30;
            else
                this.LifeTotal = 20;

        }
        private void PrepareCurrentLifeTotalView()
        {
            switch (PlayerCount)
            {
                case 2:
                    TwoPlayersLifeCounterContentViewModel twoPlayersLifeCounterContentViewModel = new TwoPlayersLifeCounterContentViewModel(this);
                    TwoPlayersLifeCounterContent twoPlayersContent = new TwoPlayersLifeCounterContent();
                    twoPlayersContent.BindingContext = twoPlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = twoPlayersContent;
                    break;
                case 3:
                    ThreePlayersLifeCounterContentViewModel threePlayersLifeCounterContentViewModel = new ThreePlayersLifeCounterContentViewModel(this);
                    ThreePlayersLifeCounterContent threePlayersContent = new ThreePlayersLifeCounterContent();
                    threePlayersContent.BindingContext = threePlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = threePlayersContent;
                    break;
                case 4:
                    FourPlayersLifeCounterContentViewModel fourPlayersLifeCounterContentViewModel = new FourPlayersLifeCounterContentViewModel(this);
                    FourPlayersLifeCounterContent fourPlayersLifeCounterContent = new FourPlayersLifeCounterContent();
                    fourPlayersLifeCounterContent.BindingContext = fourPlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = fourPlayersLifeCounterContent;
                    break;
            }
        }
    }
}
