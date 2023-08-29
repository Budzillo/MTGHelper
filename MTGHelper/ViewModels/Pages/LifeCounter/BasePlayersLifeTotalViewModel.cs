using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MTGHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.ViewModels
{
    public abstract partial class BasePlayersLifeTotalViewModel : BaseViewModel
    {
        internal LifeCounterPageViewModel lifeCounterPageViewModel;
        public BasePlayersLifeTotalViewModel() { }
        public BasePlayersLifeTotalViewModel(LifeCounterPageViewModel lifeCounterPageViewModel)
        {
            this.lifeCounterPageViewModel = lifeCounterPageViewModel;
            this.PrepareViews();
        }
        public abstract void PrepareViews();

        public abstract void RotateLifeTotal();
        internal async void RotateLabelFromContent(ContentView contentView)
        {
            var labelObject = contentView.FindByName("labelSelectedValue");
            if (labelObject != null && labelObject is Label label)
            {
                await MainThread.InvokeOnMainThreadAsync(() => {
                    var animation = new Animation(v => label.RotationX = v, 0, 360);
                    animation.Commit((IAnimatable)label.Parent, "LabelRotateAnimation", 16, 600, Easing.Linear);
                });
            }
        }
        public abstract void TurnOnOffCommanderDamageMode();

    }
}
