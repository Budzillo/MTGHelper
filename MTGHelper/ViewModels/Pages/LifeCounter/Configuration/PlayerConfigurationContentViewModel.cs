using CommunityToolkit.Mvvm.Input;
using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class PlayerConfigurationContentViewModel : BaseViewModel
    {
        private PlayerModel player;
        public PlayerModel Player
        {
            get => player;
            set
            {
                if (player == value) return;
                player = value;
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        private void ChangeCounterVisibility(string counterName)
        {
            switch(counterName)
            {
                case "poison": this.Player.IsPoisonCounterVisible = !this.Player.IsPoisonCounterVisible; break; 
                case "energy": this.Player.IsEnergyCounterVisible = !this.Player.IsEnergyCounterVisible; break; 
                case "ticket": this.Player.IsTicketCounterVisible = !this.Player.IsTicketCounterVisible; break; 
            }
        }
        [RelayCommand]
        private void SetColor(string color)
        {
            this.Player.SetColor(color);
        }
        public PlayerConfigurationContentViewModel() { }    
        public PlayerConfigurationContentViewModel(PlayerModel player) 
        {
            this.Player = player;
        }

    }
}
