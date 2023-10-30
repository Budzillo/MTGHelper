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

        public override void TurnOnOffCommanderDamageMode()
        {
            throw new NotImplementedException();
        }
        public override async Task RandomFirstPlayer()
        {

            int randomNumber = Random(5,12);
            int randomPlayer = 1;
            for (int i = 0; i < randomNumber; i++)
            {
                randomPlayer = RandomFromOne(6);
                switch (randomPlayer)
                {
                    case 1: await this.BottomLeftHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 2: await this.BottomRightHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 3: await this.TopLeftHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 4: await this.TopRightHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 5: await this.BottomVerticalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                }
                await Task.Delay(300);
            }
            switch (randomPlayer)
            {
                case 1: await this.BottomLeftHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 2: await this.BottomRightHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 3: await this.TopLeftHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 4: await this.TopRightHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 5: await this.BottomVerticalPlayerLifeContent.ShowFirstPlayer(); break;
            }
        }
    }
}
