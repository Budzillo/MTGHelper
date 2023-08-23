using CommunityToolkit.Mvvm.ComponentModel;
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
        public DiceRollModel() 
        {
        }
        public async Task RollDice(int walls)
        {
            await Task.Delay(1000);
            Random rnd = new Random();  
            int rolls = rnd.Next(10, 21);
            for(int i = 0; i < rolls; i++)
            {
                this.DiceValue = rnd.Next(1,1+walls);
                await Task.Delay(500);
            }
            this.DiceValueInformation = $"You rolled {this.DiceValue}";
        }
    }
}
