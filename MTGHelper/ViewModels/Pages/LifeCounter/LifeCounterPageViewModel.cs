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
        private ObservableCollection<PlayerModel> players = new ObservableCollection<PlayerModel>();
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
        public ObservableCollection<PlayerModel> Players
        {
            get { return players; }
            set
            {
                if(players == value) return;
                players = value;
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
            PrepareGame();
        }
        [RelayCommand]
        private void ChangePlayerCount(int count)
        {
            this.PlayerCount = count;
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
            PrepareGame();
            PrepareSettings();
        }
        private void PrepareGame()
        {
            this.PlayerCount = 4;
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
            List<string> colors = new List<string> { "Red", "Blue", "Black","Purple","Pink" };
            this.Players = new ObservableCollection<PlayerModel>();
            for(int i = 0;i < playerCount; i++)
            {
                this.Players.Add(new PlayerModel(i, lifeTotal, $"Player {i + 1}", colors[i]));
            }
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
                    TwoPlayersLifeCounterContentViewModel twoPlayersLifeCounterContentViewModel = new TwoPlayersLifeCounterContentViewModel(this.players);
                    TwoPlayersLifeCounterContent twoPlayersContent = new TwoPlayersLifeCounterContent();
                    twoPlayersContent.BindingContext = twoPlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = twoPlayersContent;
                    break;
                case 3:
                    ThreePlayersLifeCounterContentViewModel threePlayersLifeCounterContentViewModel = new ThreePlayersLifeCounterContentViewModel(this.players);
                    ThreePlayersLifeCounterContent threePlayersContent = new ThreePlayersLifeCounterContent();
                    threePlayersContent.BindingContext = threePlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = threePlayersContent;
                    break;
                case 4:
                    FourPlayersLifeCounterContentViewModel fourPlayersLifeCounterContentViewModel = new FourPlayersLifeCounterContentViewModel(this.players);
                    FourPlayersLifeCounterContent fourPlayersLifeCounterContent = new FourPlayersLifeCounterContent();
                    fourPlayersLifeCounterContent.BindingContext = fourPlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = fourPlayersLifeCounterContent;
                    break;
            }
        }
    }
}
