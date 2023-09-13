using CommunityToolkit.Mvvm.Input;
using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class MainDecksContentViewModel : BaseViewModel
    {
        private ObservableCollection<DeckModel> deckModels = new ObservableCollection<DeckModel>();
        public ObservableCollection<DeckModel> DeckModels
        {
            get => deckModels;
            set
            {
                if(deckModels == value) return;
                deckModels = value;
                OnPropertyChanged();
            }
        }
        [RelayCommand]
        private void AddDeck()
        {

        }
        public MainDecksContentViewModel()
        {

        }

    }
}
