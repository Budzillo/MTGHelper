using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scryfall.API.Models;
using MTGApi.ScryfallRepository;
using System.ComponentModel;
using System.Collections.Specialized;
using Microsoft.Rest;

namespace MTGHelper.ViewModels
{
    public partial class CardsByColorsContentViewModel : BaseViewModel
    {
        private ScryfallCardsRepository cardRepository;
        private SetSearchPageViewModel setSearchPageViewModel;

        private List<Card> cards = new List<Card>();
        private ObservableCollection<Card> whiteCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> blackCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> redCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> greenCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> blueCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> multicoloredCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> colorlessCards = new ObservableCollection<Card>();

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
        public List<Card> Cards
        {
            get => cards;
            set
            {
                if (cards == value) return;
                cards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> WhiteCards
        {
            get => whiteCards;
            set
            {
                if (whiteCards == value) return;
                whiteCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> BlackCards
        {
            get => blackCards;
            set
            {
                if (blackCards == value) return;
                blackCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> RedCards
        {
            get => redCards;
            set
            {
                if (redCards == value) return;
                redCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> GreenCards
        {
            get => greenCards;
            set
            {
                if (greenCards == value) return;
                greenCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> BlueCards
        {
            get => blueCards;
            set
            {
                if (blueCards == value) return;
                blueCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> MulticoloredCards
        {
            get => multicoloredCards;
            set
            {
                if (multicoloredCards == value) return;
                multicoloredCards = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> ColorlessCards
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
            cardRepository = new ScryfallCardsRepository();
            this.SetSearchPageViewModel = setSearchPageViewModel;
            GetCards(setName);
        }
        private async void GetCards(string setName)
        {
            //this.Cards = await cardRepository.GetCardsBySet(setName);
            this.WhiteCards = new ObservableCollection<Card>(await GetCardsBySetColor(setName,MTGApi.APIConst.COLOR_WHITE_CODE)) ;
            this.BlackCards = new ObservableCollection<Card>(await GetCardsBySetColor(setName, MTGApi.APIConst.COLOR_BLACK_CODE));
            this.RedCards = new ObservableCollection<Card>(await GetCardsBySetColor(setName, MTGApi.APIConst.COLOR_RED_CODE));
            this.GreenCards = new ObservableCollection<Card>(await GetCardsBySetColor(setName, MTGApi.APIConst.COLOR_GREEN_CODE));
            this.BlueCards = new ObservableCollection<Card>(await GetCardsBySetColor(setName, MTGApi.APIConst.COLOR_BLUE_CODE));
            this.MulticoloredCards = new ObservableCollection<Card>(await GetCardsBySetColor(setName, MTGApi.APIConst.COLOR_MULTICOLOR_CODE));
            this.ColorlessCards = new ObservableCollection<Card>(await GetCardsBySetColor(setName, MTGApi.APIConst.COLOR_COLORLESSS_CODE));
        }
        private async Task<List<Card>> GetCardsBySetColor(string setName,string color)
        {
            HttpOperationResponse<CardList> cardList = await cardRepository.GetCardsBySetColor(setName, color);
            if (cardList.Body != null && cardList.Body.Data != null)
                return cardList.Body.Data.ToList();
            else return new List<Card>();
        }
    }
}
