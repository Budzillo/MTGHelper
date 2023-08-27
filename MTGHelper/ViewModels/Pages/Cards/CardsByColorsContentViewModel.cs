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
        private SetSearchPageViewModel setSearchPageViewModel;

        private List<ICard> cards = new List<ICard>();
        private ObservableCollection<ICard> whiteCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> blackCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> redCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> greenCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> blueCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> multicoloredCards = new ObservableCollection<ICard>();
        private ObservableCollection<ICard> colorlessCards = new ObservableCollection<ICard>();

        public SetSearchPageViewModel SetSearchPageViewModel
        {
            get => setSearchPageViewModel;
            set
            {
                if(setSearchPageViewModel == value) return;
                setSearchPageViewModel = value;
                OnPropertyChanged();
            }
        }
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
        public CardsByColorsContentViewModel(SetSearchPageViewModel setSearchPageViewModel,string setName)
        {
            cardRepository = new CardRepository();
            this.SetSearchPageViewModel = setSearchPageViewModel;
            GetCards(setName);
        }
        private void GetCards()
        {

        }
        private async void GetCards(string setName)
        {
            this.Cards = await cardRepository.GetCardsBySet(setName);
            this.WhiteCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Count() == 1 && q.Colors[0].ToLower() == "w")) ;
            this.BlackCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Count() == 1 && q.Colors[0].ToLower() == "b"));
            this.RedCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Count() == 1 && q.Colors[0].ToLower() == "r"));
            this.GreenCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Count() == 1 && q.Colors[0].ToLower() == "g"));
            this.BlueCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.Colors.Count() == 1 && q.Colors[0].ToLower() == "w"));
            this.MulticoloredCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.IsMultiColor));
            this.ColorlessCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.IsColorless));
        }
    }
}
