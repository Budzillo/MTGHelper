using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Models
{
    public class DeckModel : ObservableObject
    {
        private string name;
        private string format;
        private int cardCount;
        private int maxCardCount;
        private bool isCommander = false;
        private string? commanderName;
        public string Name
        {
            get => name;
            set
            {
                if(value == name) return;
                name = value;
                OnPropertyChanged();    
            }
        }
        public string Format
        {
            get => format;
            set
            {
                if (value == format) return;
                format = value;
                OnPropertyChanged();
            }
        }
        public int CardCount
        {
            get => cardCount; 
            set
            {
                if(cardCount == value) return;  
                cardCount = value;
                OnPropertyChanged();
            }
        }
        public int MaxCardCount
        {
            get => maxCardCount;
            set
            {
                if (maxCardCount == value) return;
                maxCardCount = value;
                OnPropertyChanged();
            }
        }
        public bool IsCommander
        {
            get => isCommander;
            set
            {
                if (isCommander == value) return;
                isCommander = value;
                OnPropertyChanged();
            }
        }
        public string? CommanderName
        {
            get => commanderName;
            set
            {
                if (commanderName == value) return;
                commanderName = value;
                OnPropertyChanged();
            }
        }

        public DeckModel() { }
        public DeckModel(string name, string format, int cardCount, int maxCardCount)
        {
            Name = name;
            Format = format;
            CardCount = cardCount;
            MaxCardCount = maxCardCount;
        }
    }
}
