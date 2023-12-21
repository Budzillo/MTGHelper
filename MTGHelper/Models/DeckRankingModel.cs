using Scryfall.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Models
{
    public class DeckRankingModel : BaseModel
    {
        private int id;
        private string name;
        private string description;
        private string commanderName;
        private string commanderImage;
        private List<Scryfall.API.Models.Colors?> colors ;
        private DeckModel deck;
        private string powerLevel;

        public int Id
        {
            get => id;
            set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => description;
            set
            {
                if (description == value) return;
                description = value;
                OnPropertyChanged();
            }
        }
        public DeckModel Deck
        {
            get => deck;
            set
            {
                if (deck == value) return;
                deck = value;
                OnPropertyChanged();
            }
        }
        public string CommanderName
        {
            get => commanderName;
            set
            {
                if (commanderName == value) return;
                commanderName = value;
                OnPropertyChanged();
            }
        }
        public string CommanderImage
        {
            get => commanderImage;
            set
            {
                if (commanderImage == value) return;
                commanderImage = value;
                OnPropertyChanged();
            }
        }
        public List<Scryfall.API.Models.Colors?> Colors
        {
            get => colors;
            set
            {
                if (colors == value) return;
                colors = value;
                OnPropertyChanged();
            }
        }
        public string PowerLevel
        {
            get => powerLevel;
            set
            {
                if (powerLevel == value) return;
                powerLevel = value;
                OnPropertyChanged();
            }
        }
        public Uri CommanderImageUri
        {
            get => new Uri(commanderImage);
        }
    }
}
