using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public class PlayerConfigurationContentViewModel : BaseViewModel
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
        public PlayerConfigurationContentViewModel() { }    
        public PlayerConfigurationContentViewModel(PlayerModel player) 
        {
            this.Player = player;
        }

    }
}
