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
        internal LifeCounterPageViewModel lifeCounterPageViewModel;
        public BasePlayersLifeTotalViewModel() { }
        public BasePlayersLifeTotalViewModel(LifeCounterPageViewModel lifeCounterPageViewModel)
        {
            this.lifeCounterPageViewModel = lifeCounterPageViewModel;
            this.PrepareViews();
        }
        public abstract void PrepareViews();
    }
}
