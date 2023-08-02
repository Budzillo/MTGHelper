using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public abstract class BasePlayersLifeTotalViewModel : BaseViewModel
    {
        public ObservableCollection<PlayerModel> playerModels;
        public BasePlayersLifeTotalViewModel() { }
        public BasePlayersLifeTotalViewModel(ObservableCollection<PlayerModel> playerModels)
        {
            this.playerModels = playerModels;
            this.PrepareViews();
        }
        public abstract void PrepareViews();
    }
}
