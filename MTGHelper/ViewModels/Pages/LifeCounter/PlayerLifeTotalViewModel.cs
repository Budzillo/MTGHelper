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


        private string bottomImageSource = ClassConst.HEART_IMAGE_NAME;
        private PlayerModel playerModel = new PlayerModel();
        private bool isLifeSelected = true;
        private bool isPoisonSelected = false;
        private bool isEnergySelected = false;
        private bool isTicketsSelected = false;
        private string currentNumberValue = string.Empty;
        private int rotation;
        public string BottomImageSource
        {
            get { return bottomImageSource; }
            set
            {
                if (bottomImageSource == value) return;
                bottomImageSource = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel PlayerModel
        {
            get { return playerModel; }
            set
            {
                if (playerModel == value) return;
                playerModel = value;
                OnPropertyChanged();
            }
        }
        public bool IsLifeSelected
        {
            get { return isLifeSelected; }
            set
            {
                if (isLifeSelected == value) return;
                isLifeSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsPoisonSelected
        {
            get { return isPoisonSelected; }
            set
            {
                if (isPoisonSelected == value) return;
                isPoisonSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnergySelected
        {
            get { return isEnergySelected; }
            set
            {
                if (isEnergySelected == value) return;
                isEnergySelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsTicketsSelected
        {
            get { return isTicketsSelected; }
            set
            {
                if(isTicketsSelected == value) return;
                isTicketsSelected = value;
                OnPropertyChanged();
            }
        }
        public string CurrentNumberValue
        {
            get { return currentNumberValue; }
            set
            {
                if (currentNumberValue == value) return;
                currentNumberValue = value; 
                OnPropertyChanged();
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
            switch(GetCounterTypeByName(counterName)) 
            {
                case COUNTER_TYPES.LIFE:
                    IsLifeSelected = true;
                    IsPoisonSelected = false;
                    IsEnergySelected = false;
                    IsTicketsSelected = false;
                    BottomImageSource = ClassConst.HEART_IMAGE_NAME;
                    SetCurrentNumberValue(PlayerModel.Life);
                    break;
                case COUNTER_TYPES.POISON:
                    IsLifeSelected = false;
                    IsPoisonSelected = true;
                    IsEnergySelected = false;
                    IsTicketsSelected = false;
                    BottomImageSource = ClassConst.POISON_COUNTER_IMAGE_NAME;
                    SetCurrentNumberValue(PlayerModel.PoisonCounter);
                    break;
                case COUNTER_TYPES.ENERGY:
                    IsLifeSelected = false;
                    IsPoisonSelected = false;
                    IsEnergySelected = true;
                    IsTicketsSelected = false;
                    BottomImageSource = ClassConst.ENERGY_COUNTER_IMAGE_NAME;
                    SetCurrentNumberValue(PlayerModel.EnergyCounter);
                    break;
                case COUNTER_TYPES.TICKETS:
                    IsLifeSelected = false;
                    IsPoisonSelected = false;
                    IsEnergySelected = false;
                    IsTicketsSelected = true;
                    BottomImageSource = ClassConst.TICKETS_COUNTER_IMAGE_NAME;
                    SetCurrentNumberValue(PlayerModel.TicketsCounter);
                    break;
            }
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
        public void GridTapped(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (tappedEventArgs.GetPosition(grid).Value.Y <= grid.Height / 2)
            {
                Increase();
            }
            else Decrease();
            if (isLifeSelected) SetCurrentNumberValue(this.PlayerModel.Life);
            if (isPoisonSelected) SetCurrentNumberValue(this.PlayerModel.PoisonCounter);
            if (isEnergySelected) SetCurrentNumberValue(this.PlayerModel.EnergyCounter);
            if (isTicketsSelected) SetCurrentNumberValue(this.PlayerModel.TicketsCounter);
        }
        private void SetCurrentNumberValue(int value)
        {
            this.CurrentNumberValue = $"{value}";
        }
        private void Decrease()
        {
            if (isLifeSelected) this.PlayerModel.MinusLife();
            if (isPoisonSelected) this.PlayerModel.MinusPoisonCounter();
            if (isEnergySelected) this.PlayerModel.MinusEnergyCounter();
            if (isTicketsSelected) this.PlayerModel.MinusTicketsCounter();
        }
        private void Increase()
        {
            if (isLifeSelected) this.PlayerModel.AddLife();
            if (isPoisonSelected) this.PlayerModel.AddPoisonCounter();
            if (isEnergySelected) this.PlayerModel.AddEnergyCounter();
            if (isTicketsSelected) this.PlayerModel.AddTicketsCounter();
        }
        [RelayCommand]
        public void AddLifeClicked()
        {
            this.PlayerModel.AddLife();
        }
        [RelayCommand]
        public void MinusLifeClicked()
        {
            this.PlayerModel.MinusLife();
        }
        public PlayerLifeTotalViewModel()
        {

        }
        public PlayerLifeTotalViewModel(PlayerModel playerModel, int rotation = 0)
        {
            this.Rotation = rotation;
            this.playerModel = playerModel;
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
    }
}
