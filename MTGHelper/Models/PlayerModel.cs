using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Models
{
    public class PlayerModel : BaseModel
    {
        private int id;
        private int life;
        private string playerName;
        private string color;
        private string? commanderName;
        private int poisonCounter;
        private int experienceCounter;
        private int energyCounter;
        private int ticketsCounter;

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
        public string Color
        {
            get { return color; }
            set
            {
                if (color == value) return;
                color = value;
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
        public int TicketsCounter
        {
            get { return ticketsCounter; }
            set
            {
                if (ticketsCounter == value) return;
                ticketsCounter = value;
                OnPropertyChanged();
            }
        }
        public PlayerModel()
        {

        }
        public PlayerModel(int id, int life, string playerName,string color, int poisonCounter = 0, int experienceCounter = 0, int energyCounter = 0, int ticketsCounter = 0, string? commanderName = null)
        {
            Id = id;
            Life = life;
            PlayerName = playerName;
            CommanderName = commanderName;
            PoisonCounter = poisonCounter;
            ExperienceCounter = experienceCounter;
            EnergyCounter = energyCounter;
            TicketsCounter = ticketsCounter;
            Color = color;
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
        public void AddTicketsCounter()
        {
            this.TicketsCounter++;
        }
        public void MinusTicketsCounter()
        {
            this.TicketsCounter--;
        }
    }
}
