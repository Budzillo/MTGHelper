using MTGHelper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public class SixPlayersLifeCounterContentViewModel : BasePlayersLifeTotalViewModel
    {
        private HorizontalPlayerLifeContent bottomLeftHorizontalPlayerLifeContent;
        private HorizontalReversePlayerLifeContent bottomRightHorizontalPlayerLifeContent;        
        private HorizontalPlayerLifeContent topLeftHorizontalPlayerLifeContent;
        private HorizontalReversePlayerLifeContent topRightHorizontalPlayerLifeContent;
        private HorizontalPlayerLifeContent centerLeftHorizontalPlayerLifeContent;
        private HorizontalReversePlayerLifeContent centerRightHorizontalPlayerLifeContent;
        public HorizontalPlayerLifeContent BottomLeftHorizontallayerLifeContent
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
        public HorizontalPlayerLifeContent CenterLeftHorizontalPlayerLifeContent
        {
            get { return centerLeftHorizontalPlayerLifeContent; }
            set
            {
                if (value == centerLeftHorizontalPlayerLifeContent) return;
                centerLeftHorizontalPlayerLifeContent = value;
                return;
            }
        }
        public HorizontalReversePlayerLifeContent CenterRightHorizontalPlayerLifeContent
        {
            get { return centerRightHorizontalPlayerLifeContent; }
            set
            {
                if (value == centerRightHorizontalPlayerLifeContent) return;
                centerRightHorizontalPlayerLifeContent = value;
                return;
            }
        }

        public SixPlayersLifeCounterContentViewModel()
        {
            
        }
        public SixPlayersLifeCounterContentViewModel(LifeCounterPageViewModel lifeCounterPageViewModel) : base(lifeCounterPageViewModel)
        {

        }

        public override void PrepareViews()
        {
            this.bottomLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.bottomLeftHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 5, 180);
            this.bottomRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.bottomRightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 6, 180);
            this.topLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.topLeftHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 1);
            this.topRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.topRightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 2);
            this.centerLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.centerLeftHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 3);
            this.centerRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.centerRightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 4);
        }
        public override void RotateLifeTotal()
        {
            RotateLabelFromContent(bottomLeftHorizontalPlayerLifeContent);
            RotateLabelFromContent(bottomRightHorizontalPlayerLifeContent);
            RotateLabelFromContent(topLeftHorizontalPlayerLifeContent);
            RotateLabelFromContent(topRightHorizontalPlayerLifeContent);
            RotateLabelFromContent(centerLeftHorizontalPlayerLifeContent);
            RotateLabelFromContent(centerRightHorizontalPlayerLifeContent);
        }

        public override void TurnOnOffCommanderDamageMode()
        {
            throw new NotImplementedException();
        }

        public override async Task RandomFirstPlayer()
        {

            int randomNumber = Random(11, 21);
            int randomPlayer = 1;
            for (int i = 0; i < randomNumber; i++)
            {
                randomPlayer = RandomFromOne(7);
                switch (randomPlayer)
                {
                    case 1: await this.bottomLeftHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 2: await this.BottomRightHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 3: await this.centerLeftHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 4: await this.centerRightHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 5: await this.topLeftHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 6: await this.topRightHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                }
                await Task.Delay(300);

            }
            switch (randomPlayer)
            {
                case 1: await this.bottomLeftHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 2: await this.BottomRightHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 3: await this.centerLeftHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 4: await this.centerRightHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 5: await this.topLeftHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 6: await this.topRightHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
            }
        }
    }
}
