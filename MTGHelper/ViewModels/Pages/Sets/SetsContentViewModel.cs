using CommunityToolkit.Mvvm.Input;
using MTGApi.Repository;
using MTGApi.ScryfallRepository;
using MtgApiManager.Lib.Model;
using Scryfall.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class SetsContentViewModel : BaseViewModel
    {
        private SetSearchPageViewModel setSearchPageViewModel;
        private ScryfallSetRepository repository;
        private List<Set> allSets = new List<Set>();
        private ObservableCollection<Set> searchedSets;
        private string searchText;
        public SetSearchPageViewModel SetSearchPageViewModel
        {
            get => setSearchPageViewModel;
            set
            {
                if (setSearchPageViewModel == value) return;
                setSearchPageViewModel = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Set> SearchedSets
        {
            get => searchedSets;
            set
            {
                if (searchedSets == value) return;
                searchedSets = value;
                OnPropertyChanged();
            }
        }
        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText == value) return;
                searchText = value;
                OnPropertyChanged();
            }
        }
        public SetsContentViewModel()
        {
            
        }
        public SetsContentViewModel(SetSearchPageViewModel setSearchPageViewModel)
        {
            this.SetSearchPageViewModel = setSearchPageViewModel;
            Initialization();
        }
        private async void Initialization()
        {
            this.repository = new ScryfallSetRepository();
            SetList setList = await repository.GetAllSets();
            if(setList != null)
            {
                this.allSets = setList.Data.ToList();
                this.SearchedSets = new ObservableCollection<Set>(allSets.OrderBy(q => q.Name));
            }
        }
        [RelayCommand]
        private void SearchTextChanged()
        { 
            if(allSets != null)
                this.SearchedSets = new ObservableCollection<Set>(allSets.Where(q => q != null).OrderBy(q=>q.Name).Where(q => q.Name != null && q.Name.ToLower().Contains(this.SearchText.ToLower())).ToList());
        }
        [RelayCommand]
        private void SelectedSetChanged(object sender)
        {
            if(sender is Set set)
            {
                this.SetSearchPageViewModel.SetCardsByColorsPage(set.Code);
            }
        }
    }
    
}
