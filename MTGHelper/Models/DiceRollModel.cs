using CommunityToolkit.Mvvm.ComponentModel;
using MTGHelper.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Models
{
    public partial class DiceRollModel : ObservableObject
    {
        private int diceValue = 1;
        private string diceValueInformation = "";
        private string diceD6ImageSource = ClassConst.DICE_D6_ONE_IMAGE_NAME;
        public int DiceValue
        {
            get => diceValue;
            set
            {
                if(diceValue == value) return;
                diceValue = value;
                OnPropertyChanged();              
            }
        }
        public string DiceValueInformation
        {
            get => diceValueInformation;
            set
            {
                if(diceValueInformation == value) return;
                diceValueInformation = value; 
                OnPropertyChanged();
            }
        }
        public string DiceD6ImageSource
        {
            get => diceD6ImageSource;
            set
            {
                if(diceD6ImageSource == value) return;
                diceD6ImageSource = value;
                OnPropertyChanged();
            }
        }
        public DiceRollModel() 
        {
        }
        public async Task RollDice(int walls)
        {
            Random rnd = new Random();  
            int rolls = rnd.Next(10, 21);
            for(int i = 0; i < rolls; i++)
            {
                this.DiceValue = rnd.Next(1,1+walls);
                if(walls == 6)
                {
                    SetDiceD6ImageSource(this.DiceValue);
                }
                await Task.Delay(250);
            }
            this.DiceValueInformation = $"You rolled {this.DiceValue}";
        }
        public async Task FlipCoin(FlipCoinContent flipCoinContent)
        {
            Random rnd = new Random();
            int rolls = rnd.Next(10, 21);
            this.DiceValue = 1;
            for (int i = 0; i < rolls; i++)
            {
                this.DiceValue = this.DiceValue == 1 ? 2 : 1;
                await flipCoinContent.FlipCoin();
                await Task.Delay(500);
            }
            this.DiceValueInformation = $"You flipped {this.DiceValue}";
        }
        private void SetDiceD6ImageSource(int roll)
        {
            switch(roll)
            {
                case 1: this.DiceD6ImageSource = ClassConst.DICE_D6_ONE_IMAGE_NAME; break;
                case 2: this.DiceD6ImageSource = ClassConst.DICE_D6_TWO_IMAGE_NAME; break;
                case 3: this.DiceD6ImageSource = ClassConst.DICE_D6_THREE_IMAGE_NAME; break;
                case 4: this.DiceD6ImageSource = ClassConst.DICE_D6_FOUR_IMAGE_NAME; break;
                case 5: this.DiceD6ImageSource = ClassConst.DICE_D6_FIVE_IMAGE_NAME; break;
                case 6: this.DiceD6ImageSource = ClassConst.DICE_D6_SIX_IMAGE_NAME; break;
            }
        }
    }
}
