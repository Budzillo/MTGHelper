using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MTGHelper.Models;
using MTGHelper.Pages.LifeCounter.Views;
using MTGHelper.Pages.LifeCounter.Views.Dice;
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
        private int playerCount = 4;
        private int lifeTotal = 20;
        private int commanderDamagePlayerIndex = 1;
        private bool isCommanderDamageOpen = false;
        private int diceCount = 1;
        private Popup diceCountPopup = null;    
        private PlayerModel player1;
        private PlayerModel player2;
        private PlayerModel player3;
        private PlayerModel player4;
        private PlayerModel player5;
        private PlayerModel player6;
        private ContentView lifeTotalContent;
        private ContentView settingsContent;
        private DiceRollModel diceRollModel;
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
        public int CommanderDamagePlayerIndex
        {
            get { return commanderDamagePlayerIndex; }
            set
            {
                if (commanderDamagePlayerIndex == value) return;
                commanderDamagePlayerIndex = value;
                OnPropertyChanged();
            }
        }
        public bool IsCommanderDamageOpen
        {
            get => isCommanderDamageOpen;
            set
            {
                if(isCommanderDamageOpen == value) return;
                isCommanderDamageOpen = value;
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
        public DiceRollModel DiceRollModel
        {
            get => diceRollModel;
            set
            {
                if (diceRollModel == value) return;
                diceRollModel = value;
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
                    animation.Commit((IAnimatable)scrollView.Parent, "OpenSettingsAnimation", 16, 500, Easing.Linear, delegate
                    {
                        this.SettingsContent = new SettingsContent();
                        this.SettingsContent.BindingContext = this;
                    });
                });                
            }
        }
        [RelayCommand]
        private void ResetGame()
        {
            Player1.ResetValues(LifeTotal);
            Player2.ResetValues(LifeTotal);
            Player3.ResetValues(LifeTotal);
            Player4.ResetValues(LifeTotal);
            Player5.ResetValues(LifeTotal);
            Player6.ResetValues(LifeTotal);
            RotateLabels();
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
        private void ChangeSettingsToDices()
        {
            this.SettingsContent = new SettingsDiceContent();
            this.SettingsContent.BindingContext = this;
        }
        [RelayCommand]
        private void GoBackToSettings()
        {
            PrepareSettings();
        }
        [RelayCommand]
        private void SetLifeTotal(string value)
        {
            if(int.TryParse(value,out int life))
            {
                this.LifeTotal = life;
                ResetGame();
                RotateLabels();
            }
        }
        [RelayCommand]
        private void ChangeSettingsToLife()
        {
            this.SettingsContent = new SettingsLifeContent();
            this.SettingsContent.BindingContext = this;
        }
        [RelayCommand]
        private async Task RollDice(string diceValue)
        {
            if(int.TryParse(diceValue,out int diceValueInt))
            {
                await OpenSelectDiceCount("dices");
                this.DiceRollModel = new DiceRollModel();
                Popup popup = new Popup();
                List<ContentView> contentViews = new List<ContentView>();
                for(int i = 0; i < diceCount; i++)
                {
                    switch (diceValueInt)
                    {
                        case 6: contentViews.Add(new RollDiceD6Content() { BindingContext = new DiceContentViewModel(new DiceRollModel())}); break;
                        case 8: contentViews.Add(new RollDiceD8Content() { BindingContext = new DiceContentViewModel(new DiceRollModel()) }); break;
                        case 12: contentViews.Add(new RollDiceD12Content() { BindingContext = new DiceContentViewModel(new DiceRollModel()) }); break;
                        case 20: contentViews.Add(new RollDiceD20Content() { BindingContext = new DiceContentViewModel(new DiceRollModel()) }); break;
                    }
                }
                ContentView content = new MultipleDicesContent(contentViews);  
                popup.Content = content;
                popup.Size = PreparePopupSize(this.diceCount);
                Shell.Current.CurrentPage.ShowPopupAsync(popup);
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    foreach(var item in contentViews)
                    {
                        if (item.BindingContext is DiceContentViewModel viewModel)
                            viewModel.DiceRollModel.RollDice(diceValueInt);
                    }
                });
            }
        }

        [RelayCommand]
        private async Task FlipCoin()
        {
            await OpenSelectDiceCount("coin flips");
            this.DiceRollModel = new DiceRollModel();
            Popup popup = new Popup();
            List<ContentView> contentViews = new List<ContentView>();
            for (int i = 0; i < diceCount; i++)
            {
                contentViews.Add(new FlipCoinContent() { BindingContext = new DiceContentViewModel(new DiceRollModel()) });
            }
            ContentView content = new MultipleDicesContent(contentViews);
            popup.Content = content;
            popup.Size = PreparePopupSize(this.diceCount);
            Shell.Current.CurrentPage.ShowPopupAsync(popup);
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                foreach (var item in contentViews)
                {
                    if(item.BindingContext is DiceContentViewModel viewModel && item is FlipCoinContent coinContent)
                        viewModel.DiceRollModel.FlipCoin(coinContent);
                }
            });
        }

        [RelayCommand]
        private async Task RandomFirstPlayer()
        {
            if(this.LifeTotalContent.BindingContext is BasePlayersLifeTotalViewModel viewModel)
            {
                await viewModel.RandomFirstPlayer();
            }
        }
        [RelayCommand]
        private async Task SelectDiceCount(string value)
        {
            if(int.TryParse(value, out var count))
            {
                this.diceCount = count;
            }
            this.diceCountPopup.Close();
        }
        [RelayCommand]
        private async Task OpenSettings()
        {
            ConfigurationPopupViewModel configurationPopupViewModel = new ConfigurationPopupViewModel(this);
            ConfigurationPoupup configurationPopup = new ConfigurationPoupup();            
            configurationPopup.BindingContext = configurationPopupViewModel;
            configurationPopup.Size = new Size(400, 800);
            await Shell.Current.CurrentPage.ShowPopupAsync(configurationPopup);
        }
        private Size PreparePopupSize(int diceCount)
        {
            if (diceCount <= 3)
                return new Size(diceCount * 120, 120);
            else
                return new Size(3 * 100, 240);
        }
        private async Task OpenSelectDiceCount(string diceType)
        {
            this.diceCountPopup = new Popup();
            SelectDiceCountContent content = new SelectDiceCountContent(diceType);
            content.BindingContext = this;
            this.diceCountPopup.Content = content;
            this.diceCountPopup.Size = new Size(300, 100);
            await Shell.Current.CurrentPage.ShowPopupAsync(this.diceCountPopup);
        }
        public LifeCounterPageViewModel()
        {
            PrepareGame();
            PrepareSettings();
        }
        private void PrepareGame()
        {            
           // this.SetFormat("Standard");
            this.PreparePlayers(this.playerCount);
            this.PrepareCurrentLifeTotalView();
        }
        private void PrepareSettings()
        {
            SettingsContent settings = new SettingsContent();
            settings.BindingContext = this;
            this.SettingsContent = settings; 
        }
        private void PreparePlayers(int playersCount)
        {
            List<string> colors = new List<string> { "red", "blue", "black","green","white","Gray" };
            Player1 = new PlayerModel(0, LifeTotal, $"Player {1}", colors[0]);
            Player2 = new PlayerModel(1, LifeTotal, $"Player {2}", colors[1]);
            Player3 = new PlayerModel(2, LifeTotal, $"Player {3}", colors[2]);
            Player4 = new PlayerModel(3, LifeTotal, $"Player {4}", colors[3]);
            Player5 = new PlayerModel(4, LifeTotal, $"Player {5}", colors[4]);
            Player6 = new PlayerModel(5, LifeTotal, $"Player {6}", colors[5]);
        }
        private void RotateLabels()
        {
            if(lifeTotalContent != null && lifeTotalContent.BindingContext is BasePlayersLifeTotalViewModel totalViewModel)
            {
                totalViewModel.RotateLifeTotal();
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
        public void OpenCommanderDamage(int playerIndex)
        {
            this.CommanderDamagePlayerIndex = playerIndex;
            this.IsCommanderDamageOpen = true;
        }
        public void CloseCommanderDamage() 
        {
            this.IsCommanderDamageOpen = false;
        }
        private async void FlashAnimation()
        {
            if(this.LifeTotalContent != null)
            await MainThread.InvokeOnMainThreadAsync(() => {
                var animation = new Animation(v => this.LifeTotalContent.Opacity = v, 0, 1);
                animation.Commit((IAnimatable)this.LifeTotalContent, "ContentFlashAnimation", 16, 600, Easing.Linear);
            });
        }
        private async void PrepareCurrentLifeTotalView()
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
                case 5:
                    FivePlayersLifeCounterContentViewModel fivePlayersLifeCounterContentViewModel = new FivePlayersLifeCounterContentViewModel(this);
                    FivePlayersLifeCounterContent fivePlayersLifeCounterContent = new FivePlayersLifeCounterContent();
                    fivePlayersLifeCounterContent.BindingContext = fivePlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = fivePlayersLifeCounterContent;
                    break;
                case 6:
                    SixPlayersLifeCounterContentViewModel sixPlayersLifeCounterContentViewModel = new SixPlayersLifeCounterContentViewModel(this);
                    SixPlayersLifeCounterContent sixPlayersLifeCounterContent = new SixPlayersLifeCounterContent();
                    sixPlayersLifeCounterContent.BindingContext = sixPlayersLifeCounterContentViewModel;
                    this.LifeTotalContent = sixPlayersLifeCounterContent;
                    break;
            }
            FlashAnimation();
        }
    }
}
