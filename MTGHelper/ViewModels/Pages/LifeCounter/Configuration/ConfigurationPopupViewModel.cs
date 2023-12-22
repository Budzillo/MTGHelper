using CommunityToolkit.Mvvm.Input;
using MTGHelper.Helpers;
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
    public partial class ConfigurationPopupViewModel : BaseViewModel
    {
        private LifeCounterPageViewModel lifeCounterPageViewModel;

        private PlayersConfigurationContent playersConfigurationContent;
        public PlayersConfigurationContent PlayersConfigurationContent
        {
            get => playersConfigurationContent;
            set
            {
                if (playersConfigurationContent == value) return;
                playersConfigurationContent = value;
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        private void Close(object sender)
        {
            if(sender is ConfigurationPoupup configurationPoupup)
            {
                SettingsHelper.SaveLifeCounterConfig(lifeCounterPageViewModel);
                lifeCounterPageViewModel.ResetGameCommand.Execute(null);
                configurationPoupup.Close();
            }
        }
        public ConfigurationPopupViewModel() { }
        public ConfigurationPopupViewModel(LifeCounterPageViewModel lifeCounterPageViewModel) 
        {
            this.lifeCounterPageViewModel = lifeCounterPageViewModel;
            PrepareContents();
        }
        private void PrepareContents()
        {
            PlayersConfigurationContentViewModel playersConfigurationContentViewModel = new PlayersConfigurationContentViewModel(PreparePlayers(),lifeCounterPageViewModel.PlayerCount);
            this.PlayersConfigurationContent = new PlayersConfigurationContent();
            this.PlayersConfigurationContent.BindingContext = playersConfigurationContentViewModel;
        }
        private ObservableCollection<PlayerModel> PreparePlayers()
        {
            ObservableCollection<PlayerModel> playerModels = new ObservableCollection<PlayerModel>();
            if (lifeCounterPageViewModel != null)
            {
                playerModels.Add(lifeCounterPageViewModel.Player1);
                playerModels.Add(lifeCounterPageViewModel.Player2);
                playerModels.Add(lifeCounterPageViewModel.Player3);
                playerModels.Add(lifeCounterPageViewModel.Player4);
                playerModels.Add(lifeCounterPageViewModel.Player5);
                playerModels.Add(lifeCounterPageViewModel.Player6);
            }
            return playerModels;
        }
    }
}
