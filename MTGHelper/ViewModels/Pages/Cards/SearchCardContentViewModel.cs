using CommunityToolkit.Mvvm.Input;
using Microsoft.Rest;
using MTGApi.ScryfallRepository;
using Scryfall.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Platform;


namespace MTGHelper.ViewModels
{
    public partial class SearchCardContentViewModel : BaseViewModel
    {
        private ScryfallCardsRepository scryfallCardsRepository;

        private string cardName;
        private Card foundedCard;      
        private ObservableCollection<Card> foundedCards = new ObservableCollection<Card>();
        private Uri cardImageUri;
        private bool isFiltersOpen = false;
        public string CardName
        {
            get=> cardName;
            set 
            {
                if(cardName == value) return;
                cardName = value;
                OnPropertyChanged();
            } 
        }
        public Card FoundedCard
        {
            get => foundedCard;
            set
            {
                if(foundedCard == value) return;
                foundedCard = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Card> FoundedCards
        {
            get => foundedCards;
            set
            {
                if(foundedCards == value) return;   
                foundedCards = value;
                OnPropertyChanged();
            }
        }
        public Uri CardImageUri
        {
            get => cardImageUri;
            set
            {
                if( cardImageUri == value) return;
                cardImageUri = value;
                OnPropertyChanged();
            }
        }
        public bool IsFiltersOpen
        {
            get => isFiltersOpen;
            set
            {
                if(isFiltersOpen == value) return;
                isFiltersOpen = value;
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        private async Task SearchCardAsync()
        {
            this.FoundedCards.Clear();
            HttpOperationResponse<CardList> cardList = await new ScryfallCardsRepository().GetCardsByName(CardName);
            if(cardList.Body != null && cardList.Body.Data != null)
                FoundedCards = new ObservableCollection<Card>(cardList.Body.Data);            
        }
        [RelayCommand]
        private async Task OpenCloseFilters()
        {
            IsFiltersOpen = !IsFiltersOpen;
        }
        public SearchCardContentViewModel() 
        {
            scryfallCardsRepository = new ScryfallCardsRepository();
        }

    }
}
