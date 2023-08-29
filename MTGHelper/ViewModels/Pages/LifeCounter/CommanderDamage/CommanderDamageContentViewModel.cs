using CommunityToolkit.Mvvm.Input;
using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class CommanderDamageContentViewModel : BaseViewModel
    {
        private int playerIndex = 1;
        private int commanderDamageDealerIndex = 1;
        private LifeCounterPageViewModel lifeCounterPageViewModel;
        private bool isCommanderDamageYours = false;
        public bool IsCommanderDamageYours
        {
            get => isCommanderDamageYours;
            set
            {
                if(isCommanderDamageYours == value) return;
                isCommanderDamageYours = value;
                OnPropertyChanged();
            }
        }
        public int PlayerCommanderDamage
        {
            get => GetPlayerModel().CommanderDamagesModel.GetDamage(playerIndex);
            set
            {
                PlayerModel tempPlayer = GetPlayerModel();
                if (tempPlayer.CommanderDamagesModel == null) return;
                if (tempPlayer.CommanderDamagesModel.GetDamage(playerIndex) == value) return;
                tempPlayer.CommanderDamagesModel.SetDamage(playerIndex,value);
                OnPropertyChanged(nameof(PlayerCommanderDamage));
            }
        }
        public void GridTappedVertical(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (isCommanderDamageYours) return;
            if (tappedEventArgs.GetPosition(grid).Value.Y <= grid.Height / 2)
            {
                GetPlayerModel().CommanderDamagesModel.IncreaseDamage(playerIndex);
            }
            else GetPlayerModel().CommanderDamagesModel.DecreaseDamage(playerIndex);

        }
        public void GridTappedHorizontal(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (isCommanderDamageYours) return;
            if (tappedEventArgs.GetPosition(grid).Value.X >= grid.Width / 2)
            {
                GetPlayerModel().CommanderDamagesModel.IncreaseDamage(playerIndex);
            }
            else GetPlayerModel().CommanderDamagesModel.DecreaseDamage(playerIndex);
        }
        public void GridTappedHorizontalReverse(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (isCommanderDamageYours) return;
            if (tappedEventArgs.GetPosition(grid).Value.X <= grid.Width / 2)
            {
                GetPlayerModel().CommanderDamagesModel.IncreaseDamage(playerIndex);
            }
            else GetPlayerModel().CommanderDamagesModel.DecreaseDamage(playerIndex);
        }
        [RelayCommand]
        public void EndCommanderDamage()
        {

        }
        public CommanderDamageContentViewModel() 
        {

        }
        public CommanderDamageContentViewModel(int playerIndex, LifeCounterPageViewModel lifeCounterPageViewModel)
        {
            this.playerIndex = playerIndex;
            this.lifeCounterPageViewModel = lifeCounterPageViewModel;
        }
        public void SetCommanderDamageDealerIndex(int index)
        {
            this.commanderDamageDealerIndex = index;
            if (playerIndex == commanderDamageDealerIndex)
            {
                isCommanderDamageYours = true;
            }
            else isCommanderDamageYours = false;
            OnPropertyChanged(nameof(PlayerCommanderDamage));
        }
        private PlayerModel GetPlayerModel()
        {
            if (lifeCounterPageViewModel == null) return new PlayerModel();
            switch (commanderDamageDealerIndex)
            {
                case 1:
                    return lifeCounterPageViewModel.Player1;
                case 2:
                    return lifeCounterPageViewModel.Player2;
                case 3:
                    return lifeCounterPageViewModel.Player3;
                case 4:
                    return lifeCounterPageViewModel.Player4;
                case 5:
                    return lifeCounterPageViewModel.Player5;
                case 6:
                    return lifeCounterPageViewModel.Player6;
                default: return new PlayerModel();
            }
        }
    }
}
