﻿using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MTGHelper.Models;
using MTGHelper.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using static MTGHelper.ClassConst;

namespace MTGHelper.ViewModels
{
    public partial class PlayerLifeTotalViewModel : BaseViewModel
    {
        private System.Timers.Timer timer;

        private LifeCounterPageViewModel lifeCounterPageViewModel;
        private int playerIndex = 1;
        private int rotation;
        private int addedValue;
        private bool addedValueIsVisible = false;
        private ColorSelectContent colorSelectContent;
        private ColorSelectVerticalContent colorSelectVerticalContent;
        private HorizontalCommanderDamageContent horizontalCommanderDamageContent;
        private HorizontalReverseCommanderDamageContent horizontalReverseCommanderDamageContent;
        private VerticalCommanderDamageContent verticalCommanderDamageContent;        
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
        public int AddedValue
        {
            get { return addedValue; }
            set
            {
                if (addedValue == value) return;
                addedValue = value;
                OnPropertyChanged();
            }
        }
        public bool AddedValueIsVisible
        {
            get => addedValueIsVisible;
            set
            {
                if (addedValueIsVisible == value) return;
                addedValueIsVisible = value;
                OnPropertyChanged();
            }
        }
        public ColorSelectContent ColorSelectContent
        {
            get => colorSelectContent;
            set
            {
                if (colorSelectContent == value) return;
                colorSelectContent = value;
                OnPropertyChanged();
            }
        }
        public ColorSelectVerticalContent ColorSelectVerticalContent
        {
            get => colorSelectVerticalContent;
            set
            {
                if (colorSelectVerticalContent == value) return;
                colorSelectVerticalContent = value;
                OnPropertyChanged();
            }
        }
        public HorizontalCommanderDamageContent HorizontalCommanderDamageContent
        {
            get => horizontalCommanderDamageContent;
            set
            {
                if(horizontalCommanderDamageContent == value) return;
                horizontalCommanderDamageContent = value;
                OnPropertyChanged();
            }
        }
        public HorizontalReverseCommanderDamageContent HorizontalReverseCommanderDamageContent
        {
            get => horizontalReverseCommanderDamageContent;
            set
            {
                if (horizontalReverseCommanderDamageContent == value) return;
                horizontalReverseCommanderDamageContent = value;
                OnPropertyChanged();    
            }
        }
        public VerticalCommanderDamageContent VerticalCommanderDamageContent
        {
            get => verticalCommanderDamageContent;
            set
            {
                if (verticalCommanderDamageContent == value) return;
                verticalCommanderDamageContent = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        public void SetNumberType(string counterName)
        {
            if (GetPlayerModel().IsColorPickerOpen) return;
            GetPlayerModel().SelectCounterType(GetCounterTypeByName(counterName));           
        }
        [RelayCommand]
        private void OpenColorPicker()
        {
            GetPlayerModel().ShowColorPicker();
        }
        [RelayCommand]
        private void CloseColorPicker()
        {
            GetPlayerModel().HideColorPicker();
        }
        [RelayCommand]
        private void SetColor(string color)
        {
            GetPlayerModel().SetColor(color);
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
            if (GetPlayerModel().IsColorPickerOpen) return;
            if (tappedEventArgs.GetPosition(grid).Value.Y <= grid.Height / 2)
            {
                Increase();
            }
            else Decrease();
        }
        public void GridTappedHorizontal(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (GetPlayerModel().IsColorPickerOpen) return;
            if (tappedEventArgs.GetPosition(grid).Value.X >= grid.Width / 2)
            {
                Increase();
            }
            else Decrease();
        }
        public void GridTappedHorizontalReverse(Grid grid, TappedEventArgs tappedEventArgs)
        {
            if (GetPlayerModel().IsColorPickerOpen) return;
            if (tappedEventArgs.GetPosition(grid).Value.X <= grid.Width / 2)
            {
                Increase();
            }
            else Decrease();
        }

        private void StartAddedValueTimer(bool isPlus)
        {
            this.timer.Close();
            this.AddedValueIsVisible = true;
            if(isPlus) this.AddedValue++;
            else this.AddedValue--; 
            this.timer.Start();
        }

        private void Decrease()
        {
            StartAddedValueTimer(false);
            GetPlayerModel().Decrease();
        }
        private void Increase()
        {
            StartAddedValueTimer(true);
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
            PrepareColorSelect();
            PrepareTimer();
            PrepareCommands();
        }
        private void Initialize()
        {

        }
        private void PrepareCommands()
        {

        }
        private void PrepareColorSelect()
        {
            this.ColorSelectContent = new ColorSelectContent();
            this.ColorSelectContent.BindingContext = this;
            this.ColorSelectVerticalContent = new ColorSelectVerticalContent();
            this.ColorSelectVerticalContent.BindingContext = this;
        }
        private void PrepareTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 3000;
            timer.Elapsed += Timer_Elapsed;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.AddedValueIsVisible = false;
            this.AddedValue = 0;
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
        public async Task FlashRandomFirstPlayer(ContentView contentView)
        {
            await MainThread.InvokeOnMainThreadAsync(() => {
                var animation = new Animation(v => contentView.Opacity = v, 0, 1);
                animation.Commit((IAnimatable)contentView, "ContentRandomFirstPlayerFlashAnimation", 16, 600, Easing.Linear);
            });
        }
    }
}
