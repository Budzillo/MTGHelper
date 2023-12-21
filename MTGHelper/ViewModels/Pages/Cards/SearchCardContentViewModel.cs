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
        private ObservableCollection<Card> allCards = new ObservableCollection<Card>();
        private Uri cardImageUri;
        private bool isFiltersOpen = false;
        private string sortBy = "Name";
        private string typeLine;
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
        public string SortBy
        {
            get => sortBy;
            set
            {
                if(sortBy == value) return;
                sortBy = value; 
                OnPropertyChanged();
            }
        }
        public string TypeLine
        {
            get => typeLine;
            set
            {
                if(typeLine == value) return;
                typeLine = value; 
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        private async Task SearchCardAsync()
        {
            this.FoundedCards.Clear();
            HttpOperationResponse<CardList> cardList = await new ScryfallCardsRepository().GetCardsByName(CardName);
            if(cardList.Body != null && cardList.Body.Data != null)
            {
                allCards = new ObservableCollection<Card>(cardList.Body.Data);
                FilterBy();
            }
        }
        [RelayCommand]
        private void FilterBy()
        {
            if(allCards != null)
            {
                switch (SortBy)
                {
                    case "Name": FoundedCards = new ObservableCollection<Card>(allCards.Where(q => IsContainsType(q?.TypeLine)).OrderBy(q => q.Name)); break;
                    case "Mana value": FoundedCards = new ObservableCollection<Card>(allCards.Where(q => IsContainsType(q?.TypeLine)).OrderBy(q => q.ManaCost)); break;
                    case "Power": FoundedCards = new ObservableCollection<Card>(allCards.Where(q => IsContainsType(q?.TypeLine)).OrderBy(q => q.Power)); break;
                    case "Toughness": FoundedCards = new ObservableCollection<Card>(allCards.Where(q => IsContainsType(q?.TypeLine)).OrderBy(q => q.Toughness)); break;
                }
            }
        }
        private bool IsContainsType(string typeLine)
        {
            bool result = false;
            if (TypeLine == null || TypeLine == String.Empty) return true;
            foreach(string type in TypeLine.Split(','))
            {
                result = typeLine.ToLower().Contains(type.ToLower());
            }
            return result;
        }

        [RelayCommand]
        private void OpenCloseFilters()
        {
            IsFiltersOpen = !IsFiltersOpen;
        }
        public SearchCardContentViewModel() 
        {
            scryfallCardsRepository = new ScryfallCardsRepository();
        }

    }
}
