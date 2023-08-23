using MTGHelper.Models;
using MTGHelper.Views;
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
        private HorizontalPlayerLifeContent rightHorizontalPlayerLifeContent;
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
        public HorizontalPlayerLifeContent RightHorizontalPlayerLifeContent
        {
            get { return rightHorizontalPlayerLifeContent; }
            set
            {
                if (value == rightHorizontalPlayerLifeContent) return;
                rightHorizontalPlayerLifeContent = value;
                return;
            }
        }
        public ThreePlayersLifeCounterContentViewModel()
        {
            this.bottomVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.rightHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
        }
        public ThreePlayersLifeCounterContentViewModel(LifeCounterPageViewModel lifeCounterPageViewModel) : base(lifeCounterPageViewModel)
        {

        }

        public override void PrepareViews()
        {
            this.bottomVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.bottomVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel,1);
            this.topVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel,2);
            this.rightHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.rightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 3);
        }
        public override void RotateLifeTotal()
        {
            RotateLabelFromContent(bottomVerticalPlayerLifeContent);
            RotateLabelFromContent(topVerticalPlayerLifeContent);
            RotateLabelFromContent(rightHorizontalPlayerLifeContent);
        }
    }
}
