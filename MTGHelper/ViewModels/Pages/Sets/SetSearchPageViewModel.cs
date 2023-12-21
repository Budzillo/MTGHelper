using CommunityToolkit.Mvvm.Input;
using MTGHelper.Pages;
using MTGHelper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class SetSearchPageViewModel : BaseViewModel
    {
        private ContentView selectedContentView;
        private SetsContent setsContent;
        private CardsByColorsContent cardsByColorsContent;
        public ContentView SelectedContentPage
        {
            get => selectedContentView;
            set
            {
                if(selectedContentView == value) return;
                selectedContentView = value;
                OnPropertyChanged();
            }
        }
        public SetsContent SetsContent
        {
            get => setsContent;
            set
            {
                if(setsContent == value) return;
                setsContent = value;
                OnPropertyChanged();
            }
        }
        public CardsByColorsContent CardsByColorsContent
        {
            get=> cardsByColorsContent;
            set
            {
                if(cardsByColorsContent == value) return;
                cardsByColorsContent = value;
                OnPropertyChanged();
            }
        }
        public SetSearchPageViewModel() 
        {
            PreparePages();
        }
        private void PreparePages()
        {
            this.CardsByColorsContent = new CardsByColorsContent();   
            this.SetsContent = new SetsContent();
            this.SetsContent.BindingContext = new SetsContentViewModel(this);
            this.SelectedContentPage = this.SetsContent;
        }
        [RelayCommand]
        private void SetSetsPage()
        {
            this.SelectedContentPage = this.SetsContent;
        }
        public void SetCardsByColorsPage(string setName)
        {
            this.CardsByColorsContent = new CardsByColorsContent();
            this.CardsByColorsContent.BindingContext = new CardsByColorsContentViewModel(this,setName);
            this.SelectedContentPage = this.CardsByColorsContent;
        }

    }
}
