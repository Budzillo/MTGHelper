using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Controls
{
    public class FadingImageButton : ImageButton
    {
        public FadingImageButton() 
        {
            this.Clicked += OnButtonClicked;
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if(sender is FadingImageButton button)
            {
                
                
            }
        }
    }
}
