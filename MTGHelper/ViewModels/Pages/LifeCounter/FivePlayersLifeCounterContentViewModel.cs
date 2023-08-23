using MTGHelper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public partial class FivePlayersLifeCounterContentViewModel  : BasePlayersLifeTotalViewModel
    {
        private HorizontalPlayerLifeContent bottomLeftHorizontalPlayerLifeContent;
        private HorizontalReversePlayerLifeContent bottomRightHorizontalPlayerLifeContent;
        private HorizontalPlayerLifeContent topLeftHorizontalPlayerLifeContent;
        private HorizontalReversePlayerLifeContent topRightHorizontalPlayerLifeContent;
        private VerticalPlayerLifeContent bottomVerticalPlayerLifeContent;
        public HorizontalPlayerLifeContent BottomLeftHorizontalPlayerLifeContent
        {
            get { return bottomLeftHorizontalPlayerLifeContent; }
            set
            {
                if (value == bottomLeftHorizontalPlayerLifeContent) return;
                bottomLeftHorizontalPlayerLifeContent = value;
                return;
            }
        }
        public HorizontalReversePlayerLifeContent BottomRightHorizontalPlayerLifeContent
        {
            get { return bottomRightHorizontalPlayerLifeContent; }
            set
            {
                if (value == bottomRightHorizontalPlayerLifeContent) return;
                bottomRightHorizontalPlayerLifeContent = value;
                return;
            }
        }
        public HorizontalPlayerLifeContent TopLeftHorizontalPlayerLifeContent
        {
            get { return topLeftHorizontalPlayerLifeContent; }
            set
            {
                if (value == topLeftHorizontalPlayerLifeContent) return;
                topLeftHorizontalPlayerLifeContent = value;
                return;
            }
        }
        public HorizontalReversePlayerLifeContent TopRightHorizontalPlayerLifeContent
        {
            get { return topRightHorizontalPlayerLifeContent; }
            set
            {
                if (value == topRightHorizontalPlayerLifeContent) return;
                topRightHorizontalPlayerLifeContent = value;
                return;
            }
        }
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
        public FivePlayersLifeCounterContentViewModel()
        {
            
        }
        public FivePlayersLifeCounterContentViewModel(LifeCounterPageViewModel lifeCounterPageViewModel) : base(lifeCounterPageViewModel)
        {

        }

        public override void PrepareViews()
        {
            this.bottomLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.bottomLeftHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 3, 180);
            this.bottomRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.bottomRightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 4, 180);
            this.topLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.topLeftHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 1);
            this.topRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.topRightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 2);
            this.bottomVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.bottomVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 5);
        }

        public override void RotateLifeTotal()
        {
            RotateLabelFromContent(bottomLeftHorizontalPlayerLifeContent);
            RotateLabelFromContent(bottomRightHorizontalPlayerLifeContent);
            RotateLabelFromContent(topLeftHorizontalPlayerLifeContent);
            RotateLabelFromContent(topRightHorizontalPlayerLifeContent);
            RotateLabelFromContent(bottomVerticalPlayerLifeContent);
        }
    }
}
