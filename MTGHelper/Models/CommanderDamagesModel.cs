﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Models
{
    public partial class CommanderDamagesModel : ObservableObject
    {
        private CommanderDamageModel? player1Damage;
        private CommanderDamageModel? player2Damage;
        private CommanderDamageModel? player3Damage;
        private CommanderDamageModel? player4Damage;
        private CommanderDamageModel? player5Damage;
        private CommanderDamageModel? player6Damage;
        public CommanderDamageModel? Player1Damage
        {
            get => player1Damage;
            set
            {
                if(player1Damage == value) return;
                player1Damage = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamageModel? Player2Damage
        {
            get => player2Damage;
            set
            {
                if (player2Damage == value) return;
                player2Damage = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamageModel? Player3Damage
        {
            get => player3Damage;
            set
            {
                if (player3Damage == value) return;
                player3Damage = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamageModel? Player4Damage
        {
            get => player4Damage;
            set
            {
                if (player4Damage == value) return;
                player4Damage = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamageModel? Player5Damage
        {
            get => player5Damage;
            set
            {
                if (player5Damage == value) return;
                player5Damage = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamageModel? Player6Damage
        {
            get => player6Damage;
            set
            {
                if (player6Damage == value) return;
                player6Damage = value;
                OnPropertyChanged();
            }
        }
        public CommanderDamagesModel() { }
        public void ResetValues()
        {
            if(this.Player1Damage != null) this.Player1Damage.ResetDamage();   
            if(this.Player2Damage != null) this.Player2Damage.ResetDamage();   
            if(this.Player3Damage != null) this.Player3Damage.ResetDamage();   
            if(this.Player4Damage != null) this.Player4Damage.ResetDamage();   
            if(this.Player5Damage != null) this.Player5Damage.ResetDamage();   
            if(this.Player6Damage != null) this.Player6Damage.ResetDamage();   
        }
        public void IncreaseDamage(int playerIndex)
        {
            switch(playerIndex)
            {
                case 1: this.Player1Damage.IncreaseDamage();break;
                case 2: this.Player1Damage.IncreaseDamage();break;
                case 3: this.Player1Damage.IncreaseDamage();break;
                case 4: this.Player1Damage.IncreaseDamage();break;
                case 5: this.Player1Damage.IncreaseDamage();break;
                case 6: this.Player1Damage.IncreaseDamage();break;
            }
        }
        public void DecreaseDamage(int playerIndex)
        {
            switch (playerIndex)
            {
                case 1: this.Player1Damage.DecreaseDamage(); break;
                case 2: this.Player1Damage.DecreaseDamage(); break;
                case 3: this.Player1Damage.DecreaseDamage(); break;
                case 4: this.Player1Damage.DecreaseDamage(); break;
                case 5: this.Player1Damage.DecreaseDamage(); break;
                case 6: this.Player1Damage.DecreaseDamage(); break;
            }
        }
        public int GetDamage(int playerIndex)
        {
            switch (playerIndex)
            {
                case 1: return this.Player1Damage.Damage;
                case 2: return this.Player2Damage.Damage;
                case 3: return this.Player3Damage.Damage;
                case 4: return this.Player4Damage.Damage;
                case 5: return this.Player5Damage.Damage;
                case 6: return this.Player6Damage.Damage;
            }
            return 0;
        }
        public void SetDamage(int playerIndex, int damage)
        {
            switch (playerIndex)
            {
                case 1: this.Player1Damage.Damage = damage; break;
                case 2: this.Player2Damage.Damage = damage; break;
                case 3: this.Player3Damage.Damage = damage; break;
                case 4: this.Player4Damage.Damage = damage; break;
                case 5: this.Player5Damage.Damage = damage; break;
                case 6: this.Player6Damage.Damage = damage; break;
            }
        }
    }
}
