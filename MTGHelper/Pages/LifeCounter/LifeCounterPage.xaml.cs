namespace MTGHelper.Pages;

public partial class LifeCounterPage : ContentPage
{
	public LifeCounterPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		if (this.scrollViewOptions.HeightRequest == 0)
		{
			this.scrollViewOptions.HeightRequest = 60;
		}
		else this.scrollViewOptions.HeightRequest = 0;
    }
    
}