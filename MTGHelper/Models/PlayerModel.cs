using Microsoft.Maui.Graphics;
using MTGHelper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MTGHelper.ClassConst;

namespace MTGHelper.Models
{
    public class PlayerModel : BaseModel
    {
        #region Fields
        private int id;
        private int life = 40;
        private string playerName;
        private string? commanderName;
        private int poisonCounter = 0;
        private int experienceCounter = 0;
        private int energyCounter = 0;
        private int selectedValue;
        private COUNTER_TYPES selectedCounterType;
        private int firstLifeValue = 0;
        private bool isLifeSelected = true;
        private bool isPoisonSelected = false;
        private bool isEnergySelected = false;
        private bool isTicketsSelected = false;
        private string bottomImageSource;
        private bool isDead = false;

        private bool isGreen = false;
        private bool isBlue = false;
        private bool isRed = false;
        private bool isWhite = false;
        private bool isBlack = false;

        private string greenImageSource = $"{BASE_IMAGE_CATALOG_NAME}green.svg";
        private string blueImageSource = $"{BASE_IMAGE_CATALOG_NAME}blue.svg";
        private string redImageSource = $"{BASE_IMAGE_CATALOG_NAME}red.svg";
        private string whiteImageSource = $"{BASE_IMAGE_CATALOG_NAME}white.svg";
        private string blackImageSource = $"{BASE_IMAGE_CATALOG_NAME}black.svg";

        private bool isPoisonCounterVisible = true;
        private bool isTicketCounterVisible = true;
        private bool isEnergyCounterVisible = true;

        private bool isColorPickerOpen = false;
        private bool isCommanderDamageOpen = false;

        private Color color;

        private CommanderDamagesModel commanderDamagesModel;

        private bool isCommanderDamageDealer = false;

        #endregion

        #region Properties
        public int Id 
        { 
            get { return id; } 
            set 
            {
                if(id == value) return;
                id = value;
                OnPropertyChanged();
            } 
        }
        public int Life
        {
            get { return life; }
            set
            {
                if (life == value) return;
                life = value;
                OnPropertyChanged();
                if(life == 0)
                {
                    IsDead = true;
                }
            }
        }
        public string PlayerName
        {
            get { return playerName; }
            set
            {
                if (playerName == value) return;
                playerName = value;
                OnPropertyChanged();
            }
        }
        public string? CommanderName
        {
            get { return commanderName; }
            set
            {
                if (commanderName == value) return;
                commanderName = value;
                OnPropertyChanged();

            }
        }
        public int PoisonCounter
        {
            get { return poisonCounter; }
            set
            {
                if (poisonCounter == value) return;
                poisonCounter = value;                    
                OnPropertyChanged();
                if(poisonCounter == 10)
                {
                    IsDead = true;
                }
            }
        }
        public int ExperienceCounter
        {
            get { return experienceCounter; }
            set
            {
                if (experienceCounter == value) return;
                    experienceCounter = value;
                OnPropertyChanged();
            }
        }
        public int EnergyCounter
        {
            get { return energyCounter; }
            set
            {
                if (energyCounter == value) return;
                energyCounter = value;
                OnPropertyChanged();
            }
        }
        public int SelectedValue
        {
            get => selectedValue;
            set
            {
                if (selectedValue == value) return;
                selectedValue = value;
                OnPropertyChanged();
            }
        }
        public COUNTER_TYPES SelectedCounterType
        {
            get => selectedCounterType;
            set
            {
                if (selectedCounterType == value) return;
                selectedCounterType = value;
                switch (value)
                {
                    case COUNTER_TYPES.LIFE: 
                        SelectedValue = Life;
                        IsLifeSelected = true;
                        IsPoisonSelected = false;
                        IsEnergySelected = false;
                        IsTicketsSelected = false;
                        BottomImageSource = ClassConst.HEART_IMAGE_NAME;
                        break;
                    case COUNTER_TYPES.POISON: 
                        SelectedValue = PoisonCounter;
                        IsLifeSelected = false;
                        IsPoisonSelected = true;
                        IsEnergySelected = false;
                        IsTicketsSelected = false;
                        BottomImageSource = ClassConst.POISON_COUNTER_IMAGE_NAME;
                        break;
                    case COUNTER_TYPES.ENERGY:
                        SelectedValue = EnergyCounter;
                        IsLifeSelected = false;
                        IsPoisonSelected = false;
                        IsEnergySelected = true;
                        IsTicketsSelected = false;
                        BottomImageSource = ClassConst.ENERGY_COUNTER_IMAGE_NAME;
                        break;
                }
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
                if (isTicketsSelected == value) return;
                isTicketsSelected = value;
                OnPropertyChanged();
            }
        }
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
        public bool IsDead
        {
            get { return isDead; }
            set
            {
                if (isDead == value) return;
                isDead = value;
                OnPropertyChanged();
            }
        }

        public bool IsGreen
        {
            get => isGreen;
            set
            {
                if(isGreen == value) return;
                isGreen = value;
                if (isGreen)
                    GreenImageSource = $"{BASE_IMAGE_CATALOG_NAME}green_w.svg";
                else
                    GreenImageSource = $"{BASE_IMAGE_CATALOG_NAME}green.svg";
                MixColors();
                OnPropertyChanged();
            }
        }
        public bool IsBlue
        {
            get => isBlue;
            set
            {
                if (isBlue == value) return;
                isBlue = value;
                if (isBlue)
                    BlueImageSource = $"{BASE_IMAGE_CATALOG_NAME}blue_w.svg";
                else
                    BlueImageSource = $"{BASE_IMAGE_CATALOG_NAME}blue.svg";
                MixColors();
                OnPropertyChanged();
            }
        }
        public bool IsRed
        {
            get => isRed;
            set
            {
                if (isRed == value) return;
                isRed = value;
                if (isRed)
                    RedImageSource = $"{BASE_IMAGE_CATALOG_NAME}red_w.svg";
                else
                    RedImageSource = $"{BASE_IMAGE_CATALOG_NAME}red.svg";
                MixColors();
                OnPropertyChanged();
            }
        }
        public bool IsWhite
        {
            get => isWhite;
            set
            {
                if (isWhite == value) return;
                isWhite = value;
                if (isWhite)
                    WhiteImageSource = $"{BASE_IMAGE_CATALOG_NAME}white_w.svg";
                else
                    WhiteImageSource = $"{BASE_IMAGE_CATALOG_NAME}white.svg";
                MixColors();
                OnPropertyChanged();
            }
        }
        public bool IsBlack
        {
            get => isBlack;
            set
            {
                if (isBlack == value) return;
                isBlack = value;
                if (isBlack)
                    BlackImageSource = $"{BASE_IMAGE_CATALOG_NAME}black_w.svg";
                else
                    BlackImageSource = $"{BASE_IMAGE_CATALOG_NAME}black.svg";
                MixColors();
                OnPropertyChanged();
            }
        }
        public string GreenImageSource
        {
            get => greenImageSource;
            set
            {
                if (greenImageSource == value) return;
                greenImageSource = value;
                OnPropertyChanged();
            }
        }
        public string BlueImageSource
        {
            get=> blueImageSource;
            set
            {
                if (blueImageSource == value) return;
                blueImageSource = value;
                OnPropertyChanged();
            }
        }
        public string RedImageSource
        {
            get=> redImageSource; 
            set
            {
                if (redImageSource == value) return;
                redImageSource = value;
                OnPropertyChanged();
            }
        }
        public string WhiteImageSource
        {
            get=> whiteImageSource;
            set
            {
                if (whiteImageSource == value) return;
                whiteImageSource = value;
                OnPropertyChanged();
            }
        }
        public string BlackImageSource
        {
            get=> blackImageSource;
            set
            {
                if (blackImageSource == value) return;
                blackImageSource = value;
                OnPropertyChanged();
            }
        }

        public bool IsPoisonCounterVisible
        {
            get => isPoisonCounterVisible;
            set
            {
                if(isPoisonCounterVisible == value) return;
                isPoisonCounterVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnergyCounterVisible
        {
            get => isEnergyCounterVisible;
            set
            {
                if(isEnergyCounterVisible == value) return;
                isEnergyCounterVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsTicketCounterVisible
        {
            get => isTicketCounterVisible;
            set
            {
                if(isTicketCounterVisible == value) return;
                isTicketCounterVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsColorPickerOpen
        {
            get => isColorPickerOpen;
            set
            {
                if(isColorPickerOpen == value) return;
                isColorPickerOpen = value;
                OnPropertyChanged();
            }
        }
        public bool IsCommanderDamageOpen
        {
            get => isCommanderDamageOpen;
            set
            {
                if (isCommanderDamageOpen == value) return;
                isCommanderDamageOpen = value;
                OnPropertyChanged();
            }
        }
        public Color Color
        {
            get => color;
            set
            {
                if (color == value) return;
                color = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamagesModel CommanderDamagesModel
        {
            get => commanderDamagesModel;
            set
            {
                if(commanderDamagesModel == value) return; 
                commanderDamagesModel = value;
                OnPropertyChanged();
            }
        }
        public bool IsCommanderDamageDealer
        {
            get => isCommanderDamageDealer;
            set
            {
                if (isCommanderDamageDealer == value) return;
                isCommanderDamageDealer = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public PlayerModel()
        {

        }
        public PlayerModel(int id, int life, string playerName, string color, int poisonCounter = 0, int experienceCounter = 0, int energyCounter = 0, string? commanderName = null)
        {
            firstLifeValue = life;
            Id = id;
            Life = life;
            PlayerName = playerName;
            CommanderName = commanderName;
            PoisonCounter = poisonCounter;
            ExperienceCounter = experienceCounter;
            EnergyCounter = energyCounter;
            SelectedCounterType = COUNTER_TYPES.LIFE;
            CommanderDamagesModel = new CommanderDamagesModel();
            PrepareCommanderDamages(id);
            SetColor(color);
        }

        #region Methods
        private void PrepareCommanderDamages(int id)
        {
            if (id != 1)
                this.CommanderDamagesModel.Player1Damage = new CommanderDamageModel();
            if (id != 2)
                this.CommanderDamagesModel.Player2Damage = new CommanderDamageModel();
            if (id != 3)
                this.CommanderDamagesModel.Player3Damage = new CommanderDamageModel();
            if (id != 4)
                this.CommanderDamagesModel.Player4Damage = new CommanderDamageModel();
            if (id != 5)
                this.CommanderDamagesModel.Player5Damage = new CommanderDamageModel();
            if (id != 6)
                this.CommanderDamagesModel.Player6Damage = new CommanderDamageModel();
        }
        public void AddLife()
        {
            this.Life++;
        }
        public void MinusLife()
        {
            this.Life--;
        }
        public void AddPoisonCounter()
        {
            this.PoisonCounter++;
        }
        public void MinusPoisonCounter()
        {
            this.PoisonCounter--;
        }
        public void AddExpeirenceCounter()
        {
            this.ExperienceCounter++;
        }
        public void MinusExpeirenceCounter()
        {
            this.ExperienceCounter--;
        }
        public void AddEnergyCounter()
        {
            this.EnergyCounter++;
        }
        public void MinusEnergyCounter()
        {
            this.EnergyCounter--;
        }
        public void ResetValues(int lifeTotal)
        {
            this.Life = lifeTotal;
            this.PoisonCounter = 0;
            this.ExperienceCounter = 0;
            this.EnergyCounter = 0;
            this.SelectedCounterType = COUNTER_TYPES.LIFE;
            this.CommanderDamagesModel.ResetValues();
            this.SelectedValue = Life;
            this.IsCommanderDamageOpen = false;
            this.IsCommanderDamageDealer = false;

        }
        public void SelectCounterType(COUNTER_TYPES counterType)
        {
            this.SelectedCounterType = counterType;            
        }
        public void Decrease()
        {
            switch (SelectedCounterType)
            {
                case COUNTER_TYPES.LIFE: 
                    MinusLife(); 
                    SelectedValue = Life; 
                    break;
                case COUNTER_TYPES.POISON: 
                    MinusPoisonCounter(); 
                    SelectedValue = PoisonCounter; 
                    break;
                case COUNTER_TYPES.ENERGY: 
                    MinusEnergyCounter(); 
                    SelectedValue = EnergyCounter;  
                    break;
            }
        }
        public void Increase()
        {
            switch(SelectedCounterType)
            {
                case COUNTER_TYPES.LIFE: 
                    AddLife();
                    SelectedValue = Life; 
                    break;
                case COUNTER_TYPES.POISON:
                    AddPoisonCounter();
                    SelectedValue = PoisonCounter;
                    break;
                case COUNTER_TYPES.ENERGY: 
                    AddEnergyCounter(); 
                    SelectedValue = EnergyCounter;
                    break;
            }
            
        }
        public void ShowColorPicker()
        {
            this.IsColorPickerOpen = true;
        }
        public void HideColorPicker()
        {
            this.IsColorPickerOpen = false;
        }
        public void ShowCommanderDamage()
        {
            this.IsCommanderDamageOpen = true;
        }
        public void HideCommanderDamage()
        {
            this.IsCommanderDamageOpen = false;
        }
        public void SetColor(string color)
        {
            switch (color)
            {
                case "black": this.IsBlack = !this.IsBlack; break; 
                case "white": this.IsWhite = !this.IsWhite; break; 
                case "red": this.IsRed = !this.IsRed; break; 
                case "green": this.IsGreen = !this.IsGreen; break; 
                case "blue": this.IsBlue = !this.IsBlue; break; 
            }
        }
        private void MixColors()
        {
            List<Color> colors = new List<Color>();
            if (isBlack) colors.Add(ClassConst.BLACK_COLOR);
            if (isWhite) colors.Add(ClassConst.WHITE_COLOR);
            if (isBlue) colors.Add(ClassConst.BLUE_COLOR);
            if (isGreen) colors.Add(ClassConst.GREEN_COLOR);
            if (isRed) colors.Add(ClassConst.RED_COLOR);
            if(colors.Count == 0)
            {
                this.Color = ClassConst.COLORLSESS_COLOR;
                return;
            }
            this.Color = ColorHelper.MixColors(colors.ToArray());
        }
        #endregion
    }
}
	