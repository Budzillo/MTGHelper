using CommunityToolkit.Mvvm.Input;
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
    public partial class SetsPageViewModel : BaseViewModel
    {
        private SetRepository repository;
        private List<ISet> allSets;
        private ObservableCollection<ISet> searchedSets;
        private string searchText;
        public ObservableCollection<ISet> SearchedSets
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
        public SetsPageViewModel()
        {
            Initialization();
        }
        private async void Initialization()
        {
            this.repository = new SetRepository();
            this.allSets = await repository.GetSets();
            this.SearchedSets = new ObservableCollection<ISet>(allSets.OrderBy(q => q.Name).ThenByDescending(q => q.ReleaseDate));
        }
        [RelayCommand]
        private void SearchTextChanged()
        {
            this.SearchedSets = new ObservableCollection<ISet>(allSets.OrderBy(q=>q.Name).ThenByDescending(q => q.ReleaseDate).Where(q => q.Name.ToLower().Contains(this.SearchText.ToLower())));
        }
    }
}
