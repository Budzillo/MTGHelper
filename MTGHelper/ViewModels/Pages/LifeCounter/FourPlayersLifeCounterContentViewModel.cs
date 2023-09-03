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
    public class FourPlayersLifeCounterContentViewModel : BasePlayersLifeTotalViewModel
    {
        private HorizontalPlayerLifeContent bottomLeftHorizontalPlayerLifeContent;
        private HorizontalReversePlayerLifeContent bottomRightHorizontalPlayerLifeContent;
        private HorizontalPlayerLifeContent topLeftHorizontalPlayerLifeContent;
        private HorizontalReversePlayerLifeContent topRightHorizontalPlayerLifeContent;
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
        public FourPlayersLifeCounterContentViewModel()
        {
            this.bottomLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.bottomRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.topLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.topRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
        }
        public FourPlayersLifeCounterContentViewModel(LifeCounterPageViewModel lifeCounterPageViewModel) : base(lifeCounterPageViewModel)
        {

        }

        public override void PrepareViews()
        {
            this.bottomLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.bottomLeftHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel,3,180);
            this.bottomRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.bottomRightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 4, 180);
            this.topLeftHorizontalPlayerLifeContent = new HorizontalPlayerLifeContent();
            this.topLeftHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 1);
            this.topRightHorizontalPlayerLifeContent = new HorizontalReversePlayerLifeContent();
            this.topRightHorizontalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 2);
        }
        public override void RotateLifeTotal()
        {
            RotateLabelFromContent(bottomLeftHorizontalPlayerLifeContent);
            RotateLabelFromContent(bottomRightHorizontalPlayerLifeContent);
            RotateLabelFromContent(topLeftHorizontalPlayerLifeContent);
            RotateLabelFromContent(topRightHorizontalPlayerLifeContent);
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
                randomPlayer = RandomFromOne(5);
                switch (randomPlayer)
                {
                    case 1: await this.BottomLeftHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 2: await this.BottomRightHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 3: await this.TopLeftHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 4: await this.TopRightHorizontalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                }
                await Task.Delay(300);
            }
            switch (randomPlayer)
            {
                case 1: await this.BottomLeftHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 2: await this.BottomRightHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 3: await this.TopLeftHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
                case 4: await this.TopRightHorizontalPlayerLifeContent.ShowFirstPlayer(); break;
            }
        }
    }
}
