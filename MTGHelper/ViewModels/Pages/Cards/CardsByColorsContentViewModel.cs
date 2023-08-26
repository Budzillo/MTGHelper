using MTGApi.Repository;
using MtgApiManager.Lib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public class CardsByColorsContentViewModel : BaseViewModel
    {
        private CardRepository cardRepository;

        private List<ICard> cards = new List<ICard>();
        private ObservableCollection<ICard> whiteCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> blackCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> redCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> greenCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> blueCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> multicoloredCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> colorlessCards = new ObservableCollection<ICard>();
        public List<ICard> Cards
        {
            get => cards;
            set
            {
                if (cards == value) return;
                cards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ICard> WhiteCards
        {
            get => whiteCards;
            set
            {
                if (whiteCards == value) return;
                whiteCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ICard> BlackCards
        {
            get => blackCards;
            set
            {
                if (blackCards == value) return;
                blackCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ICard> RedCards
        {
            get => redCards;
            set
            {
                if (redCards == value) return;
                redCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ICard> GreenCards
        {
            get => greenCards;
            set
            {
                if (greenCards == value) return;
                greenCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ICard> BlueCards
        {
            get => blueCards;
            set
            {
                if (blueCards == value) return;
                blueCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ICard> MulticoloredCards
        {
            get => multicoloredCards;
            set
            {
                if (multicoloredCards == value) return;
                multicoloredCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ICard> ColorlessCards
        {
            get => colorlessCards;
            set
            {
                if (colorlessCards == value) return;
                colorlessCards = value;
                OnPropertyChanged();
            }
        }
        public CardsByColorsContentViewModel()
        {

        }
        public CardsByColorsContentViewModel(string setName)
        {
            cardRepository = new CardRepository();
            GetCards(setName);
        }
        private void GetCards()
        {

        }
        private async void GetCards(string setName)
        {
            this.Cards = await cardRepository.GetCardsBySet(setName);
            //this.WhiteCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Contains("w")));
            //this.BlackCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Contains("b")));
            //this.WhiteCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Contains("w")));
            //this.WhiteCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Contains("w")));
            //this.WhiteCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Contains("w")));
        }
    }
}
