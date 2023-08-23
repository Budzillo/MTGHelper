using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static MTGHelper.ClassConst;

namespace MTGHelper.ViewModels
{
    public partial class PlayerLifeTotalViewModel : BaseViewModel
    {
        private LifeCounterPageViewModel lifeCounterPageViewModel;
        private int playerIndex = 1;
        private int rotation;
        public PlayerModel PlayerModel
        {
            get => GetPlayerModel();
            set
            {
                PlayerModel tempPlayer = GetPlayerModel();
                if (tempPlayer == value) return;
                tempPlayer = value;
                OnPropertyChanged(nameof(PlayerModel));
            }
        }
        public int Rotation
        {
            get { return rotation; }
            set
            {
                if (rotation == value) return;
                rotation = value;
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        public void SetNumberType(string counterName)
        { 
            GetPlayerModel().SelectCounterType(GetCounterTypeByName(counterName));           
        }
        private void SetNumberTypeByEnum(COUNTER_TYPES counterType)
        {
            SetNumberType(GetCounterNameByType(counterType));
        }
        private string GetCounterNameByType(COUNTER_TYPES counterType)
        {
            switch (counterType)
            {
                case COUNTER_TYPES.LIFE:
                    return ClassConst.LIFE_COUNTER_NAME;
                case COUNTER_TYPES.POISON:
                    return ClassConst.POISON_COUNTER_NAME;
                case COUNTER_TYPES.ENERGY:
                    return ClassConst.ENERGY_COUNTER_NAME;
                case COUNTER_TYPES.TICKETS:
                    return ClassConst.TICKETS_COUNTER_NAME;
                default:
                    Trace.WriteLine("Unknown counter");
                    return "UNKOWN COUNTER";
            }
        }
        private COUNTER_TYPES GetCounterTypeByName(string counter_Name)
        {
            switch (counter_Name)
            {
                case ClassConst.LIFE_COUNTER_NAME:
                    return COUNTER_TYPES.LIFE;
                case ClassConst.POISON_COUNTER_NAME:
                    return COUNTER_TYPES.POISON;
                case ClassConst.ENERGY_COUNTER_NAME:
                    return COUNTER_TYPES.ENERGY;
                case ClassConst.TICKETS_COUNTER_NAME:
                    return COUNTER_TYPES.TICKETS;
                default:
                    return COUNTER_TYPES.UNKOWN;
            }
        }
        public void GridTappedVertical(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (tappedEventArgs.GetPosition(grid).Value.Y <= grid.Height / 2)
            {
                Increase();
            }
            else Decrease();
        }
        public void GridTappedHorizontal(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (tappedEventArgs.GetPosition(grid).Value.X >= grid.Width / 2)
            {
                Increase();
            }
            else Decrease();
        }
        private void Decrease()
        {
            GetPlayerModel().Decrease();
        }
        private void Increase()
        {
            GetPlayerModel().Increase();
        }
        [RelayCommand]
        public void AddLifeClicked()
        {
            GetPlayerModel().AddLife();
        }
        [RelayCommand]
        public void MinusLifeClicked()
        {
            GetPlayerModel().MinusLife();
        }
        public PlayerLifeTotalViewModel()
        {

        }
        public PlayerLifeTotalViewModel(LifeCounterPageViewModel lifeCounterPageViewModel, int playerIndex, int rotation = 0)
        {
            this.playerIndex = playerIndex;
            this.lifeCounterPageViewModel = lifeCounterPageViewModel;
            this.Rotation = rotation;            
            SetNumberTypeByEnum(COUNTER_TYPES.LIFE);
            Initialize();
            PrepareCommands();
        }
        private void Initialize()
        {

        }
        private void PrepareCommands()
        {

        }
        public PlayerModel GetPlayerModel()
        {
            if (lifeCounterPageViewModel == null) return new PlayerModel();
            switch (playerIndex)
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
