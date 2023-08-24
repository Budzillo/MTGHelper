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
    }
}
