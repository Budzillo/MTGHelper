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
    public class FourPlayersLifeCounterContentViewModel : BasePlayersLifeTotalViewModel
    {
        private VerticalPlayerLifeContent bottomLeftVerticalPlayerLifeContent;
        private VerticalPlayerLifeContent bottomRightVerticalPlayerLifeContent;
        private VerticalPlayerLifeContent topLeftVerticalPlayerLifeContent;
        private VerticalPlayerLifeContent topRightVerticalPlayerLifeContent;
        public VerticalPlayerLifeContent BottomLeftVerticalPlayerLifeContent
        {
            get { return bottomLeftVerticalPlayerLifeContent; }
            set
            {
                if (value == bottomLeftVerticalPlayerLifeContent) return;
                bottomLeftVerticalPlayerLifeContent = value;
                return;
            }
        }
        public VerticalPlayerLifeContent BottomRightVerticalPlayerLifeContent
        {
            get { return bottomRightVerticalPlayerLifeContent; }
            set
            {
                if (value == bottomRightVerticalPlayerLifeContent) return;
                bottomRightVerticalPlayerLifeContent = value;
                return;
            }
        }
        public VerticalPlayerLifeContent TopLeftVerticalPlayerLifeContent
        {
            get { return topLeftVerticalPlayerLifeContent; }
            set
            {
                if (value == topLeftVerticalPlayerLifeContent) return;
                topLeftVerticalPlayerLifeContent = value;
                return;
            }
        }
        public VerticalPlayerLifeContent TopRightVerticalPlayerLifeContent
        {
            get { return topRightVerticalPlayerLifeContent; }
            set
            {
                if (value == topRightVerticalPlayerLifeContent) return;
                topRightVerticalPlayerLifeContent = value;
                return;
            }
        }
        public FourPlayersLifeCounterContentViewModel()
        {
            this.bottomLeftVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.bottomRightVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topLeftVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topRightVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
        }
        public FourPlayersLifeCounterContentViewModel(ObservableCollection<PlayerModel> playerModels) : base(playerModels)
        {

        }

        public override void PrepareViews()
        {
            this.bottomLeftVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.bottomLeftVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(this.playerModels[2],180);
            this.bottomRightVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.bottomRightVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(this.playerModels[3],180);
            this.topLeftVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topLeftVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(this.playerModels[0]);
            this.topRightVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topRightVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(this.playerModels[1]);
        }
    }
}
