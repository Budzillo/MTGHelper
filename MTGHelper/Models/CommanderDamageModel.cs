using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Models
{
    public partial class CommanderDamageModel : ObservableObject
    {
        private PlayerModel playerWhoDealtDamage;
        private int damage = 0;
        public PlayerModel PlayerWhoDealDamage
        {
            get => playerWhoDealtDamage;
            set
            {
                if(value == playerWhoDealtDamage) return;
                playerWhoDealtDamage = value;
                OnPropertyChanged();
            }
        }
        public int Damage
        {
            get => damage;
            set
            {
                if(value == damage) return;
                damage = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamageModel() 
        {
            
        }
        public CommanderDamageModel(PlayerModel player)
        {
            this.PlayerWhoDealDamage = player;
        }
        public void IncreaseDamage()
        {
            this.Damage++;
        }
        public void DecreaseDamage()
        {
            this.Damage--;
        }
        public void ResetDamage()
        {
            this.Damage = 0;
        }
    }
}
