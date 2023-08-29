using CommunityToolkit.Mvvm.Input;
using MTGApi;
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
    public partial class CardsByColorsContentViewModel : BaseViewModel
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
        [RelayCommand]
        private async Task ContentViewLoaded()
        {            
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
            //this.Cards = await cardRepository.GetCardsBySet(setName);
            this.WhiteCards = new ObservableCollection<ICard>(await cardRepository.GetCardsBySetAndColor(setName,APIConst.COLOR_WHITE_CODE)) ;
            this.BlackCards = new ObservableCollection<ICard>(await cardRepository.GetCardsBySetAndColor(setName, APIConst.COLOR_BLACK_CODE));
            this.RedCards = new ObservableCollection<ICard>(await cardRepository.GetCardsBySetAndColor(setName, APIConst.COLOR_RED_CODE));
            this.GreenCards = new ObservableCollection<ICard>(await cardRepository.GetCardsBySetAndColor(setName, APIConst.COLOR_GREEN_CODE));
            this.BlueCards = new ObservableCollection<ICard>(await cardRepository.GetCardsBySetAndColor(setName, APIConst.COLOR_BLUE_CODE));
            this.MulticoloredCards = new ObservableCollection<ICard>(this.Cards.Where(q => q.IsMultiColor));
            this.ColorlessCards = new ObservableCollection<ICard>(await cardRepository.GetCardsBySetAndColor(setName, APIConst.COLOR_COLORLESSS_CODE));

            var listImages = this.WhiteCards.Where(q => q.ImageUrl != null).Select(q => q.ImageUrl).ToList();
        }
    }
}
