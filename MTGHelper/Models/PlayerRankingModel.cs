using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Models
{
    public class PlayerRankingModel : BaseModel
    {
        private string name;
        private int deckCount;
        private bool isDeckListShow;
        private int tournamentWins;
        private List<DeckRankingModel> deckRankingModels = new List<DeckRankingModel>();

        public string Name
        {
            get => name;
            set
            {
                if(name==value) return;
                name = value;
                OnPropertyChanged();
            }
        }
        public int DeckCount
        {
            get => deckRankingModels.Count;
        }
        public bool IsDeckListShow
        {
            get => isDeckListShow;
            set
            {
                if(isDeckListShow == value) return;
                isDeckListShow = value;
                OnPropertyChanged();
            }
        }
        public int TournamentWins
        {
            get => tournamentWins;
            set
            {
                if(tournamentWins == value) return;
                tournamentWins = value;
                OnPropertyChanged();
            }
        }        
        public List<DeckRankingModel> DeckRankingModels
        {
            get => deckRankingModels;
            set
            {
                if(deckRankingModels == value) return;
                deckRankingModels = value;
                OnPropertyChanged();
            }
        }
        public PlayerRankingModel() 
        {
            
        }
    }
}
