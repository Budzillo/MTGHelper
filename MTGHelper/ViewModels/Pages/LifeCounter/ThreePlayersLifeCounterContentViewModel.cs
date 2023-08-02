using MTGHelper.Models;
using MTGHelper.Pages.LifeCounter.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    class ThreePlayersLifeCounterContentViewModel : BasePlayersLifeTotalViewModel
    {
        private VerticalPlayerLifeContent bottomVerticalPlayerLifeContent;
        private VerticalPlayerLifeContent topVerticalPlayerLifeContent;
        private VerticalPlayerLifeContent rightVerticalPlayerLifeContent;
        public VerticalPlayerLifeContent BottomVerticalPlayerLifeContent
        {
            get { return bottomVerticalPlayerLifeContent; }
            set
            {
                if (value == bottomVerticalPlayerLifeContent) return;
                bottomVerticalPlayerLifeContent = value;
                return;
            }
        }
        public VerticalPlayerLifeContent TopVerticalPlayerLifeContent
        {
            get { return topVerticalPlayerLifeContent; }
            set
            {
                if (value == topVerticalPlayerLifeContent) return;
                topVerticalPlayerLifeContent = value;
                return;
            }
        }
        public VerticalPlayerLifeContent RightVerticalPlayerLifeContent
        {
            get { return rightVerticalPlayerLifeContent; }
            set
            {
                if (value == rightVerticalPlayerLifeContent) return;
                rightVerticalPlayerLifeContent = value;
                return;
            }
        }
        public ThreePlayersLifeCounterContentViewModel()
        {
            this.bottomVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.rightVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
        }
        public ThreePlayersLifeCounterContentViewModel(ObservableCollection<PlayerModel> playerModels) : base(playerModels)
        {

        }

        public override void PrepareViews()
        {
            this.bottomVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.bottomVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(this.playerModels[0]);
            this.topVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(this.playerModels[1]);
            this.rightVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.rightVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(this.playerModels[2]);
        }
    }
}
