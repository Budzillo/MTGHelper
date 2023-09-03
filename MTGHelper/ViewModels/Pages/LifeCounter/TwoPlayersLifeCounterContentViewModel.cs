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
    public class TwoPlayersLifeCounterContentViewModel : BasePlayersLifeTotalViewModel
    {
        private VerticalPlayerLifeContent bottomVerticalPlayerLifeContent;
        private VerticalPlayerLifeContent topVerticalPlayerLifeContent;
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
        public TwoPlayersLifeCounterContentViewModel()
        {
            this.bottomVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.topVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
        }
        public TwoPlayersLifeCounterContentViewModel(LifeCounterPageViewModel lifeCounterPageViewModel) : base(lifeCounterPageViewModel)
        {

        }
        
        public override void PrepareViews()
        {
            this.BottomVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.BottomVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 1);
            this.TopVerticalPlayerLifeContent = new VerticalPlayerLifeContent();
            this.TopVerticalPlayerLifeContent.BindingContext = new PlayerLifeTotalViewModel(lifeCounterPageViewModel, 2);
        }
        public override void RotateLifeTotal()
        {
            RotateLabelFromContent(bottomVerticalPlayerLifeContent);
            RotateLabelFromContent(topVerticalPlayerLifeContent);
        }

        public override void TurnOnOffCommanderDamageMode()
        {
            throw new NotImplementedException();
        }

        public override async Task RandomFirstPlayer()
        {
           
            int randomNumber = Random(11,21);
            int randomPlayer = 1;
            for (int i = 0; i < randomNumber; i++)
            {
                randomPlayer = RandomFromOne(3);
                switch (randomPlayer)
                {
                    case 1: await this.BottomVerticalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                    case 2: await this.TopVerticalPlayerLifeContent.FlashRandomFirstPlayer(); break;
                }
                await Task.Delay(300);

            }
            switch (randomPlayer)
            {
                case 1: await this.BottomVerticalPlayerLifeContent.ShowFirstPlayer(); break;
                case 2: await this.TopVerticalPlayerLifeContent.ShowFirstPlayer(); break;
            }
        }
    }
}
