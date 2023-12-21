using CommunityToolkit.Mvvm.Input;
using MTGHelper.Pages.Ranking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class MainRankingViewModel : BaseViewModel
    {
        private ContentView currentSelectedPage;

        public ContentView CurrentSelectedPage
        {
            get => currentSelectedPage;
            set
            {
                if(currentSelectedPage == value) return;
                currentSelectedPage = value;
                OnPropertyChanged();
            }
        }
        public RankingDecks RankingDecks { get; set; } = new RankingDecks();
        public RankingPowerLevel RankingPowerLevel { get; set; } = new RankingPowerLevel();
        [RelayCommand]
        private void SelectPowerLavelPage()
        {
            CurrentSelectedPage = RankingPowerLevel;
        }
        [RelayCommand]
        private void SelectDeckPage()
        {
            CurrentSelectedPage = RankingDecks;
        }
        public MainRankingViewModel() 
        {
            CurrentSelectedPage = RankingDecks;
        }

    }
}
